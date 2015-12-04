using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JoinMeLive.DAL.Models;

namespace JoinMeLive.DAL
{
    /// <summary>
    /// join.me Live Database Context
    /// </summary>
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
