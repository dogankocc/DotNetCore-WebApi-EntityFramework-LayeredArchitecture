using DijitalTestApi.Data;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDBContext dbContext;
        private IDbContextTransaction transaction;

        public UnitOfWork(ApplicationDBContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public void BeginTransaction()
        {
            transaction = dbContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            try

            {
                transaction.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void RollBack()
        {
            transaction.Rollback();
        }

        public void SaveChange()
        {
            dbContext.SaveChanges();
        }
    }
}
