﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB_BMS.Models;

namespace WEB_BMS.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        QuanLyVatLieuXayDungDataContext data = new QuanLyVatLieuXayDungDataContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Introduce()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult New_NH()
        {
            return View();
        }
        public ActionResult New_TT()
        {
            return View();
        }
        public ActionResult Table_Price()
        {
            return View();
        }
        public ActionResult Product_Index()
        {
            return View();
        }
        public ActionResult Product()
        {
            return View();
        }
    }
}