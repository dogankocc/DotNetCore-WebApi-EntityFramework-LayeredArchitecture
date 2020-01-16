using Data.Infrastructure;
using DijitalTestApi.Data;
using Model.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    public class UserPermissionRepository : RepositoryBase<UserPermission>, IUserPermissionRepository
    {

        public UserPermissionRepository(ApplicationDBContext dbContext): base(dbContext) { }

        public ICollection<UserPermission> GetUserPermissionsByType(int UserPermissionType)

        {

            var UserPermissions = this.DbContext.UserPermissions.Where(c => c.Type == UserPermissionType).ToList();

            return UserPermissions;

        }

    }

    public interface IUserPermissionRepository : IRepository<UserPermission>

    {

        ICollection<UserPermission> GetUserPermissionsByType(int UserPermissionType);

    }
}
