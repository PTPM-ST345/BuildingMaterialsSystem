using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        public ActionResult DangNhap()
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
            List<HangHoa> dshh = data.HangHoas.ToList();
            return View(dshh);
        }
        
        public ActionResult Product_Index(int page = 1)
        {
            // Lấy tất cả sản phẩm
            var products = data.HangHoas.AsQueryable();

            // Lọc sản phẩm theo giá
            
            List<HangHoa> dshh = data.HangHoas.ToList();
            // paging
            int NoOfRecordPerPage = 6;
            int NoOfPages = Convert.ToInt32(Math.Ceiling((Convert.ToDouble(dshh.Count) / Convert.ToDouble(NoOfRecordPerPage))));

            int NoOfRecordToSKip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            
            dshh = dshh.Skip(NoOfRecordToSKip).Take(NoOfRecordPerPage).ToList();
            return View(dshh);
        }
        [HttpPost]
        public ActionResult Product_Index(int page = 1, decimal? minPrice = null, decimal? maxPrice = null, string sortOrder = "asc")
        {
            // Lấy tất cả sản phẩm và chuyển đổi thành IQueryable để có thể thực hiện các thao tác lọc và phân trang
            var products = data.HangHoas.AsQueryable();

            // Lọc sản phẩm theo giá
            if (minPrice.HasValue)
            {
                products = products.Where(p => p.GiaBan >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                products = products.Where(p => p.GiaBan <= maxPrice.Value);
            }

            // Sắp xếp sản phẩm theo giá
            products = sortOrder == "asc" ? products.OrderBy(p => p.GiaBan) : products.OrderByDescending(p => p.GiaBan);

            // Phân trang
            int NoOfRecordPerPage = 6;
            int NoOfPages = Convert.ToInt32(Math.Ceiling((Convert.ToDouble(products.Count()) / Convert.ToDouble(NoOfRecordPerPage))));

            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            ViewBag.MinPrice = minPrice;
            ViewBag.MaxPrice = maxPrice;
            ViewBag.SortOrder = sortOrder;

            var pagedProducts = products.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();

            return View(pagedProducts);
        }
        public ActionResult Product(string id)
        {
            HangHoa hh = data.HangHoas.SingleOrDefault(n => n.MaHH == id);
            var currentProduct = data.HangHoas.SingleOrDefault(p => p.MaHH == id);

            if (currentProduct == null)
            {
                return HttpNotFound();
            }

            // Retrieve similar products excluding the current one
            var similarProducts = data.HangHoas.Where(p => p.MaHH != id).ToList();

            // Pass both the current product and the list of similar products to the view
            ViewBag.lstHH = similarProducts;
            return View(hh);
        }

        public ActionResult HTDSTheoLoai(string id)
        {
            List<HangHoa> dssp = data.HangHoas.Where(n => n.MaLoai == id).ToList();
            return View("Product_Index", dssp);
        }

        public ActionResult Login(string id)
        {
            List<HangHoa> dssp = data.HangHoas.Where(n => n.MaLoai == id).ToList();
            return View("Product_Index", dssp);
        } 
            //Search
            [HttpPost]
        public ActionResult Search(FormCollection c)
        {
            string text = c["id"].ToString();
            List<HangHoa> ds = data.HangHoas.Where(t => t.TenHangHoa.Contains(text) ).ToList();
            if (ds.Count() == 0)
            {
                ViewBag.tb = "Không tồn tại sản phẩm bạn muốn tìm.";
                return View("Product_Index", new List<HangHoa>());
            }
            else
            {
                return View("Product_Index", ds);
            }
        }

    }
}