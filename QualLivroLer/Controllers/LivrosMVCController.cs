using MongoDB.Bson;
using QualLivroLer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using QualLivroLer.Controllers.API;
using System.Web.Mvc;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace QualLivroLer.Controllers
{
    public class LivrosMVCController : Controller
     {
         private readonly LivrosController _apiController;
         public LivrosMVCController()
         {
             _apiController = new LivrosController();
         }
         public async Task<ActionResult> Index()
         {
             var lista = await _apiController.Get();
             return View(lista);
         }
         [HttpPost]
         public async Task<ActionResult> Create(Livros livro)
         {
             try
             {
                  _apiController.Post(livro);
                 return RedirectToAction("Index");
             }
             catch
             {
                 return View();
             }
         }
         public ActionResult Edit(string _id)
         {
             var dados = _apiController.Get(_id);
             ViewBag.MongoId = dados._id;
             return View(dados);
         }
         [HttpPost]
         public ActionResult Edit(string _id, Livros livro)
         {
            livro._id = new ObjectId(_id);
             try
             {
                 _apiController.Put(_id, livro);
                 return RedirectToAction("Index");
             }
             catch
             {
                 return View();
             }
         }
         [HttpPost]
         public ActionResult Delete(string _id, Livros l)
         {
             var dados = _apiController.Get(_id);
             var MongoIdConv = dados._id;
             try
             {
                 _apiController.Delete(new ObjectId(_id));
                 return RedirectToAction("Index");
             }
             catch
             {
                 return View();
             }
         }
     }
}