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
                RandomSeed = new System.Random(seed).Next()
            };
            var generator = new LevelGenerator(options);
            var level = generator.Generate();
            var byteArray = level.Render();

            return Json(new
            {
                seed = seed,
                width = options.Width,
                height = options.Height,
                level = byteArray
            });
        }
    }
}