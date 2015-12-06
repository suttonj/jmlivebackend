using System.Data.Entity;

using JoinMeLive.DAL.Models;

namespace JoinMeLive.DAL
{
    /// <summary>
    /// join.me Live Database Context
    /// </summary>
    [DbConfigurationType(typeof(LiveDbConfiguration))]
    public class LiveContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<Discussion> Topics { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
