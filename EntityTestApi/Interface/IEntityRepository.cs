using EntityTestApi.Models;

namespace EntityTestApi.Interface
{
    public interface IEntityRepository
    {
        Task<Entity> GetEntityAsync(Guid entityId);
        Task<bool> CreateEntityAsync(Entity entity);
        Task<bool> SaveAsync();
    }
}
