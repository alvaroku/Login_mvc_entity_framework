using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Login_mvc_entity_framework.Controllers
{
    //[Authorize(Roles = "Manager")]
    [Authorize]
    public class SecretoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
