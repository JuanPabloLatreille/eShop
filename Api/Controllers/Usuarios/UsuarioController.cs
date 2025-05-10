using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Usuarios;

public class UsuarioController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}