using AssessmentPaper.WebApi.Models;
using AssessmentPaper.WebApi.Persistence.Core;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AssessmentPaper.WebApi.Persistence.Repositories;

public class TagRepository : Repository<TagRepository>, ITagRepository<TagRepository>
{
    public DbClient DbClient { get; }
    public TagRepository(DbClient dbClient) : base(dbClient)
    {
        DbClient = dbClient;
    }

    public TagModel AddTag(TagModel tag)
    {
        var db = DbClient.Client().GetCollection<TagModel>("Tags");
        if(!IsTagAvailable(tag)){
            db.InsertOne(tag);
            return tag;
        }else{
            throw new Exception($"{tag} tag is already in database");
        }
    }

    public bool IsTagAvailable(TagModel tag){
        var db = DbClient.Client().GetCollection<TagModel>("Tags").Find(new BsonDocument()).ToList();
        
        var s = db.Where(x => x.Tag.Contains(tag.Tag)).Count();

        return s > 0 ? true : false;
    }
    public IEnumerable<TagModel> AddTagRange(IEnumerable<TagModel> tags)
    {
        throw new NotImplementedException();
    }

    public TagModel RemoveTag(int tagId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TagModel> RemoveTagRange(IEnumerable<int> tagsIds)
    {
        throw new NotImplementedException();
    }
}