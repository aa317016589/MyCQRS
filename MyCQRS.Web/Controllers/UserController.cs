using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using MyCQRS.Commands;
using MyCQRS.QueryServices;
using MyCQRS.Web.Auxiliary;
using MyCQRS.Web.Models;

namespace MyCQRS.Web.Controllers
{
    public class UserController : Controller
    {
        public IUserQueryServices UserQueryServices;

        public UserController(IUserQueryServices userQueryServices)
        {
            UserQueryServices = userQueryServices;
        }

        // GET: User
        public async Task<ActionResult> Index()
        {
            return View(await UserQueryServices.GetUser());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(UserViewModel userViewModel)
        {
            await ServiceLocator.Current.CommandBus.SendAsync(new UserAddCommand(Guid.NewGuid(), -1, userViewModel.UserName));

            return RedirectToAction("Index");
        }
    }
}