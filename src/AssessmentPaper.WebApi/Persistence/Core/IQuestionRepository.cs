namespace AssessmentPaper.WebApi.Persistence.Core;

public interface IQuestionRespository<TEntity> : IRepository<TEntity> where TEntity : class
{
    public QuestionModel AddQuestionToACategory(string category, QuestionModel question);
    public IEnumerable<QuestionModel> GetNQuestionsFromXCategory(string category, int numberOfQuestions);
    public IEnumerable<QuestionModel> GetNQuestionsFromXCategoryOfSpecificTags(string Category, int numberOfQuestions, string[] tags);
}