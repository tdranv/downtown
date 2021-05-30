using Downtown.Core;

namespace Downtown.Data.Entities
{
    public interface IDataEntity<TModel>
        where TModel : IModelEntity
    {
        void SetProperties(TModel model);

        TModel ToModel();
    }
}
