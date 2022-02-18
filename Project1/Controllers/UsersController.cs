using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project1.Models;

namespace Project1.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class UsersController : BaseController
    {
        private readonly IJWTManager jWTManager;
        public UsersController(IJWTManager manager)
        {
            jWTManager = manager;
        }

        [HttpGet]
        public List<string> Get()
        {
            return new List<string> { "admin" };
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public JsonResult Authenticate(Users usersdata)
        {
            var token = jWTManager.Authenticate(usersdata);
            if (token == null)
                return Json(new { status = 401, message = "unauthorized" });
            return Json(new { status = 0, message = "authorized", token = token.Token, refreshToken = token.RefreshToken });
        }
    }
}
