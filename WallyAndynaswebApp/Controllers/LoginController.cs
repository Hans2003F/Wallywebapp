using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WallyAndynaswebApp.Context;
using WallyAndynaswebApp.Models;


namespace WallyAndynaswebApp.Controllers 
{
    public class LoginController : Controller
    {
        private MiContext _miContext;
        public LoginController(MiContext context)
        {
            _miContext = context;
         }
        public IActionResult Index()
        {
            return View();
         }

        [HttpPost]
         public async Task<IActionResult> Login(String email, String password)
         {
                var usuario = await _miContext.Usuarios
                                .Where(x => x.Cuenta == email && x.Contraseña == password)
                              .FirstOrDefaultAsync();
           if (usuario != null)
            {
              await SetUserCookies(usuario);
            return RedirectToAction("Index", "Home");
            }
            else
            {
               TempData["LoginError"] = "Usuario o contraseña incorrecto!";
                return RedirectToAction("Index");
             }
         }

        private async Task SetUserCookies(Usuario usuario)
        {
            var claims = new List<Claim>()
            {
               new Claim(ClaimTypes.Name,usuario! .NombreCompleto! ),
               new Claim(ClaimTypes.Email,usuario!.Cuenta!),
               new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
               new Claim(ClaimTypes.Role, usuario.Rol!.ToString()),
            };
            var claimsIdentity= new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Inicio"); 
        }
    }
 }
    
