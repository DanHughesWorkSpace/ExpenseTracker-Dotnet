using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExpenseTrackerApi.Data;
using ExpenseTrackerApi.Models;

namespace ExpenseTrackerApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly ApiContext _context;

        public ExpensesController(ApiContext context)
        {
            _context = context;
        }

        //Create/Edit
        [HttpPost]
        public JsonResult CreateEdit(Expenses expense)
        {
            if(expense.Id == 0)
            {
                _context.Expenses.Add(expense);
            }
            else
            {
                var expenseInDb = _context.Expenses.Find(expense.Id);

                if (expenseInDb == null)
                    return new JsonResult(NotFound());

                expenseInDb = expense;
            }

            _context.SaveChanges();

            return new JsonResult(Ok(expense));

        }

        // Get
        [HttpGet]
        public JsonResult Get(int id) 
        { 
            var result = _context.Expenses.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }

        // Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _context.Expenses.Find(id);

            if(result == null)
                return new JsonResult(NotFound());

            _context.Expenses.Remove(result);
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
