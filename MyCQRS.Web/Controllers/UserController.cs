using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using MyCQRS.Commands;
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
        public async Task<ActionResult>  Add(UserViewModel userViewModel)
        {
            await ServiceLocator.Current.CommandBus.SendAsync(new UserAddCommand(Guid.NewGuid(), -1, userViewModel.UserName));

            return View();
        }
    }
}