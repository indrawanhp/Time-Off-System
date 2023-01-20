using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Api.Repositories.Interface;

public interface IRepository<Entity, TId> where Entity : class
{
    public IEnumerable<Entity> Get();
    public Entity Get(TId id);
    public int Insert(Entity entity);
    public int Update(Entity entity);
    public int Delete(TId id);

}
