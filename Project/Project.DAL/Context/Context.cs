using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using Project.DAL.Entities;

namespace Project.DAL.Context
{
    internal class Context : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Rating> Ratings { get; set; }
    }
}
