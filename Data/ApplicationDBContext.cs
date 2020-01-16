using Data.Builders;
using Microsoft.EntityFrameworkCore;
using Model.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DijitalTestApi.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
      

        public DbSet<User> Users { get; set; }

        public DbSet<UserPermission> UserPermissions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)

        {

            base.OnModelCreating(builder);

            new UserBuilder(builder.Entity<User>());

            new UserPermissionBuilder(builder.Entity<UserPermission>());

        }

    }
}
