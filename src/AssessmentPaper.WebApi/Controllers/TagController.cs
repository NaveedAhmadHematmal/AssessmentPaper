using AssessmentPaper.WebApi.Models;
using AssessmentPaper.WebApi.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AssessmentPaper.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TagController : ControllerBase
{
    private readonly ILogger<HomeController> _logger;
    private readonly UnitOfWork unitOfWork;

    public TagController(ILogger<HomeController> logger, UnitOfWork unitOfWork)
    {
        _logger = logger;
        this.unitOfWork = unitOfWork;
    }

    [Route("[Action]")]
    [HttpPost]
    public IActionResult AddTag([FromBody] TagModel tag){
        return Ok(unitOfWork.Tags.AddTag(tag));
    }

    [Route("[Action]")]
    [HttpGet]
    public IActionResult GetTags(){
        return Ok(unitOfWork.Tags.GetTags());
    }
}
