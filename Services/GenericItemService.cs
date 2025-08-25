using Microsoft.EntityFrameworkCore;
using resturangApi.Mappers;
using resturangApi.Repositories.Interface;
using resturangApi.Services.Iservices;

namespace resturangApi.Services
{
    public class GenericItemService(IGenericRepository repo) : IGenericItemService
    {
        private readonly IGenericRepository _repo = repo;

        public async Task<List<TEntity>> GetAll<TEntity>() where TEntity : class
         {
            return await _repo.GetAll<TEntity>();
        }

        public async Task<TEntity> CreateItem<TEntity, TDto>(TDto dto)
            where TEntity : class
            where TDto : class
        {
            var entity = Activator.CreateInstance<TEntity>();
            if (entity == null)
                throw new Exception($"Could not create instance of type {typeof(TEntity).Name}");
            GenericMapper.ApplyCreate(entity, dto);
            return await _repo.CreateItem(entity);
        }

        public async Task<TEntity> UpdateItem<TEntity, TDto>(object id, TDto dto)
         where TEntity : class
         where TDto : class
        {
            
            return await _repo.UpdateItem<TEntity, TDto>(id, dto);
        }

        public async Task<bool> DeleteItem<TEntity>(object id) where TEntity : class
        {
            return await _repo.DeleteItem<TEntity>(id);
        }
    }
}
