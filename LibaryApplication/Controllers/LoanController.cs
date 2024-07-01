using Microsoft.AspNetCore.Mvc;

namespace LibaryApplication.Controllers
{
    public class LoanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
