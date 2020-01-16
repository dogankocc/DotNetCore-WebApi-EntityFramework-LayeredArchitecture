using System;
using System.Collections.Generic;
using System.Text;

namespace Model.UserModels
{
    public class UserPermission : BaseEntity
    {
        private int type;
        private string userId;
        private User user;
       
        public int Type { get => type; set => type = value; }
        public virtual User User { get => user; set => user = value; }
        public string UserId { get => userId; set => userId = value; }
    }
}
