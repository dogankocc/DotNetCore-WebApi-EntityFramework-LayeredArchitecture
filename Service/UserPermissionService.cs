using Data.Infrastructure;
using Data.Repositories;
using Model.UserModels;
using System;
using System.Collections.Generic;

namespace Service
    {
        public interface IUserPermissionService
        {
            UserPermission GetUserPermission(long id);

            IEnumerable<UserPermission> GetUserPermissions();

            void CreateUserPermission(UserPermission UserPermission);

            void UpdateUserPermission(UserPermission UserPermission);

            void DeleteUserPermission(long id);

            void SaveUserPermission();

        }

        public class UserPermissionService : IUserPermissionService
        {

            private readonly IUserPermissionRepository UserPermissionRepository;

            private readonly IUnitOfWork unitOfWork;

            public UserPermissionService(IUserPermissionRepository UserPermissionRepository, IUnitOfWork unitOfWork)
            {
                this.UserPermissionRepository = UserPermissionRepository;
                this.unitOfWork = unitOfWork;
            }

            #region IUserPermissionService Members

            public IEnumerable<UserPermission> GetUserPermissions()
            {
                var UserPermissions = UserPermissionRepository.GetAll();
                return UserPermissions;
            }

            public UserPermission GetUserPermission(long id)
            {
                var UserPermission = UserPermissionRepository.GetById(id);
                return UserPermission;
            }

            public void CreateUserPermission(UserPermission UserPermission)
            {
                UserPermissionRepository.Add(UserPermission);
            }

            public void UpdateUserPermission(UserPermission UserPermission)
            {
                UserPermissionRepository.Update(UserPermission);
            }

            public void DeleteUserPermission(long id)
            {
                UserPermissionRepository.Delete(pc => pc.Id == id);
            }

            public void SaveUserPermission()      
            {
                unitOfWork.Commit();
            }

            #endregion

        }
    }


