using Hotels.Core;

namespace Hotels.Data.Entities
{
    public interface IDataEntity<TModel>
        where TModel : IModelEntity
    {
        void SetProperties(TModel model);

        TModel ToModel();
    }
}
