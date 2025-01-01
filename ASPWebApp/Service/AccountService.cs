using ASPWebApp.Entities;
using ASPWebApp.Model;
using ASPWebApp.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ASPWebApp.Service
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public AccountService(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }
        public async Task<AccountDTO> CreateAccountAsync(Account account)
        {
            try
            {
                string hashPassword = BCrypt.Net.BCrypt.HashPassword(account.Password);
                account.Password = hashPassword;
                await _accountRepository.AddAsync(account);
                return _mapper.Map<AccountDTO>(account);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<IEnumerable<AccountDTO>> GetAllAccountsAsync()
        {
            var accounts = await _accountRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<AccountDTO>>(accounts);
        }

        public async Task<AccountDTO> GetAccountByIdAsync(Guid Id)
        {
            var account = await _accountRepository.GetByIdAsync(Id);
            return _mapper.Map<AccountDTO>(account);
        }

        public async Task<AccountDTO> UpdateAccountAsync(Guid Id, Account account)
        {
            Account accountToUpdate = await _accountRepository.GetByIdAsync(account.Id);
            if (accountToUpdate == null)
            {
                throw new ArgumentException("Account not found");
            }
            accountToUpdate.Email = account.Email;
            accountToUpdate.Address = account.Address;
            accountToUpdate.FirstName = account.FirstName;
            accountToUpdate.LastName = account.LastName;
            accountToUpdate.Role = account.Role;
            _accountRepository.UpdateAsync(accountToUpdate);
            return _mapper.Map<AccountDTO>(accountToUpdate);
        }

        public async Task DeleteAccountAsync(Guid Id)
        {
            Account accountToDelete = await _accountRepository.GetByIdAsync(Id);
            if (accountToDelete == null)
            {
                throw new ArgumentException("Account not found");
            }
            await _accountRepository.DeleteAsync(accountToDelete);
        }

        public async Task<AccountDTO> CheckLogin(string email, string password)
        {
            var account = await _accountRepository.GetAccountByEmail(email);
            if (account == null)
            {
                throw new ArgumentException("Account not found");
            }
            var isPasswordValid = BCrypt.Net.BCrypt.Verify(password, account.Password);
            if (!isPasswordValid)
            {
                throw new ArgumentException("Invalid password");
            }
            return _mapper.Map<AccountDTO>(account);
        }
    }
}
