using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using MyDiskApp.Services.Interface;
using MyDiskEF.Models; // пространство имен UserContext и класса User
using MyDiskApp.ViewModels; // пространство имен моделей RegisterModel и LoginModel
using Microsoft.AspNetCore.Authorization;

namespace MyDiskApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAddUser _addUser;
        private readonly ILogin _login;
        private readonly IUserIsExist _userIsExist;
        private readonly ILoggy _loggy;
        public AccountController(IAddUser addUser, ILogin login, IUserIsExist userIsExist, ILoggy loggy)
        {
            _addUser = addUser;
            _login = login;
            _userIsExist = userIsExist;
            _loggy = loggy;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = _login.Login(model);
                if (user != null)
                {
                    await _loggy.AddLogAsync(user.Login, "Login", DateTime.Now);
                    await AuthenticateAsync(model.Login); // аутентификация

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if (_userIsExist.UserIsExist(model.Login))
                {
                    _addUser.AddUser(model);// добавляем пользователя в бд
                    await _loggy.AddLogAsync(model.Login, "Register", DateTime.Now);
                    await AuthenticateAsync(model.Login); // аутентификация
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Такой пользователь существует!");
                }
            }
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _loggy.AddLogAsync(User.Identity.Name, "Logout", DateTime.Now);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
        private async Task AuthenticateAsync(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie");
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
