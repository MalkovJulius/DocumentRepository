using DocumentRepository.Models.Dtos;
using DocumentRepository.Models.Entities;
using DocumentRepository.Models.Services;
using DocumentRepository.Models.Services.Abstracts;
using DocumentRepository.Models.Services.EFCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentRepository.Controllers
{
    [Authorize]
    public class AuthenticationController : Controller
    {
        readonly IAccountRep _account = new AccountEF();
        //если использовать фабрику, то тут сделать конструктор с IAccount

        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AuthenticationController(UserManager<IdentityUser> userMan, SignInManager<IdentityUser> signInMan)
        {
            userManager = userMan;
            signInManager = signInMan;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(AccountDto accountDto)
        {
            try
            {
                //TODO: сделать проверку через посторонний сервис для валидации данных а потом уже либо на главную страницу либо сообщение и вернуть на страницу входа
                var account = new Account()
                {
                    Login = accountDto.Login
                };

                var (message, success) = _account.Login(accountDto);
                return View("Home/Index");
            }
            catch
            {
                return View();
            }
        }

        public IActionResult SignOut()
        {
            //TODO: 
            return View("SignIn");
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(AccountDto accountDto)
        {
            try
            {
                //TODO:  сделать не напрямую внос данных а через посторонний методы, дыбы легко менять ORM
                var account = new Account()
                {
                    Login = accountDto.Login
                };

                var (message, success) = _account.AddAccount(accountDto);


                return View("Home/Index");
            }
            catch
            {
                return View();
            }

        }
    }
}
