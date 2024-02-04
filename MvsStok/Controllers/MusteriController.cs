using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvsStok.Models.Entity;

namespace MvsStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvsDbStokEntities db = new MvsDbStokEntities();
        public ActionResult Index(string p)
        {
            //var degerler = db.TBLMUSTERILER.ToList();
           // return View(degerler);
           var degerler =from d in db.TBLMUSTERILER select d;
            if(!string.IsNullOrEmpty(p))
            {
                degerler=degerler.Where(m=>m.MUSTERIAD.Contains(p));
            }
            return View(degerler.ToList());
        }
 
    [HttpGet]
    public ActionResult YeniMusteri()
    {
        return View();
    }
    [HttpPost]
    public ActionResult YeniMusteri(TBLMUSTERILER p1)
    {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.TBLMUSTERILER.Add(p1);
        db.SaveChanges();
            return View();
        }
    public ActionResult SIL (int id)
        {
            var mus =db.TBLMUSTERILER.Find(id);
            db.TBLMUSTERILER.Remove(mus);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    public ActionResult MusteriGetir (int id)
        {
            var mus = db.TBLMUSTERILER.Find(id);
            return View("MusteriGetir",mus);
        }
        public ActionResult Guncelle(TBLMUSTERILER p1)
        {
            var mus = db.TBLMUSTERILER.Find(p1.MUSTERIID);
            mus.MUSTERIAD = p1.MUSTERIAD;
            mus.MUSTERISOYAD=p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("index");
        }

    }
}