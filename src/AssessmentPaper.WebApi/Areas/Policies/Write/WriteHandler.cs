using Microsoft.AspNetCore.Authorization;

namespace AssessmentPaper.WebApi.Areas.Policies.Write;

public class WriteHandler : AuthorizationHandler<WriteRequirement>{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, WriteRequirement requirement)
    {
        if(context.User.HasClaim("Permission", "Write")){
            context.Succeed(requirement);
        }
        return Task.CompletedTask;
    } 
}