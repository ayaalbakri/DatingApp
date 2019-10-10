using DatingApp.DataContext;

namespace Items.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(DataBaseContext context)
        {
            Context = context;
        }
        public DataBaseContext Context { set; get; }
        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
