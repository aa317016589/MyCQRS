﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<ActionResult> Index()
        {
            IEnumerable<PostQueryEntity> postsEntities = await _postQueryServices.GetPosts();

            return View(postsEntities);
        }

        [HttpPost]
        public async Task<ActionResult> Create(PostViewModel postViewModel)
        {
            Post post = ServiceLocator.Current.Container.Resolve<IMapper>().Map<Post>(postViewModel);
 
            await ServiceLocator.Current.CommandBus.SendAsync(new PostAddCommand(post.PostId, -1, post));

            return RedirectToAction("Index");
        }

        public ActionResult Create()
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