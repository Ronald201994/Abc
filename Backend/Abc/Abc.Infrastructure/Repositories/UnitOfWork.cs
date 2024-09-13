using Abc.Application.Contracts.Persistence;
using Abc.Domain.Common;
using Abc.Infrastructure.Persistence;
using System.Collections;

namespace Abc.Infrastructure.Repositories
{
    public class UnitOfWork(AbcContext context) : IUnitOfWork
    {
        private Hashtable _repositories;
        private readonly AbcContext _context = context;

        private IEmpleadoRepository _empleadoRepository;
        public IEmpleadoRepository EmpleadoRepository => _empleadoRepository ??= new EmpleadoRepository(_context);
        public AbcContext DinetDbContext => _context;
        public async Task<int> Complete()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Err");
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IBaseRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(BaseRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                _repositories.Add(type, repositoryInstance);
            }

            return (IBaseRepository<TEntity>)_repositories[type];
        }
    }
}
