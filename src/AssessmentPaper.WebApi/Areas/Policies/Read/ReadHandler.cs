using Microsoft.AspNetCore.Authorization;

namespace AssessmentPaper.WebApi.Areas.Policies.Read;

public class ReadHandler : AuthorizationHandler<ReadRequirement> {
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ReadRequirement requirement)
    {
        if(context.User.HasClaim("Permission", "Read")){
            context.Succeed(requirement);
        }
        
        return Task.CompletedTask;
    } 
}