using Microsoft.AspNetCore.Mvc;
using Promethean.Core;

namespace Promethean.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetData()
        {
            var seed = System.Guid.NewGuid().GetHashCode();
            var options = new Options()
            {
                RandomSeed = new System.Random(seed).Next(),
                Border = 2
            };

            var generator = new LevelGenerator(options);
            var level = generator.Generate();

            return Json(new
            {
                seed = seed,
                width = level.GetLength(0),
                height = level.GetLength(1),
                level = level
            });
        }
    }
}