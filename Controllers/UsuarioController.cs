using Zaguate.Models;
using Microsoft.AspNetCore.Mvc;

namespace Zaguate.Controllers
{
    public class UsuarioController : Controller
    {
        private static List<Usuario> usuarios = null;
        public UsuarioController() {
            usuarios = GetUsuarios();
        }
        public  List<Usuario> GetUsuarios()
        {
            return new List<Usuario>{
                new Usuario{ IdUsuario = 1, Nombre = "Cazuario", Email ="Keli@suHermana.com", Clave = "LaSopaMaggie", Estado = true},

                new Usuario { IdUsuario = 2, Nombre = "Zapato", Email = "elpie@desuHermana.com", Clave = "elzapato", Estado = false}
            };
                
        }
        public IActionResult Index()
        {
            return View(usuarios);
        }
    }
}
