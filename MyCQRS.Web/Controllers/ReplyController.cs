using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCQRS.Web.Models;

namespace MyCQRS.Web.Controllers
{
    public class ReplyController : Controller
    {
        // GET: Reply
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Add(ReplyViewModel post)
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }
    }
}