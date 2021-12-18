using Microsoft.AspNetCore.Authorization;

namespace AssessmentPaper.WebApi.Areas.Policies.Admin;

public class AdminHandler : AuthorizationHandler<AdminRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AdminRequirement requirement)
    {
        if(context.User.HasClaim("Permission", "Admin")){
            context.Succeed(requirement);
        }
        
        return Task.CompletedTask;
    }
}