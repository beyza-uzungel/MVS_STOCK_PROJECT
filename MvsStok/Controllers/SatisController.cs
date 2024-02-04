﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvsStok.Models.Entity;

namespace MvsStok.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        MvsDbStokEntities db = new MvsDbStokEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet ]
        public ActionResult YeniSatis()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(TBLSATISLAR p)
        {
            db.TBLSATISLAR.Add(p);
            db.SaveChanges();
            return View("Index");
        }
    }
}