using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TesteComercio.Domain.Entities;
using TesteComercio.Domain.IRepositories;
using TesteComercio.Persistence.Db;

namespace TesteComercio.Persistence.Repositories
{
    public class EfReadOnlyRepository<TEntity> : IReanOnlyRepository<TEntity>
        where TEntity : class, IEntity
    {
        protected readonly CleanArchReadOnlyDbContext DbContext;

        public DbSet<TEntity> Entities { get; }

        public virtual IQueryable<TEntity> Table => Entities;

        public virtual IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();

        public EfReadOnlyRepository(CleanArchReadOnlyDbContext dbContext)
        {
            DbContext = dbContext;
            Entities = DbContext.Set<TEntity>();
        }

        public virtual ValueTask<TEntity> GetByIdAsync(CancellationToken cancellationToken, params object[] ids)
        {
            return Entities.FindAsync(ids, cancellationToken);
        }

        public virtual TEntity GetById(params object[] ids)
        {
            return Entities.Find(ids);
        }
    }
}