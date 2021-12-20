using AssessmentPaper.WebApi.Areas.Data;
using AssessmentPaper.WebApi.Areas.Policies.Admin;
using AssessmentPaper.WebApi.Areas.Policies.Read;
using AssessmentPaper.WebApi.Areas.Policies.Write;
using AssessmentPaper.WebApi.Persistence;
using AssessmentPaper.WebApi.Persistence.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

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

    public static IServiceCollection AddIdentity(this IServiceCollection services)
    {
        // adds Identity to WebApi
        services.AddIdentity<IdentityUser, IdentityRole>(options => 
            options.Password.RequiredLength = 8)
            .AddEntityFrameworkStores<IdentityDatabaseContext>()
            .AddDefaultTokenProviders();

        // Authorization Policies
        services.AddAuthorization(options =>{
            options.AddPolicy(
                "CanWrite",
                policyBuilder => 
                policyBuilder.AddRequirements(
                    new WriteRequirement()
                )
            );
            options.AddPolicy(
                "CanRead",
                policyBuilder =>
                policyBuilder.AddRequirements(
                    new ReadRequirement()
                )
            );
            options.AddPolicy(
                "CanControl",
                policyBuilder =>
                policyBuilder.AddRequirements(
                    new AdminRequirement()
                )
            );
        });

        // Authorization Handlers
        services.AddSingleton<IAuthorizationHandler, AdminHandler>();
        services.AddSingleton<IAuthorizationHandler, WriteHandler>();
        services.AddSingleton<IAuthorizationHandler, ReadHandler>();
        services.AddSingleton<IAuthorizationHandler, AdminToWriteHandler>();
        services.AddSingleton<IAuthorizationHandler, AdminToReadHandler>();
        services.AddSingleton<IAuthorizationHandler, WriteToReadHandler>();
        
        return services;
    }
}