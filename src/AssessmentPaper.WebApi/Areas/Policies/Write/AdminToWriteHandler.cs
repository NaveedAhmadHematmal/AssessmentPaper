using Microsoft.AspNetCore.Authorization;

namespace AssessmentPaper.WebApi.Areas.Policies.Write;

public class AdminToWriteHandler : AuthorizationHandler<WriteRequirement>{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, WriteRequirement requirement)
    {
        if(context.User.HasClaim("Permission", "Admin")){
            context.Succeed(requirement);
        }
        return Task.CompletedTask;
    } 
}