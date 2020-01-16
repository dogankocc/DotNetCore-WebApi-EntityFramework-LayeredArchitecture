using Data.Infrastructure;
using Data.Repositories;
using Model.UserModels;
using System;
using System.Collections.Generic;

namespace Service
{
    public interface IUserService

    {

        User GetUser(long id);

        IEnumerable<User> GetUsers();

        void CreateUser(User User);

        void UpdateUser(User User);

        void DeleteUser(long id);

        void SaveUser();

    }

    public class UserService : IUserService

    {

        private readonly IUserRepository UserRepository;
        //private readonly IRepository<User> repository; //if you want use this then you can make disable IUserRepository and remove like this lines in StartUp.cs: "services.Add(new ServiceDescriptor(typeof(IUserRepository), typeof(UserRepository), ServiceLifetime.Transient));"
        private readonly IUnitOfWork unitOfWork;

        public UserService(/*IRepository<User> repository,*/ IUserRepository UserRepository, IUnitOfWork unitOfWork)
        {

            this.UserRepository = UserRepository;
            //this.repository = repository;
            this.unitOfWork = unitOfWork;

        }

        #region IUserService Members

        public IEnumerable<User> GetUsers()
        {
            var Users = UserRepository.GetAll();
            return Users;
        }

        public User GetUser(long id)
        {
            var User = UserRepository.GetById(id);
            return User;
        }

        public void CreateUser(User User)
        {
            UserRepository.Add(User);
        }

        public void UpdateUser(User User)
        {
            UserRepository.Update(User);
        }

        public void DeleteUser(long id)
        {
            UserRepository.Delete(pc => pc.Id == id);
            unitOfWork.SaveChange();
        }

        public void SaveUser()
        {
            unitOfWork.Commit();
        }
        #endregion
    }
}
