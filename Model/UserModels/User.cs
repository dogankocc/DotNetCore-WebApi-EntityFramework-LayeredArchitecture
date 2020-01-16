using Model.UserModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.UserModels
{
    public class User : BaseEntity
    {
        private string name;
        //private UserPermission userPermissions;
        private ICollection<UserPermission> userPermissions;
        public string Name { get => name; set => name = value; }
        public virtual ICollection<UserPermission> UserPermissions { get => userPermissions; set => userPermissions = value; }
        //public virtual UserPermission UserPermissions { get => userPermissions; set => userPermissions = value; }
    }
}
