using DatingApp.DataContext;
using System;

namespace Items.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        //ItemsContext
        #region Context
        DataBaseContext Context { set; get; }
        #endregion

        #region commit changes
        void Commit();
        #endregion
    }
}
