using AssessmentPaper.WebApi.Filters;
using AssessmentPaper.WebApi.Models;
using AssessmentPaper.WebApi.Persistence.Repositories;
using AssessmentPaper.WebApi.Utilities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AssessmentPaper.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    private readonly ILogger<HomeController> _logger;
    private readonly UnitOfWork unitOfWork;

    public HomeController(ILogger<HomeController> logger, UnitOfWork unitOfWork)
    {
        _logger = logger;
        this.unitOfWork = unitOfWork;
    }

    [Route("[Action]/{Category}")]
    [HttpPost]
    [ValidateModel]
    public IActionResult AddQuestionToACategory([FromBody] QuestionModel questionModel, [FromRoute] string Category){
        try
        {
            return Ok(unitOfWork.AddQuestionToACategory(Category, questionModel));
        }
        catch (System.Exception ex)
        {
            return NotFound($"{ex.Message} tags are not available");
        }
    }

    [Route("[Action]/{Category}")]
    [HttpGet]
    public IActionResult GetNQuestionsFromACategory(string Category, int numberOfQuestions){
        return Ok(unitOfWork.GetNQuestionsFromXCategory(Category, numberOfQuestions));
    }

    [Route("[Action]/{Category}/{numberOfQuestions}/{tags}")]
    [HttpGet]
    public IActionResult GetNQuestionsFromXCategoryOfSpecificTags(string Category, int numberOfQuestions, string tags){
        return Ok(unitOfWork.GetNQuestionsFromXCategoryOfSpecificTags(Category, numberOfQuestions, tags.SplitCommanSeperatedStringIntoObjectArray()));
    }
}
