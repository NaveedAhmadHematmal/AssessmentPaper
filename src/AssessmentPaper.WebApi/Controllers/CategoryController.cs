using AssessmentPaper.WebApi.Filters;
using AssessmentPaper.WebApi.Models;
using AssessmentPaper.WebApi.Persistence.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AssessmentPaper.WebApi.Controllers;

[Authorize]
public class CategoryController : ControllerBase
{
    private readonly ILogger<CategoryController> _logger;
    private readonly UnitOfWork unitOfWork;

    public CategoryController(ILogger<CategoryController> logger, UnitOfWork unitOfWork)
    {
        _logger = logger;
        this.unitOfWork = unitOfWork;
    }

    [Route("[Action]")]
    [HttpPost]
    [ValidateModel]
    public IActionResult AddQuestionToACategory([FromBody] CategoryModel categoryModel){
        try
        {
            return Ok(unitOfWork.AddCategory(categoryModel));
        }
        catch (System.Exception ex)
        {
            return NotFound($"{ex.Message} tags are not available");
        }
    }

}