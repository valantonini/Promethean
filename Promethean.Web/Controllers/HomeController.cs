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

            var options = new Options() { RandomSeed = new System.Random(System.Guid.NewGuid().GetHashCode()).Next() };
            var generator = new LevelGenerator(options);
            var level = generator.Generate();
            var byteArray = level.Render();

            return Json(new
            {
                width = options.Width,
                height = options.Height,
                level = byteArray
            });
        }
    }
}