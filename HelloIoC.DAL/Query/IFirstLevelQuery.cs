using System.Linq;

namespace HelloIoC.DAL.Query
{
    public interface IFirstLevelQuery<out TEntity>
    {
        IQueryable<TEntity> GetSource(ContactDbContext db);
    }
}