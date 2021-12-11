using AssessmentPaper.WebApi.Persistence.Core;
using Microsoft.AspNetCore.Mvc;

namespace AssessmentPaper.WebApi.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly DbClient _context;
    public QuestionRepository Questions { get; private set; }
    public TagRepository Tags {get; private set;}
    public UnitOfWork([FromServices] DbClient context)
    {
        _context = context;
        Questions = new QuestionRepository(_context);
        Tags = new TagRepository(_context);
    }
    public int Complete()
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}