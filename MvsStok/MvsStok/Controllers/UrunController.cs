using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvsStok.Models.Entity;

namespace MvsStok.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        MvsDbStokEntities db = new MvsDbStokEntities();
        public ActionResult Index()
        {
            var degerler =db.TBLURUNLER.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> degereler =( from i in db.TBLKATEGORILER.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = i.KATEGORIAD,
                                                  Value = i.KATEGORIID.ToString(),
                                              }).ToList();
            ViewBag.dgr=degereler;
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(TBLURUNLER p1)
        {
            var ktg = db.TBLKATEGORILER.Where(m => m.KATEGORIID == p1.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            p1.TBLKATEGORILER = ktg;
            db.TBLURUNLER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult SIL (int id)
        {
            var urun  = db.TBLURUNLER.Find(id);
            db.TBLURUNLER.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("index");

        }
        public ActionResult UrunGetir(int id)
        {
            var urun = db.TBLURUNLER.Find(id);


            List<SelectListItem> degereler = (from i in db.TBLKATEGORILER.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = i.KATEGORIAD,
                                                  Value = i.KATEGORIID.ToString(),
                                              }).ToList();
            ViewBag.dgr = degereler;
            return View("UrunGetir", urun);
        }
        public ActionResult Guncelle(TBLURUNLER p1)
        {
            var urun = db.TBLURUNLER.Find(p1.URUNID);
            urun.URUNID = p1.URUNID;
            urun.FIYAT = p1.FIYAT;
            urun.STOK = p1.STOK;
            urun.URUNAD=p1.URUNAD;
            urun.MARKA=p1.MARKA;
            //  urun.URUNKATEGORI=p1.URUNKATEGORI;
            var ktg = db.TBLKATEGORILER.Where(m => m.KATEGORIID == p1.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
           urun.URUNKATEGORI = ktg.KATEGORIID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}