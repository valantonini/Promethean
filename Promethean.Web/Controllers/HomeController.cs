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
                //RandomSeed = new System.Random(seed.Value).Next(),
                RandomSeed = 1863346693,
                Border = 2,
                OverlapRooms = false,
                NumberOfRooms = 45,
                //RoomBorder = 2,
                // MinRoomHeight = 3,
                // MinRoomWidth = 3,
                // MaxRoomWidth = 5,
                // MaxRoomHeight = 5
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