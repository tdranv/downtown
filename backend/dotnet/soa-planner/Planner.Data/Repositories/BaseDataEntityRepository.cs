using Planner.Core;
using Planner.Data.Entities;
using System;

namespace Planner.Data.Repositories
{
    public class BaseDataEntityRepository<TModel, TDataEntity> : BaseRepository<TModel, TDataEntity>
                where TModel : class, IModelEntity
                where TDataEntity : class, IDataEntity<TModel>, new()
    {
        public BaseDataEntityRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected override TDataEntity ToDataEntity(TModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            TDataEntity result = new TDataEntity();
            result.SetProperties(model);
            return result;
        }

        protected override TModel ToModel(TDataEntity entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            TModel result = entity.ToModel();

            return result;
        }
    }
}
