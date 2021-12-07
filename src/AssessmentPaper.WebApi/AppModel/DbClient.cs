using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AssessmentPaper.WebApi.AppModel;

public class DbClient<T>
{
    private readonly IOptions<ServicesSettings> options;
    public DbClient(IOptions<ServicesSettings> options)
    {
        this.options = options;
    }

    public IMongoCollection<T> Client(string collectionName){
        var client = new MongoClient(options.Value.MongodbConnectionString);

        var database = client.GetDatabase(options.Value.MonogoDatabase);
        var collection = database.GetCollection<T>(collectionName);

        return collection;
    }
}