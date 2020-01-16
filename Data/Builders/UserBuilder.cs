using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.UserModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Builders
{
    public class UserBuilder
    {
        public UserBuilder(EntityTypeBuilder<User> entityBuilder)
        {
            entityBuilder.HasKey(e => e.Id);
            entityBuilder.Property(e => e.CreateDate).IsRequired();
            entityBuilder.Property(e => e.LastUpdate).IsRequired();
            entityBuilder.Property(e => e.Name).IsRequired().HasMaxLength(200);
        }
    }
}
