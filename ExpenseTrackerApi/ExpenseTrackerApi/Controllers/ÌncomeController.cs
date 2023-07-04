using ExpenseTrackerApi.Data;
using ExpenseTrackerApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackerApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ÌncomeController : ControllerBase
    {
        private readonly ApiContext _context;

        public ÌncomeController(ApiContext context)
        {
            _context = context;
        }

        //Create/Edit
        [HttpPost]
        public JsonResult CreateEdit(Income income)
        {
            if (income.Id == 0)
            {
                _context.Income.Add(income);
            }
            else
            {
                var incomeInDb = _context.Income.Find(income.Id);

                if (incomeInDb == null)
                    return new JsonResult(NotFound());

                incomeInDb = income;
            }

            _context.SaveChanges();

            return new JsonResult(Ok(income));

        }

        // Get
        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.Income.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }

        // Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _context.Income.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            _context.Income.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }

        // Get All
        [HttpGet]
        public JsonResult GetAll(int userId)
        {
            var result = _context.Expenses.Where(x => x.User_Id == userId).ToList();

            return new JsonResult(Ok(result));
        }
    }
}
