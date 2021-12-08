using AssessmentPaper.WebApi.ApiModels;
using AssessmentPaper.WebApi.Filters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AssessmentPaper.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        
    }

    [Route("[Action]/{Category}")]
    [HttpPost]
//// TODO1: The below Action checks the body for validation without this attribute, and I can't figure out why?
    [ValidateModel]
    public IActionResult AddQuestionToACategory([FromServices] AddQuestionApiModel addQuestion, [FromBody] QuestionModel questionModel, [FromRoute] string Category){
        return Ok(addQuestion.AddQuestion(questionModel, Category));
    }
}
