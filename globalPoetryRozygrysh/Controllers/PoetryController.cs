﻿using globalPoetryRozygrysh.Repositories.MySql;
using System.Web.Mvc;

namespace globalPoetryRozygrysh.Controllers
{
    public class PoetryController : Controller
    {
        private TextMySqlRepository _textMySqlRepository;

        public PoetryController()
        {
            _textMySqlRepository = new TextMySqlRepository();
        }

        [HttpGet]
        public ActionResult Index(string vk_id)
        {
            ViewBag.vk_id = vk_id;
            string errMessage = null;
            var texts = _textMySqlRepository.Get(vk_id, out errMessage);
            return View(texts);
        }

        [HttpPost]
        public ActionResult Process(string vk_id, string[] lyrics)
        {
            return null;
        }
    }
}