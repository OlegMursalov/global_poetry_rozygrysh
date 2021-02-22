using globalPoetryRozygrysh.Models;
using System.Web.Mvc;

namespace globalPoetryRozygrysh.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public ActionResult Index(AuthPerson authPerson = null)
        {
            return View(authPerson);
        }

        [HttpPost]
        public ActionResult Process(string vk_id, string pass, string description)
        {
            var authPerson = new AuthPerson
            {
                VK_ID = vk_id,
                Pass = pass,
                Description = description
            };

            string tooltipText;
            if (!authPerson.Validate(out tooltipText))
            {
                ViewBag.TooltipText = tooltipText;
                return View("Index", authPerson);
            }
            else
            {
                
            }
        }
    }
}