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
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(UserViewModel userViewModel)
        {
            ServiceLocator.Current.CommandBus.Send(new UserAddCommand(Guid.NewGuid(), -1, userViewModel.UserName));

            return View();
        }
    }
}