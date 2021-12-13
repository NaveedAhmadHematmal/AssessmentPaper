namespace AssessmentPaper.WebApi.Persistence.Core;

public interface IQuestionRepository<TEntity> where TEntity : class
{
    public TEntity AddQuestionToACategory(string category, TEntity question);
    public IEnumerable<TEntity> GetNQuestionsFromXCategory(string category, int numberOfQuestions);
    public IEnumerable<TEntity> GetNQuestionsFromXCategoryOfSpecificTags(string Category, int numberOfQuestions, string[] tags);
}