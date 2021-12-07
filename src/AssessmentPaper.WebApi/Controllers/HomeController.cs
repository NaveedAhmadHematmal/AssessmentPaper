using Microsoft.AspNetCore.Mvc;

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
    public IActionResult AddQuestionToACategory([FromServices] AddQuestionApiModel addQuestion, [FromBody] QuestionModel questionModel, [FromRoute] string Category){
        if(ModelState.IsValid){
            return Ok(addQuestion.AddQuestion(questionModel, Category));
        }
        return BadRequest();
    }
}
