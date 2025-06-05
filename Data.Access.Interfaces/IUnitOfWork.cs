using Data.Access.Interfaces.Repositories.Auth;

namespace Data.Access.Interfaces
{
    public interface IUnitOfWork
    {
        #region Auth
           IUserRepository Users { get; }
        #endregion

        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
