using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSistemasCRUDCompleto.Controllers
{
    public class ProdutosController : Controller
    { 
        // GET: /Produtos/
        public IActionResult Index()
        {
            return View();
        }
        // GET: /Produtos/Privacy
        public IActionResult Privacy() {
            return View();
        }
        // GET: /Produtos/Welcome
        public IActionResult Welcome(String name="Lucas", int numTimes = 1)
        {
            ViewData["Mensagem"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;
            return View();
        }
    }
}
