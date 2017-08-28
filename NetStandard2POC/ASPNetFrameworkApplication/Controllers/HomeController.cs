using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetStandardClassLibrary.MovieHtmlParser;
using NetStandardClassLibrary.Models;

namespace ASPNetFrameworkApplication.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var htmlParser = new MovieHtmlParser();
            var movies = await htmlParser.RetrieveMoviesOfTheWeek();

            return View(movies);
        }
    }
}
