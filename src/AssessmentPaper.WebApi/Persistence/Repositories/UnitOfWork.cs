using AssessmentPaper.WebApi.Models;
using AssessmentPaper.WebApi.Persistence.Core;
using Microsoft.AspNetCore.Mvc;

namespace AssessmentPaper.WebApi.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly DbClient _context;
    private IQuestionRepository<QuestionModel> Questions { get; set; }
    private ITagRepository<TagModel> Tags {get; set;}
    private ICategoryRepository<CategoryModel> Categories {get;set;}
    public UnitOfWork([FromServices] DbClient context, QuestionRepository question, TagRepository tags, CategoryRepository category)
    {
        _context = context;
        Questions = question;
        Tags = tags;
        Categories = category;
    }
    public int Complete()
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public QuestionModel AddQuestionToACategory(string category, QuestionModel question){
        List<string> notAvailableTags = new();
        bool allTagsAvailable = true;
        if(!Categories.IsCategoryAvailable(category)){
            throw new Exception($"{category} not available");
        }
        foreach (var item in question.Tags)
        {
            if(!Tags.IsTagAvailable(item)){
                notAvailableTags.Add(item);
                allTagsAvailable = false;
            }
        }
        if(allTagsAvailable){
            return Questions.AddQuestionToACategory(category, question);
        }
        
        throw new Exception(String.Join(", ", notAvailableTags.ToArray()));
    }

    public IEnumerable<QuestionModel> GetNQuestionsFromXCategory(string category, int numberOfQuestions)
    {
        return Questions.GetNQuestionsFromXCategory(category, numberOfQuestions);
    }

    public IEnumerable<QuestionModel> GetNQuestionsFromXCategoryOfSpecificTags(string Category, int numberOfQuestions, string[] tags)
    {
        return Questions.GetNQuestionsFromXCategoryOfSpecificTags(Category, numberOfQuestions, tags);
    }

    public TagModel AddTag(TagModel tag){
        return Tags.AddTag(tag);
    }

    public IEnumerable<TagModel> GetTags()
    {
        return Tags.GetTags();
    }

    public CategoryModel AddCategory(CategoryModel category)
    {
        return Categories.AddCategory(category);
    }

    public IEnumerable<string> GetTagsSuggestions(string question){
        return Tags.GetTagsSuggestions(question);
    }
}