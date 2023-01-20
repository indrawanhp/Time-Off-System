using Api.Contexts;
using Api.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Api.Repositories;

public class GeneralRepository<Entity, TId> : IRepository<Entity, TId>
    where Entity : class
{
    private MyContext _context;
    private DbSet<Entity> _entity;
    public GeneralRepository(MyContext context)
    {
        _context = context;
        _entity = _context.Set<Entity>();
    }

    public int Delete(TId id)
    {
        var data = _entity.Find(id);
        if (data == null)
        {
            return 0;
        }

        _entity.Remove(data);
        var result = _context.SaveChanges();
        return result;
    }

    public IEnumerable<Entity> Get()
    {
        return _entity.ToList();
    }

    public Entity Get(TId id)
    {
        return _entity.Find(id);
    }

    public int Insert(Entity entity)
    {
        _entity.Add(entity);
        var result = _context.SaveChanges();
        return result;
    }

    public int Update(Entity entity)
    {
        _entity.Entry(entity).State = EntityState.Modified;
        var result = _context.SaveChanges();
        return result;
    }
}
