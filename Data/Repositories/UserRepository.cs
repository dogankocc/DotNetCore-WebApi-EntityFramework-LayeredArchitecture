using Data.Infrastructure;
using DijitalTestApi.Data;
using Model.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {

        public UserRepository(ApplicationDBContext dbContext): base(dbContext) { }

        public ICollection<User> GetUsersByName(string userName)

        {

            var users = this.DbContext.Users.Where(c => c.Name == userName).ToList();

            return users;

        }

    }

    public interface IUserRepository : IRepository<User>

    {

        ICollection<User> GetUsersByName(string userName);

    }
}
