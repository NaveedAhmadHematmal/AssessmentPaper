using AssessmentPaper.WebApi.Persistence;
using AssessmentPaper.WebApi.Persistence.Repositories;

namespace AssessmentPaper.WebApi.DISettings;

public static class AddExtensions
{
    public static IServiceCollection AddClients(this IServiceCollection services){
        services.AddTransient(typeof(DbClient));
        services.AddTransient<UnitOfWork>();
        services.AddSingleton<QuestionRepository>();
        services.AddSingleton<TagRepository>();
        services.AddSingleton<CategoryRepository>();
        
        return services;
    }
}