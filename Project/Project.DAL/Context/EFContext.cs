using System;
using System.Collections.Generic;
using System.Text;
using Project.DAL.Entities;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Project.DAL.Context
{
    public class EFContext : IdentityDbContext<ApplicationUser>
    {
        public EFContext() : base("Context", throwIfV1Schema: false) { }
        public EFContext(string connectionString) : base(connectionString) { }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        public static EFContext Create() => new EFContext();
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin>().HasKey(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
            base.OnModelCreating(modelBuilder);
        }
    }
}
