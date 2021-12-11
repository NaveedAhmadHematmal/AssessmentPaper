using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AssessmentPaper.WebApi.Persistence;

public class DbClient
{
    private readonly IOptions<ServicesSettings> options;
    public DbClient(IOptions<ServicesSettings> options)
    {
        this.options = options;
    }

    public IMongoDatabase Client(){
        var client = new MongoClient(options.Value.MongodbConnectionString);

        var database = client.GetDatabase(options.Value.MonogoDatabase);

        return database;
    }
}