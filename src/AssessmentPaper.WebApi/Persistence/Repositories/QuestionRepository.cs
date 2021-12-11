using AssessmentPaper.WebApi.Persistence.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace AssessmentPaper.WebApi.Persistence.Repositories;

public class QuestionRepository : Repository<QuestionRepository>, IQuestionRespository<QuestionRepository>
{
    public QuestionRepository(DbClient dbClient) : base(dbClient)
    {
        DbClient = dbClient;
    }

    public DbClient DbClient { get; }

    public QuestionModel AddQuestionToACategory(string category, QuestionModel question)
    {
        var db = DbClient.Client().GetCollection<object>(category);
        question._id = ObjectId.GenerateNewId();
        db.InsertOne(question);
        return question;
    }

    public IEnumerable<QuestionModel> GetNQuestionsFromXCategory(string category, int numberOfQuestions)
    {
        return DbClient
        .Client()
        .GetCollection<QuestionModel>(category)
        .Find(new BsonDocument())
        .ToList()
        .Take(numberOfQuestions);
    }

    public IEnumerable<QuestionModel> GetNQuestionsFromXCategoryOfSpecificTags(string Category, int numberOfQuestions, string[] tags)
    {
        var q = DbClient.Client().GetCollection<QuestionModel>(Category).Find(new BsonDocument()).ToList();
        return 
            from r in q
            where r.Tags.Any(a => a.Contains(tags[0]))
            select r;
    }
}