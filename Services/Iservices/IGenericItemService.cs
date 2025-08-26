namespace resturangApi.Services.Iservices
{
    public interface IGenericItemService
    {

        Task<List<TEntity>> GetAll<TEntity>() where TEntity : class;

        Task<TEntity> GetItemByID<TEntity>(object id) where TEntity : class;


        Task<TEntity> CreateItem<TEntity, TDto>(TDto dto)
            where TEntity : class
            where TDto : class;


        Task<TEntity> UpdateItem<TEntity, TDto>(object id, TDto dto)
        where TEntity : class
        where TDto : class;


        Task<bool> DeleteItem<TEntity>(object id) where TEntity : class;
    }
}
