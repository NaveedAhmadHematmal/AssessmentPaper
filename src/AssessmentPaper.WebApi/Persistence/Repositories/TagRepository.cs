using AssessmentPaper.WebApi.Models;
using AssessmentPaper.WebApi.Persistence.Core;
using AssessmentPaper.WebApi.Utilities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AssessmentPaper.WebApi.Persistence.Repositories;

public class TagRepository : ITagRepository<TagModel>
{
    public DbClient DbClient { get; }
    public TagRepository(DbClient dbClient)
    {
        DbClient = dbClient;
    }

    public TagModel AddTag(TagModel tag)
    {
        var db = DbClient.Client().GetCollection<TagModel>("Tags");
        if(!IsTagAvailable(tag.Tag)){
            db.InsertOne(tag);
            return tag;
        }else{
            throw new Exception($"{tag} tag is already in database");
        }
    }

    public bool IsTagAvailable(string tag){
        var db = DbClient.Client().GetCollection<TagModel>("Tags").Find(new BsonDocument()).ToList();
        
        var s = db.Where(x => x.Tag.Contains(tag)).Count();

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

    public IEnumerable<TagModel> GetTags()
    {
        return DbClient
        .Client()
        .GetCollection<TagModel>("Tags")
        .Find(new BsonDocument())
        .ToList();
    }

    public IEnumerable<string> GetTagsSuggestions(string question){
        // Who was the first president of Afghanistan?

        question = question.RemoveExceptLetters();
        string[] words = question.SplitSpaceSeperatedStringIntoObjectArray();

        List<string> availableTagsInstring = new();

        foreach (var item in words)
        {
            if(IsTagAvailable(item)){
                availableTagsInstring.Add(item);
            }
        }

        // Remove duplicate tags
        return availableTagsInstring.Distinct().ToList();
    }
}