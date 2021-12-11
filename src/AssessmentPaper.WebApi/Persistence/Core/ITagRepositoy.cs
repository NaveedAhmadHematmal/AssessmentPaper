using AssessmentPaper.WebApi.Models;

namespace AssessmentPaper.WebApi.Persistence.Core;

public interface ITagRepository<TEntity> : IRepository<TEntity>  where TEntity : class {
    public TagModel AddTag(TagModel tag);
    public IEnumerable<TagModel> AddTagRange(IEnumerable<TagModel> tags);
    public TagModel RemoveTag(int tagId);
    public IEnumerable<TagModel> RemoveTagRange(IEnumerable<int> tagsIds);
    public bool IsTagAvailable(TagModel tag);
} 