using Abc.Application.Contracts.Persistence;
using Abc.Domain.Common;
using Abc.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Abc.Infrastructure.Repositories
{
    public class BaseRepository<T>(AbcContext context) : IBaseRepository<T> where T : BaseDomainModel
    {
        protected readonly AbcContext _context = context;

        public void AddEntity(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}
