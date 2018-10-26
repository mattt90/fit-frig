using System.Threading;
using System.Threading.Tasks;
using Fit.Frig.Web.Data;
using Fit.Frig.Web.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fit.Frig.Web.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class FoodController : Controller
    {
        public FoodDbContext FoodDbContext { get; private set; }
    
        public FoodController(FoodDbContext context)
        {
            FoodDbContext = context;
        }

        public IActionResult Index(
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return View();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(
            [FromRoute]int id,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var food = await FoodDbContext.Food.FindAsync(id);
            return Ok(food);
        }

        [HttpPost]
        public async Task<IActionResult> Add(
            [FromForm] FoodInfo foodInfo,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            await FoodDbContext.Food.AddAsync(new Food(foodInfo), cancellationToken);
            await FoodDbContext.SaveChangesAsync(cancellationToken);

            return NoContent();
        }
    }
}