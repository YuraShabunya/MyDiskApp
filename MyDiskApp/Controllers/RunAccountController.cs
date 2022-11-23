using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyDiskApp.Services.Interface;
using MyDiskApp.ViewModels;
using System.Numerics;

namespace MyDiskApp.Controllers
{
    public class RunAccountController : Controller
    {
        private readonly IGetUser _getUser;
        private readonly IRecoverPassword _recoverPassword;
        private readonly ILoggy _loggy;
        public RunAccountController(IGetUser getUser, IRecoverPassword recoverPassword, ILoggy loggy)
        {
            _getUser = getUser;
            _recoverPassword = recoverPassword;
            _loggy = loggy;
        }
        [HttpGet]
        [Authorize]
        public IActionResult FullInformation()
        {
            var user = _getUser.GetUser(User.Identity.Name);
            return View(user);
        }
        [HttpGet]
        public IActionResult RecoverPassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RecoverPassword(RecoverModel recoverModel)
        {
            bool complete = false;
            if (ModelState.IsValid)
            {
                complete = _recoverPassword.ChangePassword(recoverModel);
            }

            if(complete)
            {
                _loggy.AddLogAsync(recoverModel.Login, "Поменял пароль", DateTime.Now);
                ModelState.AddModelError("", "Пароль изменён!");
                return View(recoverModel);
            }
            ModelState.AddModelError("", "Невнрно секретное слово!");
            return View(recoverModel);
        }

    }
}
