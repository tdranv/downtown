using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Hotels.Data
{
    public class HotelDbContext : DbContext, IUnitOfWork
    {
        public HotelDbContext(DbContextOptions options) : base(options)
        {
        }

        public IQueryable<T> GetAllQuery<T>() where T : class
        {
            IQueryable<T> result = this.Set<T>().AsNoTracking();

            return result;
        }

        public async Task<T> GetByIdAsync<T>(object id) where T : class
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            T result = await this.Set<T>().FindAsync(id).ConfigureAwait(false);

            if (result != null)
            {
                this.Entry(result).State = EntityState.Detached;
            }

            return result;
        }

        public async Task MarkAsCreatedAsync<T>(T entity) where T : class
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await this.Set<T>().AddAsync(entity).ConfigureAwait(false);
        }

        public void MarkAsDeletedAsync<T>(T entity) where T : class
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            this.Set<T>().Attach(entity);
            this.Entry(entity).State = EntityState.Deleted;
        }

        public void MarkAsUpdatedAsync<T>(T entity) where T : class
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            this.Set<T>().Attach(entity);
        }

        public async Task SaveAllAsync()
        {
            try
            {
                await this.SaveChangesAsync().ConfigureAwait(false);
            }
            finally
            {
                foreach (EntityEntry entry in this.ChangeTracker.Entries())
                {
                    entry.State = EntityState.Detached;
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            MethodInfo[] mapMethods = typeof(HotelDbContext)
                .Assembly
                .GetTypes()
                .Select(t => t.GetMethod("Map", new[] { typeof(ModelBuilder) }))
                .Where(m => m != null && m.IsStatic && m.IsPublic)
                .ToArray();

            foreach (MethodInfo mapMethod in mapMethods)
            {
                mapMethod.Invoke(null, new object[] { modelBuilder });
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
