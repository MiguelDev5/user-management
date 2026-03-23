using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class AuthController : Controller
{
    private readonly AppDbContext _context;

    public AuthController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult BlockedAccount()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var user = _context.Account
            .FirstOrDefault(u => u.Username == model.Username);

        if (user == null)
        {
            ModelState.AddModelError("Username", "Usuario incorrecto");
            return View(model);
        }

        if (user.IsLocked)
        {
            return RedirectToAction("BlockedAccount", "Auth");
        }

        if (user.PasswordHash != model.Password)
        {
            user.LoginAttempts += 1;   // Sumar 1 intento
            _context.SaveChanges();

            if(user.LoginAttempts >= 5){
                user.IsLocked = true;  // bloquear cuenta
                _context.SaveChanges();
                return RedirectToAction("BlockedAccount", "Auth");
            }

            ModelState.AddModelError("Password", "Contraseña incorrecta");
            return View(model);
        }

        user.LoginAttempts = 0;   // reiniciar intentos a 0
        _context.SaveChanges();

        HttpContext.Session.SetString("User", user.Username);
        HttpContext.Session.SetString("LastActivity", DateTime.UtcNow.ToString());

        return RedirectToAction("Profile", "Account");
    }

    [HttpPost]
    public IActionResult ExtendSession()
    {
        HttpContext.Session.SetString("LastActivity", DateTime.UtcNow.ToString());
        return Ok();
    }

    [HttpPost]
    public IActionResult ExpireSession()
    {
        HttpContext.Session.Clear();
        return Ok();
    }
}