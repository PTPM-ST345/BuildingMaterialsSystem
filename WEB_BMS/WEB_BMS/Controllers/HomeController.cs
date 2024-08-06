using System;
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
            List<HangHoa> dshh = data.HangHoas.ToList();
            return View(dshh);
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
            List<HangHoa> dshh = data.HangHoas.ToList();
            return View(dshh);
        }
        public ActionResult Product_Index()
        {
            List<HangHoa> dshh = data.HangHoas.ToList();
            return View(dshh);
           
        }
        public ActionResult Product(string id)
        {
            HangHoa hh = data.HangHoas.SingleOrDefault(n => n.MaHH == id);
            return View(hh);
        }

        public ActionResult HTDSTheoLoai(string id)
        {
            List<HangHoa> dssp = data.HangHoas.Where(n => n.MaLoai == id).ToList();
            return View("Product_Index", dssp);
        }
    }
}