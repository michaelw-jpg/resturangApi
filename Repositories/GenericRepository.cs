using Microsoft.EntityFrameworkCore;
using resturangApi.Data;
using resturangApi.Mappers;
using resturangApi.Repositories.Interface;

namespace resturangApi.Repositories
{
    public class GenericRepository : IGenericRepository
    {
        private readonly ResturangApiDbContext _context;
        public GenericRepository(ResturangApiDbContext context)
        {
            _context = context;
        }
        public async Task<List<TEntity>> GetAll<TEntity>() where TEntity : class
        {
            var items = await _context.Set<TEntity>().ToListAsync();
            return items;
        }

        public async Task<TEntity> GetItemByID<TEntity>(int id) where TEntity : class
        {
            return await _context.Set<TEntity>().FindAsync(id);

        }

        public async Task<TEntity> CreateItem<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;

        }

        public async Task<TEntity> UpdateItem<TEntity, TDto>(object id, TDto dto) 
            where TEntity : class
            where TDto : class
        {
           var entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return null;
            }
            GenericPatchMapper.ApplyPatch(entity, dto);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<bool> DeleteItem<TEntity>(int id) where TEntity : class
        {
            var entity = await GetItemByID<TEntity>(id);
            if (entity == null)
            {
                return false;
            }
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}