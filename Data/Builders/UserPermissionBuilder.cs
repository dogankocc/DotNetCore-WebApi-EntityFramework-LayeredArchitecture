using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.UserModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Builders
{
    public class UserPermissionBuilder
    {
        public UserPermissionBuilder(EntityTypeBuilder<UserPermission> entityBuilder)
        {
            entityBuilder.HasKey(e => e.Id);
            entityBuilder.Property(e => e.CreateDate).IsRequired();
            entityBuilder.Property(e => e.LastUpdate).IsRequired();
            entityBuilder.Property(e => e.Type).IsRequired();
            //entityBuilder.HasOne(e => e.User).WithOne(e => e.UserPermissions).HasForeignKey<UserPermission>(key => key.UserId); // one to one example
            entityBuilder.HasOne(e => e.User).WithMany(e => e.UserPermissions).HasForeignKey(key => key.UserId);
        }
    }
}
