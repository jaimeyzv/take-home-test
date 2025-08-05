namespace Fundo.Applications.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        public Task<int> Commit(CancellationToken cancellationToken);
    }
}
