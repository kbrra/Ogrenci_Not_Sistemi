using Microsoft.AspNetCore.Mvc;
using Ogrenci_Not_Kayit_Sistemi.Context;
using Ogrenci_Not_Kayit_Sistemi.Models;

namespace Ogrenci_Not_Kayit_Sistemi.Controllers
{   
    public class OgretmenController : Controller
    {
        private readonly AppDbContext _context;

        public OgretmenController(AppDbContext context)
        {
            _context = context;
        }
      
        private bool YetkiKontrol()
        {
            var rol = HttpContext.Session.GetString("Rol");
            return rol == "Ogretmen";
        }

        
        public IActionResult Index()
        {
            if (!YetkiKontrol())
                return RedirectToAction("Index", "Login");

            var dersler = _context.TblDers.ToList();
            return View(dersler);
        }

        
        public IActionResult Create()
        {
            if (!YetkiKontrol())
                return RedirectToAction("Index", "Login");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Ders ders)
        {
            int sinav = 0;
            int toplam = 0;

            if (ders.Ogrs1.HasValue) { toplam += ders.Ogrs1.Value; sinav++; }
            if (ders.Ogrs2.HasValue) { toplam += ders.Ogrs2.Value; sinav++; }
            if (ders.Ogrs3.HasValue) { toplam += ders.Ogrs3.Value; sinav++; }

            if (sinav == 3)
            {
                ders.Ortalama = Math.Round(toplam / 3m, 2);
                ders.Durum = ders.Ortalama >= 50;
            }
            else
            {
                ders.Ortalama = null;
                ders.Durum = null;
            }

            _context.TblDers.Add(ders);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(short id)
        {
            if (!YetkiKontrol())
                return RedirectToAction("Index", "Login");

            var ders = _context.TblDers.Find(id);
            if (ders == null)
                return RedirectToAction("Index");

            return View(ders);
        }

        [HttpPost]
        public IActionResult Edit(Ders ders)
        {
            if (!YetkiKontrol())
                return RedirectToAction("Index", "Login");

            int sinav = 0;
            int toplam = 0;

            if (ders.Ogrs1.HasValue) { toplam += ders.Ogrs1.Value; sinav++; }
            if (ders.Ogrs2.HasValue) { toplam += ders.Ogrs2.Value; sinav++; }
            if (ders.Ogrs3.HasValue) { toplam += ders.Ogrs3.Value; sinav++; }

            if (sinav == 3)
            {
                ders.Ortalama = Math.Round(toplam / 3m, 2);
                ders.Durum = ders.Ortalama >= 50;
            }
            else
            {
                ders.Ortalama = null;
                ders.Durum = null;
            }

            _context.TblDers.Update(ders);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }



        public IActionResult Delete(short id)
        {
            if (!YetkiKontrol())
                return RedirectToAction("Index", "Login");

            var ders = _context.TblDers.Find(id);
            if (ders != null)
            {
                _context.TblDers.Remove(ders);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult CreateStudent()
        {
            if (!YetkiKontrol())
                return RedirectToAction("Index", "Login");
            return View();
        }

        [HttpPost]
        public IActionResult CreateStudent(Kullanici kullanici)
        {
            if (!YetkiKontrol())
                return RedirectToAction("Index", "Login");

            kullanici.Rol = "Ogrenci"; 

            _context.TblKullanici.Add(kullanici);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
