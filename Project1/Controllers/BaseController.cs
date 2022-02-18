using Microsoft.AspNetCore.Mvc;
using Project1.Models;

namespace Project1.Controllers
{

    [ApiController]
    public class BaseController : Controller
    {
        protected AppDBContext dbContext => (AppDBContext)HttpContext.RequestServices.GetService(typeof(AppDBContext));

    }
}
