using AssessmentPaper.WebApi.AppModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace AssessmentPaper.WebApi.ApiModels;

public class AddQuestionApiModel{

    private readonly IOptions<ServicesSettings> options;
    private readonly DbClient<QuestionModel> dbClient;

    public AddQuestionApiModel([FromServices] IOptions<ServicesSettings> options, [FromServices] DbClient<QuestionModel> dbClient)
    {
        this.options = options;
        this.dbClient = dbClient;
    }
    public string AddQuestion(QuestionModel questionModel, string collectionName)
    {
        dbClient.Client(collectionName).InsertOne(questionModel);
        return JsonConvert.SerializeObject(questionModel);
    }
}