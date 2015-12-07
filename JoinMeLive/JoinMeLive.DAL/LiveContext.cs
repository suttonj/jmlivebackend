using System.Data.Entity;

using JoinMeLive.DAL.Models;

namespace JoinMeLive.DAL
{
    /// <summary>
    /// join.me Live Database Context
    /// </summary>
    //[DbConfigurationType(typeof(LiveDbConfiguration))]
    public class LiveContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Discussion> Discussions { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<LiveContext>(modelBuilder);
            //Database.SetInitializer(sqliteConnectionInitializer);
        }
    }
}
