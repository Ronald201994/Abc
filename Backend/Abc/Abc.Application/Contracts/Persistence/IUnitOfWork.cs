using Abc.Domain.Common;

namespace Abc.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IEmpleadoRepository EmpleadoRepository { get; }
        IBaseRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;
        Task<int> Complete();
    }
}
