using Planner.Core;

namespace Planner.Data.Entities
{
    public interface IDataEntity<TModel>
        where TModel : IModelEntity
    {
        void SetProperties(TModel model);

        TModel ToModel();
    }
}
