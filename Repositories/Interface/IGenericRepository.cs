using resturangApi.Models;

namespace resturangApi.Repositories.Interface
{
    public interface IGenericRepository
    {
        Task<List<TEntity>> GetAll<TEntity>() where TEntity : class;
        Task<TEntity> GetItemByID<TEntity>(object id) where TEntity : class ;
        Task<TEntity> CreateItem<TEntity>(TEntity entity)where TEntity : class ;
        Task<TEntity> UpdateItem<TEntity, TDto>(object id, TDto dto)
            where TEntity : class
            where TDto : class;
        Task<bool> DeleteItem<TEntity>(object id) where TEntity :class;
    }
}
