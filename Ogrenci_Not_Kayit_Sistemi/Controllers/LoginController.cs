using Microsoft.AspNetCore.Mvc;
using Ogrenci_Not_Kayit_Sistemi.Context;
using Ogrenci_Not_Kayit_Sistemi.Models;

namespace Ogrenci_Not_Kayit_Sistemi.Controllers
{
    
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

       
        public IActionResult Index()
        {
            return View();
        }

       
        [HttpPost]
        public IActionResult Index(LoginViewModel model)
        {
            
            var kullanici = _context.TblKullanici
                .FirstOrDefault(x => x.KullaniciAd == model.KullaniciAd
                                   && x.Sifre == model.Sifre);

            if (kullanici == null)
            {
                ViewBag.Hata = "Kullanıcı adı veya şifre yanlış!";
                return View();
            }

           
            HttpContext.Session.SetString("KullaniciAd", kullanici.KullaniciAd);
            HttpContext.Session.SetString("Rol", kullanici.Rol);
            HttpContext.Session.SetString("OgrNumara", kullanici.OgrNumara ?? "");

           
            if (kullanici.Rol == "Ogretmen")
                return RedirectToAction("Index", "Ogretmen");
            else
                return RedirectToAction("Index", "Ogrenci");
        }

       
        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); 
            return RedirectToAction("Index");
        }
    }
}
