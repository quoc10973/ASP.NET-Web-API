using ASPWebApp.Entities;
using ASPWebApp.Model;
using ASPWebApp.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPWebApp.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Policy = "ADMIN")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllAccounts()
        {
            try
            {
                return Ok(await _accountService.GetAllAccountsAsync());
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<ActionResult> GetAccountById(Guid Id)
        {
            try
            {
                return Ok(await _accountService.GetAccountByIdAsync(Id));
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> CreateAccount(Account account)
        {
            try
            {
                return Ok(await _accountService.CreateAccountAsync(account));
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult> UpdateAccount(Guid Id, Account account)
        {
            try
            {
                return Ok(await _accountService.UpdateAccountAsync(Id,account));
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<ActionResult> DeleteAccount(Guid Id)
        {
            try
            {
                await _accountService.DeleteAccountAsync(Id);
                return Ok("Account deleted successfully");
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
