﻿using ASPWebApp.Entities;
using ASPWebApp.Model;
using ASPWebApp.Repository;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ASPWebApp.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthenticationService(IAccountService accountService, IMapper mapper, IConfiguration configuration)
        {
            _accountService = accountService;
            _mapper = mapper;
            _configuration = configuration;
        }

        public Task<string> GenerateToken(AccountDTO account)
        {
            var jwtConfig = _configuration.GetSection("JwtConfig");

            var issuer = jwtConfig["Issuer"];
            var audience = jwtConfig["Audience"];
            var key = Environment.GetEnvironmentVariable("SECRET");
            var expiryIn = DateTime.Now.AddDays(Double.Parse(jwtConfig["ExpireDays"]));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                    new Claim("Id", account.Id.ToString()),
                    new Claim(ClaimTypes.Email, account.Email),
                    new Claim(ClaimTypes.Role, account.Role.ToString())
                }),
                Expires = expiryIn,
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var accessToken = tokenHandler.WriteToken(token);
            return Task.FromResult(accessToken);
        }

        public async Task<AccountDTO> Login(string email, string password)
        {
            try {
                var account = await _accountService.CheckLogin(email, password);
                var model = _mapper.Map<AccountDTO>(account);
                model.AccessToken = await GenerateToken(model);
                return model;
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }          
        }

        public Task<AccountDTO> Register(Account account)
        {
            var newAccount = _accountService.CreateAccountAsync(account);
            return newAccount;
        }
    }
}