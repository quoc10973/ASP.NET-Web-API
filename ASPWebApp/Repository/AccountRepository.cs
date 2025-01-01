using ASPWebApp.Entities;
using ASPWebApp.Model;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace ASPWebApp.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BookStoreContext _context;

        public AccountRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Account account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Account account)
        {
            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
        }

        public Task<Account> GetAccountByEmail(string email)
        {
            var account = _context.Accounts.FirstOrDefaultAsync(a => a.Email.Equals(email));
            return account;
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<Account> GetByIdAsync(Guid Id)
        {
            return await _context.Accounts.FindAsync(Id);
        }

        public async Task UpdateAsync(Account account)
        {
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
        }
    }
}
