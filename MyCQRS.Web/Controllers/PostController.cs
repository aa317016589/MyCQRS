using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCQRS.Web.Models;

namespace MyCQRS.Web.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(PostViewModel post)
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(PostViewModel post)
        {
            return View();
        }

        public ActionResult Add(String id)
        {
            return View();
        }


        public ActionResult Delete(String id)
        {
            return View();
        }
    }
}