using EntityTestApi.Data;
using EntityTestApi.Interface;
using EntityTestApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityTestApi.Repository
{
    public class EntityRepository : IEntityRepository
    {
        private readonly DataContext _context;

        public EntityRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateEntityAsync(Entity entity)
        {
            await _context.Entities.AddAsync(entity);
            return await SaveAsync();
        }

        public async Task<Entity> GetEntityAsync(Guid entityId)
        {
            return await _context.Entities.Where(e => e.Id == entityId).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveAsync()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }
    }
}
