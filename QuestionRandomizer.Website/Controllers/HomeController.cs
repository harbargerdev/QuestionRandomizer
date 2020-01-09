using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuestionRandomizer.SharedLibrary;
using QuestionRandomizer.SharedLibrary.Entities;
using QuestionRandomizer.Website.Models;

namespace QuestionRandomizer.Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRandomizer _randomizer;
        private readonly IHostingEnvironment _hostingEnvironment;

        public HomeController(ILogger<HomeController> logger, IHostingEnvironment hostingEnvironment, IRandomizer randomizer)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
            _randomizer = randomizer;

            string contentRootPath = _hostingEnvironment.ContentRootPath;
            var json = System.IO.File.ReadAllText(contentRootPath + "/seedQuestions.json");

            randomizer.SetInitialQuestions(json);
        }

        public IActionResult Index()
        {
            List<Question> questions = _randomizer.RandomizeQuestions(20);
            return View(questions);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
