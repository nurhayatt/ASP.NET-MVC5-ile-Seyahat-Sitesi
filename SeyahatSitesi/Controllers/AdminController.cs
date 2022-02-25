using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeyahatSitesi.Models.Siniflar;

namespace SeyahatSitesi.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniBlog()
        {//sayfanın boş halini döndür.
            return View(); //httpgette çalışıyor sayfayı geri döndürüyor
        }
        [HttpPost]
        public ActionResult YeniBlog(Blog p)
        { //sayfaya bir şeyler gönderdiğinde burada döndür.
            c.Blogs.Add(p);
            c.SaveChanges(); //değişiklikleri kaydet
            return RedirectToAction("Index");
        }
        public ActionResult BlogSil(int id)
        {
            var b = c.Blogs.Find(id); //gönderilen id ye göre değerleri bul
            c.Blogs.Remove(b);//b den gelen değerleri listeden kaldır
            c.SaveChanges();//değişikleri kaydet
            return RedirectToAction("Index");//indexe yönlendir
        }
   public ActionResult BlogGetir(int id)
        {
            var bl = c.Blogs.Find(id);//id ye göre bul
            return View("BlogGetir", bl);//sayfayı döndür bl den geln değerleri de döndür

        }
        public ActionResult BlogGuncelle(Blog b)
        {
            var blg = c.Blogs.Find(b.ID);
            blg.Aciklama = b.Aciklama;
            blg.Baslik = b.Baslik;
            blg.BlogImage = b.BlogImage;
            blg.Tarih = b.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YorumListesi()
        {
            var yorumlar = c.Yorumlars.ToList();
            return View(yorumlar);
        }
        public ActionResult YorumSil(int id)
        {
            var b = c.Yorumlars.Find(id); //gönderilen id ye göre değerleri bul
            c.Yorumlars.Remove(b);//b den gelen değerleri listeden kaldır
            c.SaveChanges();//değişikleri kaydet
            return RedirectToAction("YorumListesi");//indexe yönlendir
        }
        public ActionResult YorumGetir(int id)
        {
            var yrm = c.Yorumlars.Find(id);
            return View("YorumGetir", yrm);

        }
        public ActionResult YorumGuncelle(Yorumlar y)
        {
            var yr = c.Yorumlars.Find(y.ID);
            yr.KulalniciAdi = y.KulalniciAdi;
            yr.Mail = y.Mail;
            yr.Yorum = y.Yorum;
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
    }
}