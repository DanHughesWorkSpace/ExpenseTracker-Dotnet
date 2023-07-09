using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExpenseTrackerApi.Data;
using ExpenseTrackerApi.Models;

namespace ExpenseTrackerApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ApiContext _context;

        public TransactionController(ApiContext context)
        {
            _context = context;
        }

        //Create/Edit
        [HttpPost]
        public JsonResult CreateEdit(Transaction transaction)
        {
            if (transaction.Id == 0)
            {
                _context.Transactions.Add(transaction);
            }
            else
            {
                var transactionInDb = _context.Transactions.Find(transaction.Id);

                if (transactionInDb == null)
                    return new JsonResult(NotFound());
                else
                {
                    transactionInDb.Id = transaction.Id;
                    transactionInDb.User_Id = transaction.User_Id;
                    transactionInDb.Type = transaction.Type;
                    transactionInDb.Description = transaction.Description;
                    transactionInDb.Amount = transaction.Amount;
                    transactionInDb.Transaction_Category_Id = transaction.Transaction_Category_Id;
                }
                transactionInDb = transaction;
            }

                _context.SaveChanges();

            return new JsonResult(Ok(transaction));

        }

        // Get all Expenses for a User
        [HttpGet]

        public IActionResult GetUserExpenses(int userId)
        {
            var result = _context.Transactions.Where(x => x.User_Id == userId && x.Type == "expense");

            if (!result.Any())
            {
                return NotFound();
            }
            return Ok(result);
        }
            // Get all Income for a User
            [HttpGet]
        public IActionResult GetUserIncome(int userId) 
        { 
            var result = _context.Transactions.Where(x => x.User_Id == userId && x.Type == "income");

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // Delete
        [HttpDelete]
            public JsonResult Delete(int id)
        {
            var result = _context.Transactions.Find(id);

            if(result == null)
                return new JsonResult(NotFound());

            _context.Transactions.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }

        // Get All
        [HttpGet]
        public JsonResult GetAll(int userId) 
        {
            var result = _context.Transactions.Where(x => x.User_Id == userId).ToList();

            return new JsonResult(Ok(result));
        }
    }
}
