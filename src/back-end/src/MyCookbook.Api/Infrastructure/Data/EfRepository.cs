using Microsoft.EntityFrameworkCore;
using MyCookbook.Api.Domain;
using MyCookbook.Api.Domain.SharedKernel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCookbook.Api.Infrastructure.Data
{
    public class EfRepository<T> : IRepository<T> where T : Entity
    {
        protected EfRepository(MyCookBookDbContext db)
        {
            Db = db;
        }

        public IUnitOfWork UnitOfWork => Db;

        protected MyCookBookDbContext Db { get; }

        public virtual Task<T> GetByIdAsync(int id)
            => Db.Set<T>().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<T> AddAsync(T entity)
        {
            await Db.Set<T>().AddAsync(entity);
            return entity;
        }

        public void Update(T entity)
        {
            Db.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            Db.Set<T>().Remove(entity);
        }

        public virtual async Task<IReadOnlyList<T>> ListAllAsync()
            => await Db.Set<T>().AsNoTracking().ToListAsync();
    }
}
