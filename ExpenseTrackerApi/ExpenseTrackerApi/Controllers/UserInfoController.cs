using ExpenseTrackerApi.Data;
using ExpenseTrackerApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackerApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly ApiContext _context;

        public UserInfoController(ApiContext context)
        {
            _context = context;
        }

        //Create/Edit
        [HttpPost]
        public JsonResult CreateEdit(UserInfo user)
        {
            if (user.Id == 0)
            {
                _context.UserInfo.Add(user);
            }
            else
            {
                var userInfoInDb = _context.UserInfo.Find(user.Id);

                if (userInfoInDb == null)
                    return new JsonResult(NotFound());
                else
                {
                    userInfoInDb.Id = user.Id;
                    userInfoInDb.Name = user.Name;
                    userInfoInDb.Email = user.Email;
                }
                userInfoInDb = user;
            }

            _context.SaveChanges();

            return new JsonResult(Ok(user));

        }

        // Get
        [HttpGet]
        public IActionResult Get(int id)
        {
            var result = _context.UserInfo.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }

        // Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _context.UserInfo.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            _context.UserInfo.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }

        // Get All
        [HttpGet]
        public JsonResult GetAll()
        {
            var result = _context.UserInfo.ToList();

            return new JsonResult(Ok(result));
        }
    }
}
