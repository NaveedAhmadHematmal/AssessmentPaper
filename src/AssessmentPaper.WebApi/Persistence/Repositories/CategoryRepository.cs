using AssessmentPaper.WebApi.Models;
using AssessmentPaper.WebApi.Persistence.Core;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AssessmentPaper.WebApi.Persistence.Repositories;

public class CategoryRepository : ICategoryRepository<CategoryModel>
{
    public DbClient DbClient { get; }
    public CategoryRepository(DbClient dbClient)
    {
        DbClient = dbClient;
    }
    public CategoryModel AddCategory(CategoryModel category)
    {
        var db = DbClient.Client().GetCollection<CategoryModel>("Categories");
        if(!IsCategoryAvailable(category.CategoryName)){
            db.InsertOne(category);
            return category;
        }else{
            throw new Exception($"{category.CategoryName} category is already in database");
        }
    }

    public IEnumerable<CategoryModel> AddRangeCategory(IEnumerable<CategoryModel> categories)
    {
        throw new NotImplementedException();
    }

    public CategoryModel DeleteCategory(Guid _id)
    {
        throw new NotImplementedException();
    }

    public bool IsCategoryAvailable(string category)
    {
         var db = DbClient.Client().GetCollection<CategoryModel>("Categories").Find(new BsonDocument()).ToList();
        
        var s = db.Where(x => x.CategoryName.Contains(category)).Count();

        return s > 0 ? true : false;
    }
}