using System.Web.Mvc;

namespace globalPoetryRozygrysh.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Process(string vk_id, string pass, string description)
        {
            return View();
        }
    }
}