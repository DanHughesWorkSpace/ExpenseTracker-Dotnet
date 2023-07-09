using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExpenseTrackerApi.Data;
using ExpenseTrackerApi.Models;

namespace ExpenseTrackerApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApiContext _context;

        public CategoryController(ApiContext context)
        {
            _context = context;
        }

        //Create/Edit
        [HttpPost]
        public JsonResult CreateEdit(Category category)
        {
            if (category.Id == 0)
            {
                _context.Categories.Add(category);
            }
            else
            {
                var categoryInDb = _context.Categories.Find(category.Id);

                if (categoryInDb == null)
                    return new JsonResult(NotFound());
                else
                {
                    categoryInDb.Id = categoryInDb.Id;
                    categoryInDb.Type = categoryInDb.Type;
                    categoryInDb.Name = categoryInDb.Name;
                    categoryInDb.Description = categoryInDb.Description;
                    categoryInDb.Created_Date = categoryInDb.Description;
                }
                categoryInDb = category;
            }

            _context.SaveChanges();

            return new JsonResult(Ok(category));

        }

        // Get
        [HttpGet]
        public IActionResult Get(int id)
        {
            var result = _context.Categories.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }

        // Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _context.Categories.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            _context.Categories.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }

        // Get All
        [HttpGet]
        public JsonResult GetAll(int userId)
        {
            var result = _context.Categories.Where(x => x.Created_By == userId).ToList();

            return new JsonResult(Ok(result));
        }
    }
}
