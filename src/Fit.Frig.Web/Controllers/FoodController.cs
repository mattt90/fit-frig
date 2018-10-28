using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Fit.Frig.Web.Data;
using Fit.Frig.Web.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fit.Frig.Web.Controllers
{
    //TODO: make api!!
    [Authorize]
    [Route("[controller]/[action]")]
    public class FoodController : Controller
    {
        public FoodDbContext FoodDbContext { get; private set; }
    
        public FoodController(FoodDbContext context)
        {
            FoodDbContext = context;
        }

        [HttpGet("{id}")]
        public IActionResult Details(
            [FromRoute]int id,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var foodItem = FoodItems.FirstOrDefault(f => f.Id == id);

            if (foodItem == null)
            {
                return NotFound();
            }

            return View(foodItem);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(
            [FromRoute]int id,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            //do delete

            return RedirectToAction("Index");
        }

        [HttpGet("{id}")]
        public IActionResult Edit(
            [FromRoute]int id,            
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var foodItem = FoodItems.FirstOrDefault(f => f.Id == id);

            if (foodItem == null)
            {
                return NotFound();
            }

            return View(foodItem);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(
            [FromRoute]int id,
            [FromForm]FoodInfo foodInfo,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            //do edit

            return RedirectToAction("Index");
        }

        public IActionResult Index(
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return View(FoodItems);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(
            [FromRoute]int id,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var food = await FoodDbContext.Food.FindAsync(id);
            return Ok(food);
        }

        public IActionResult Add(
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(
            [FromForm] FoodInfo foodInfo,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            await FoodDbContext.Food.AddAsync(new Food(foodInfo), cancellationToken);
            await FoodDbContext.SaveChangesAsync(cancellationToken);

            return RedirectToAction("Index");
        }
        
        public List<Food> FoodItems = new List<Food>{
                new Food { Id = 1, Name = "Pizza" },
                new Food { Id = 2, Name = "Taco" },
                new Food { Id = 3, Name = "Lettuce" }
            };
    }
}