using DocumentRepository.Models.Dtos;
using DocumentRepository.Models.Entities;
using DocumentRepository.Models.Services;
using DocumentRepository.Models.Services.EFCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentRepository.Controllers
{
    public class AuthenticationController : Controller
    {
        readonly IAccountRep _account = new AccountEF();
        //если использовать фабрику, то тут сделать конструктор с IAccount

        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(AccountDto accountDto)
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

        public ActionResult SignOut()
        {
            //TODO: 
            return View("SignIn");
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(AccountDto accountDto)
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
