using Data.Access.EF.Context;
using Data.Access.EF.Repositories.Auth;
using Data.Access.Interfaces;
using Data.Access.Interfaces.Repositories.Auth;

namespace Data.Access.EF
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Auth
        public IUserRepository? _users;
        public IUserRepository Users => _users ??= new UserRepository(_context);
        #endregion

        public int SaveChanges() => _context.SaveChanges();

        public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();
    }
}
