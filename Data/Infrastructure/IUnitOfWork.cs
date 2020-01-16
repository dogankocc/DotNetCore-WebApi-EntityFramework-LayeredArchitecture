using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
        void SaveChange();
        void RollBack();
    }
}
