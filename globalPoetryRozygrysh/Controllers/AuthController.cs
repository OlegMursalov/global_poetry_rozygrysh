using globalPoetryRozygrysh.Models;
using globalPoetryRozygrysh.Repositories.MySql;
using System.Web.Mvc;

namespace globalPoetryRozygrysh.Controllers
{
    public class AuthController : Controller
    {
        private PersonMySqlRepository _personMySqlRepository;

        public AuthController()
        {
            _personMySqlRepository = new PersonMySqlRepository();
        }

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
                string errMsg;
                if (!_personMySqlRepository.IsExist(vk_id, pass, out errMsg))
                {
                    _personMySqlRepository.Create(vk_id, pass, description, out errMsg);
                }
                return Redirect($"/Poetry/Index?vk_id={vk_id}");
            }
        }
    }
}