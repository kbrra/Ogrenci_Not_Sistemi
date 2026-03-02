using Microsoft.AspNetCore.Mvc;
using Ogrenci_Not_Kayit_Sistemi.Context;

namespace Ogrenci_Not_Kayit_Sistemi.Controllers
{
    public class OgrenciController : Controller
    {
        private readonly AppDbContext _context;

        public OgrenciController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
           
            var rol = HttpContext.Session.GetString("Rol");
            if (string.IsNullOrEmpty(rol))
                return RedirectToAction("Index", "Login");

           
            if (rol != "Ogrenci")
                return RedirectToAction("Index", "Ogretmen");

           
            var ogrNumara = HttpContext.Session.GetString("OgrNumara");

            
            var not = _context.TblDers
                .FirstOrDefault(x => x.OgrNumara == ogrNumara);

            return View(not);
        }
    }
}
