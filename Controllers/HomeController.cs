using DocumentRepository.Models;
using DocumentRepository.Models.Services;
using DocumentRepository.Models.Services.EFCore;
using DocumentRepository.Models.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentRepository.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        //Переименовать в РЕЕСТР ДОКУМЕНТОВ
        public IActionResult Index()
        {
            //TODO: сделать нормально через права
            var registred = true;
            if (registred)
            {
                return View("Authoritation/SignIn");//над этим надо подумать - надо ли вообще
            }

            return View(_document.GetDocuments(1));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        readonly IDocumentRep _document = new DocumentEF();
        //если использовать фабрику, то тут сделать конструктор с IDocument


        [HttpGet]
        public ActionResult AddFile()
        {
            return View();//Open view for add new document
        }

        [HttpPost]
        public string AddFile(List<byte> file)//may need to use A DTO
        {
            //TODO: something
            try
            {
                _document.AddDocument(file);
                return "Документ добавлен";
            }
            catch
            {
                return "Произошла ошибка";
            }
        }

        [HttpPost]
        public string DeleteFile(int id)
        {
            //TODO: something
            try
            {
                _document.DeletDocument(id);
                return "Документ удалён";
            }
            catch
            {
                return "Произошла ошибка";
            }
        }

        [HttpGet]
        public List<byte> OpenFile(int id)
        {
            try
            {
                return _document.GetDocument(id);
            }
            catch
            {
                throw new Exception("Something wrong");
            }
        }

        [HttpGet]
        public ActionResult GetCurrentDocuments(int id, string text)
        {
            return View(_document.GetCurrentDocuments(id, text));
        }
    }
}
