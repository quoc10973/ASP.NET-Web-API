using ASPWebApp.Entities;
using ASPWebApp.Model;

namespace ASPWebApp.Repository
{
    public interface IAccountRepository
    {
        public Task AddAsync(Account account);
        public Task DeleteAsync(Account account);
        public Task<IEnumerable<Account>> GetAllAsync();
        public Task<Account> GetByIdAsync(Guid id);
        public Task UpdateAsync(Account account);

        public Task<Account> GetAccountByEmail(string email);

    }
}
