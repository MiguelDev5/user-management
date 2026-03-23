using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    // Página de Perfil (Solo accesible si está "logueado")
    public IActionResult Profile()
    {
        ViewBag.SessionTimeout = 60;
        return View();
    }
}