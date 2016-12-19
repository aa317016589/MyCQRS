using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using MyCQRS.ApplicationHelper;
using MyCQRS.Commands;
using MyCQRS.Domain.Entities;
using MyCQRS.Web.Auxiliary;
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
        public ActionResult Add(PostViewModel postViewModel)
        {
            Post post = ServiceLocator.Current.Container.Resolve<IMapper>().Map<Post>(postViewModel);

            post.UserId= Guid.NewGuid();

            ServiceLocator.Current.CommandBus.Send(new PostAddCommand(post.PostId, -1, post));
 
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
 

        public ActionResult Delete(String id)
        {
            return View();
        }
    }
}