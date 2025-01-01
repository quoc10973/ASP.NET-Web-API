using ASPWebApp.Entities;
using ASPWebApp.Model;

namespace ASPWebApp.Service
{
    public interface IAuthenticationService
    {
        public Task<AccountDTO> Login(string email, string password);
        public Task<AccountDTO> Register(Account account);

        public Task<string> GenerateToken(AccountDTO account);
    }
}
