using AssessmentPaper.WebApi.AppModel;

namespace AssessmentPaper.WebApi.DISettings;

public static class AddExtensions
{
    public static IServiceCollection AddClients(this IServiceCollection services){
        services.AddTransient<AddQuestionApiModel>();
        services.AddTransient(typeof(DbClient<>));
        
        return services;
    }
}