using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Autofac;
using MyCQRS.ApplicationHelper;
using MyCQRS.Commands;
using MyCQRS.Domain.Entities;
using MyCQRS.QueryServices;
using MyCQRS.QueryServices.DTOs;
using MyCQRS.Web.Auxiliary;
using MyCQRS.Web.Models;

namespace MyCQRS.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostQueryServices _postQueryServices;

        public PostController(IPostQueryServices postQueryServices)
        {
            _postQueryServices = postQueryServices;
        }

        public ActionResult Index()
        {
            IEnumerable<PostQueryEntity> postsEntities = _postQueryServices.GetPosts().ToList();

            return View();
        }

        [HttpPost]
        public async Task<ActionResult>  Add(PostViewModel postViewModel)
        {
            Post post = ServiceLocator.Current.Container.Resolve<IMapper>().Map<Post>(postViewModel);

            post.UserId = Guid.NewGuid();

          await  ServiceLocator.Current.CommandBus.SendAsync(new PostAddCommand(post.PostId, -1, post));

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