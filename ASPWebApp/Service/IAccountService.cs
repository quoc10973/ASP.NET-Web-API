using ASPWebApp.Entities;
using ASPWebApp.Model;

namespace ASPWebApp.Service
{
    public interface IAccountService
    {
        Task<AccountDTO> CreateAccountAsync(Account account);
        Task<IEnumerable<AccountDTO>> GetAllAccountsAsync();
        Task<AccountDTO> GetAccountByIdAsync(Guid Id);
        Task<AccountDTO> UpdateAccountAsync(Guid Id, Account account);
        Task DeleteAccountAsync(Guid Id);
    }
}
