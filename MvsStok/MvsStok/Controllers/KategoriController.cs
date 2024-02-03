﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvsStok.Models.Entity;
using PagedList;
using PagedList.Mvc;


namespace MvsStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvsDbStokEntities db =new MvsDbStokEntities();  
        public ActionResult Index(int sayfa=1)
        {
            // var degerler =db.TBLKATEGORILER.ToList();
            var degerler = db.TBLKATEGORILER.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKategori() 
        {
            return View(); 
        }

        [HttpPost]
        public ActionResult YeniKategori(TBLKATEGORILER p1)
        {
            if(!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.TBLKATEGORILER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SIL (int id)
        {
            var kategori =db.TBLKATEGORILER.Find(id);   
            db.TBLKATEGORILER.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir (int id)
        {
            var ktgr = db.TBLKATEGORILER.Find(id);
            return View("KategoriGetir" ,ktgr);
        }
        public ActionResult Guncelle(TBLKATEGORILER p1)
        {
            var ktg = db.TBLKATEGORILER.Find(p1.KATEGORIID);
            ktg.KATEGORIAD = p1.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction ("Index");
        }
            
    }
}