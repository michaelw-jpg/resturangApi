using Humanizer;
using Microsoft.EntityFrameworkCore;
using resturangApi.Data;
using resturangApi.Dto.UserDtos;
using resturangApi.Mappers;
using resturangApi.Models;
using resturangApi.Repositories.Interface;
using resturangApi.Services;
using resturangApi.Services.Iservices;

namespace resturangApi.Repositories
{
    public class GenericRepository(ResturangApiDbContext context, IPasswordHasher passwordHasher) : IGenericRepository
    {
        private readonly ResturangApiDbContext _context = context;
        private readonly IPasswordHasher _passwordHasher = passwordHasher;

        public async Task<List<TEntity>> GetAll<TEntity>() where TEntity : class
        {
            var items = await _context.Set<TEntity>().ToListAsync();
            return items;
        }

        public async Task<TEntity> GetItemByID<TEntity>(object id) where TEntity : class
        {
            return await _context.Set<TEntity>().FindAsync(id);

        }

        public async Task<TEntity> CreateItem<TEntity>(TEntity entity) where TEntity : class
        {

            if (entity is User user && user.PasswordHash != null)
            {
                var password = _passwordHasher.Hash(user.PasswordHash);
                user.PasswordHash = password;
            }
            
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
            if (dto is PatchUserDto userDto && userDto.PasswordHash != null)
            {
                var password = _passwordHasher.Hash(userDto.PasswordHash);
                userDto.PasswordHash = password;
            }
            
            GenericMapper.ApplyPatch(entity, dto);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<bool> DeleteItem<TEntity>(object id) where TEntity : class
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