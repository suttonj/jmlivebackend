using System.Data.Entity;
using System.Linq;

using JoinMeLive.DAL.Models;

namespace JoinMeLive.DAL.Extensions
{
    public static class DbSetExtensions
    {
        public static bool IsAttached<T>(this DbSet<T> dbset, T entity) where T : class, IIdsEqual<T>
        {
            return dbset.Local.Any(x => x.IdsEqual(entity));
        }
    }
}
