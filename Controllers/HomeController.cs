using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcSQL.Domain;
using MvcSQL.Models;

namespace MvcSQL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ArticlesRepository articlesRepository;

        public HomeController(ArticlesRepository articlesRepository)
        {
            this.articlesRepository = articlesRepository;
        }
        public IActionResult Index()
        {
            var model = articlesRepository.GetArticles();
            return View(model);
        }

        public IActionResult ArticlesEdit(Guid id)
        {
            Article model = id == default ? new Article() : articlesRepository.GetArticlesById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult ArticlesEdit(Article model)
        {
            if (ModelState.IsValid)
            {
                articlesRepository.SaveArticles(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult ArticlesDelete(Guid id)
        {
            articlesRepository.DeleteArticles(new Article{Id = id});
            return RedirectToAction("Index");
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
    }
}
