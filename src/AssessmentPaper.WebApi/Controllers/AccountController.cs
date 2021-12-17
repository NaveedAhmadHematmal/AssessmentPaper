using System.Security.Claims;
using AssessmentPaper.WebApi.Areas.Models;
using AssessmentPaper.WebApi.Filters;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AssessmentPaper.WebApi.Controllers;

public class AccountController : ControllerBase
{
    private readonly ILogger<AccountController> _logger;
    private readonly UserManager<IdentityUser> userManager;
    private readonly SignInManager<IdentityUser> signInManager;

    public AccountController(ILogger<AccountController> logger, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _logger = logger;
        this.userManager = userManager;
        this.signInManager = signInManager;
    }

    [Route("[Action]")]
    [HttpPost]
    [ValidateModel]
    public async Task<IActionResult> Register([FromBody] RegisterModel registerModel, string returnUrl = null){
        var user = new IdentityUser(registerModel.Email);

        var result = await userManager.CreateAsync(user, registerModel.Password);

        if(result.Succeeded){
            var claim = new Claim("FullName", registerModel.FullName);
            await userManager.AddClaimAsync(user, claim);

            await signInManager.SignInAsync(user, true);

            return Ok();
        }
        return NotFound();
    }
}