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
                width = level.Width,
                height = level.Height,
                level = level.Render()
            });
        }
    }
}