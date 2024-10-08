﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Identity.Client;
using TunifyPlatform.Models;
using TunifyPlatform.Models.DTO;
using TunifyPlatform.Repositories.Interfaces;

namespace TunifyPlatform.Repositories.Services
{
    public class IdentityAccountService : IAccounts
    {
        private UserManager<ApplicationUser> _userManager;

        //Inject IWT Service 
        private JwtTokenService _jwtTokenService;

        private readonly SignInManager<ApplicationUser> _signInManager;
        public IdentityAccountService(UserManager<ApplicationUser> Manager, SignInManager<ApplicationUser> signInManager,JwtTokenService jwtTokenService)
        {
            _userManager = Manager;
            _signInManager = signInManager;
            _jwtTokenService = jwtTokenService;
        }
        public async Task<AccountDto> Register(RegisterDto registerDto, ModelStateDictionary modleState)
        {
            var user = new ApplicationUser()
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email

            };
            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRolesAsync(user, registerDto.Role);
                return new AccountDto()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Role = await _userManager.GetRolesAsync(user)

                };
            }

            //detect type of error
            foreach (var error in result.Errors)
            {
                var errorCode = error.Code.Contains("password") ? nameof(registerDto) :
                                error.Code.Contains("Email") ? nameof(registerDto) :
                                error.Code.Contains("Username") ? nameof(registerDto) : "";
                modleState.AddModelError(errorCode, error.Description);
            }
            return null;
        }

        public async Task<AccountDto> UserAuthentication(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            bool passValidation = await _userManager.CheckPasswordAsync(user, password);
            if (passValidation)
            {
                return new AccountDto()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    //Retrive Token after validation(LogIn) [Minutes for testing its shoukd be hours]
                    Token = await _jwtTokenService.GenerateToken(user, System.TimeSpan.FromMinutes(8))
                };
            }
            return null;
        }
        public async Task Logout()
        {
            await _signInManager.SignOutAsync();  
        }
    }
}
