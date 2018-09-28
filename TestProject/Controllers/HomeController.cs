using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestProject.Models;
using TestProject.Services;

namespace TestProject.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            NewsService newsService = new NewsService();
            NewsData newsData = await newsService.GetNewsListAsync();
            return View(newsData);
        }


        public async Task<IActionResult> NewsList(string redditAfterID, string apiServicePage)
        {
            NewsService newsService = new NewsService();
            NewsData newsData = await newsService.GetNewsListAsync(redditAfterID,  apiServicePage);
            return PartialView("_NewsListPartial", newsData);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
