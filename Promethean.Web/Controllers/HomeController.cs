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

        public IActionResult GetData(int? seed = null)
        {
            seed = seed ?? System.Guid.NewGuid().GetHashCode();
            //seed = 1954860574;
            var options = new Options()
            {
                RandomSeed = new System.Random(seed.Value).Next(),
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