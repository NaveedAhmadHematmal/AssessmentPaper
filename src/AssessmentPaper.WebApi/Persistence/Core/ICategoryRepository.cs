using AssessmentPaper.WebApi.Models;

namespace AssessmentPaper.WebApi.Persistence.Core;

public interface ICategoryRepository<TEntity> where TEntity : class{
    public CategoryModel AddCategory(CategoryModel category);
    public CategoryModel DeleteCategory(Guid _id);
    public IEnumerable<CategoryModel> AddRangeCategory(IEnumerable<CategoryModel> categories);
    public bool IsCategoryAvailable(string category);
}