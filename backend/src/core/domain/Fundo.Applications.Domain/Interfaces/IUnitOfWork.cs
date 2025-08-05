namespace Fundo.Applications.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        public Task Commit(CancellationToken cancellationToken);
    }
}
