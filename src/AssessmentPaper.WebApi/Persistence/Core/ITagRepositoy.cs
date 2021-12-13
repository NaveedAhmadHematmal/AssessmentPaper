using AssessmentPaper.WebApi.Models;

namespace AssessmentPaper.WebApi.Persistence.Core;

public interface ITagRepository<TEntity>  where TEntity : class{
    public TEntity AddTag(TEntity tag);
    public IEnumerable<TEntity> AddTagRange(IEnumerable<TEntity> tags);
    public TEntity RemoveTag(int tagId);
    public IEnumerable<TEntity> RemoveTagRange(IEnumerable<int> tagsIds);
    public bool IsTagAvailable(string tag);
    public IEnumerable<TEntity> GetTags();
} 