namespace AssessmentPaper.WebApi.Persistence.Core;

public interface IUnitOfWork : IDisposable
{
    int Complete();
}