using Microsoft.EntityFrameworkCore;
using Hotels.Core;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Hotels.Data.Repositories
{
    public abstract class BaseRepository<TModel, TDataEntity> : IRepository<TModel>
            where TModel : class, IModelEntity
            where TDataEntity : class
    {
        protected readonly IUnitOfWork UnitOfWork;

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<TModel> GetByIdAsync(int id)
        {
            TDataEntity dataEntity = await this.UnitOfWork.GetByIdAsync<TDataEntity>(id).ConfigureAwait(false);

            if (dataEntity == null)
            {
                return null;
            }

            TModel result = this.ToModel(dataEntity);

            return result;
        }

        public async Task<TModel[]> GetAllAsync()
        {
            TDataEntity[] entities = await this.GetAllQuery().ToArrayAsync().ConfigureAwait(false);

            TModel[] result = entities.Select(e => this.ToModel(e)).ToArray();

            return result;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await this.GetByIdAsync(id).ConfigureAwait(false) != null;
        }

        public async Task<TModel> SaveAsync(TModel entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            TDataEntity dataEntity = this.ToDataEntity(entity);

            await this.MarkAsCreatedOrUpdated(entity, dataEntity).ConfigureAwait(false);
            await this.UnitOfWork.SaveAllAsync().ConfigureAwait(false);

            TModel result = this.ToModel(dataEntity);

            return result;
        }

        public async Task<TModel[]> SaveAsync(params TModel[] entities)
        {
            if (entities is null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            TDataEntity[] dataEntities = entities.Select(this.ToDataEntity).ToArray();
            for (int i = 0; i < dataEntities.Length; i++)
            {
                await this.MarkAsCreatedOrUpdated(entities[i], dataEntities[i]).ConfigureAwait(false);
            }

            await this.UnitOfWork.SaveAllAsync().ConfigureAwait(false);

            TModel[] result = dataEntities.Select(this.ToModel).ToArray();

            return result;
        }

        public virtual async Task DeleteAsync(TModel entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            TDataEntity dataEntity = this.ToDataEntity(entity);
            this.UnitOfWork.MarkAsDeletedAsync(dataEntity);

            await this.UnitOfWork.SaveAllAsync().ConfigureAwait(false);
        }

        public virtual async Task InsertHotelAsync(TModel entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            TDataEntity dataEntity = this.ToDataEntity(entity);
            await this.UnitOfWork.MarkAsCreatedAsync(dataEntity);

            await this.UnitOfWork.SaveAllAsync().ConfigureAwait(false);
        }

        protected abstract TModel ToModel(TDataEntity entity);

        protected abstract TDataEntity ToDataEntity(TModel model);

        protected IQueryable<TDataEntity> GetAllQuery()
        {
            IQueryable<TDataEntity> result = this.UnitOfWork.GetAllQuery<TDataEntity>();

            return result;
        }

        protected virtual Task<bool> IsNewAsync(TModel entity)
        {
            return Task.FromResult(entity.Id == 0);
        }

        private async Task MarkAsCreatedOrUpdated(TModel entity, TDataEntity dataEntity)
        {
            if (await this.IsNewAsync(entity))
            {
                await this.UnitOfWork.MarkAsCreatedAsync(dataEntity).ConfigureAwait(false);
                return;
            }

            this.UnitOfWork.MarkAsUpdatedAsync(dataEntity);
        }
    }
}
