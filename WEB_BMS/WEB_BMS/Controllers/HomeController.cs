﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEB_BMS.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
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
	}
}