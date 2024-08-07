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
            List<HangHoa> ds = data.HangHoas.Where(t => t.TenHangHoa.Contains(text)).ToList();
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
        //Giỏ Hàng
        private ShoppingCart GetCart()
        {
            var cart = Session["Cart"] as ShoppingCart;
            if (cart == null)
            {
                cart = new ShoppingCart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public HangHoa GetProductById(string productId)
        {
            return data.HangHoas.SingleOrDefault(n => n.MaHH == productId);
        }
        // Thêm giỏ hàng
        public ActionResult AddToCart(string productId)
        {
            var cart = GetCart();

            // Lấy thông tin sản phẩm từ cơ sở dữ liệu (ví dụ)
            HangHoa product = GetProductById(productId);
            if (product != null)
            {
                var cartItem = new CardItems
                {
                    MaHH = productId,
                    TenHangHoa = product.TenHangHoa,
                    SoLuongTon = 1,
                    GiaBan = (decimal)product.GiaBan // Chuyển đổi kiểu int sang decimal
                };
                cart.AddItem(cartItem);
            }
            return RedirectToAction("Product_Index");
        }
        // Xóa Giỏ Hàng
        public ActionResult RemoveFromCart(string productId)
        {
            var cart = GetCart();
            cart.RemoveItem(productId); // Giả sử có phương thức RemoveItem trong ShoppingCart
            return RedirectToAction("XemGioHang"); // Chuyển hướng đến trang giỏ hàng hoặc trang khác
        }
        public ActionResult XemGioHang()
        {
            var cart = GetCart();
            return View(cart);
        }
        // Cap Nhat SL
        public ActionResult UpdateCart(string productId, int quantity)
        {
            var cart = GetCart();

            if (quantity <= 0)
            {
                cart.RemoveItem(productId);
            }
            else
            {
                cart.UpdateItemQuantity(productId, quantity); // Giả sử có phương thức UpdateItemQuantity trong ShoppingCart
            }

            return RedirectToAction("XemGioHang"); // Chuyển hướng đến trang giỏ hàng
        }

        public ActionResult XacNhanThongTin()
        {
            KhachHang kh = Session["Khachhang"] as KhachHang;

            if (kh == null)
            {
                return RedirectToAction("DangNhap", "Home");
            }
            List<CardItems> gio = Session["gh"] as List<CardItems>;
            ViewBag.g = gio;
            return View(kh);
        }




        // Xử lý đặt hàng sau khi xác nhận
        [HttpPost]
        //public ActionResult PlaceOrder(Order order)
        //{

        //    if (!string.IsNullOrEmpty(col["txtDate"]))
        //    {
        //        DateTime ngaygiao;
        //        if (DateTime.TryParse(col["txtDate"], out ngaygiao))
        //        {
        //            DonHang hd = new DonHang();
        //            hd.MaKH = kh.MaKH;
        //            hd.NgayDat = DateTime.Now;
        //            hd.NgayGiao = ngaygiao;
        //            data.DonHangs.InsertOnSubmit(hd);
        //            data.SubmitChanges();

        //            foreach (var item in giohang)
        //            {
        //                ChiTietDonHang ct = new ChiTietDonHang();
        //                ct.MaDonHang = hd.MaDonHang;
        //                ct.MaSP = item.masp;
        //                ct.SoLuong = item.soluong;
        //                data.ChiTietDonHangs.InsertOnSubmit(ct);
        //            }

        //            data.SubmitChanges();

        //            giohang.Clear();
        //            ViewBag.tb = "Đặt hàng thành công";
        //            return View();
        //        }
        //        else
        //        {
        //            ViewBag.tb = "Ngày giao không hợp lệ";
        //            return View();
        //        }
        //    }
        //    else
        //    {
        //        ViewBag.tb = "Ngày giao không được để trống";
        //        return View();
        //    }
        //}
        //if (ModelState.IsValid)
        //{
        //    // Lưu đơn hàng vào cơ sở dữ liệu

        //    //_context.Orders.Add(order);
        //    //_context.SaveChanges();
        //    // Xóa giỏ hàng
        //    Session["Cart"] = null;

        //    // Chuyển hướng đến trang xác nhận hoặc cảm ơn
        //    return RedirectToAction("OrderConfirmation");
        //}

        //return View("ConfirmOrder", order);


        // Hiển thị trang xác nhận đơn hàng
        public ActionResult OrderConfirmation()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhapXLThem(FormCollection c)
        {
            string tk = c["txtTen"];
            string mk = c["txtMK"];

            KhachHang kh = data.KhachHangs.SingleOrDefault(t => t.TaiKhoan == tk && t.MatKhau == mk);
            if (kh == null)
            {
                ViewBag.Notification = "Incorrect username or password. Please try again.";
                return RedirectToAction("DangNhap");
            }
            Session["khachhang"] = kh;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult DangXuat()
        {
            Session["Khachhang"] = null;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKyXLThem(KhachHang kh)
        {
            // Retrieve the latest customer ID
            var lastCustomer = data.KhachHangs.OrderByDescending(k => k.MaKH).FirstOrDefault();

            // Initialize new ID
            string newCustomerId;

            if (lastCustomer != null)
            {
                // Extract the numeric part from the last customer ID
                string lastId = lastCustomer.MaKH;
                int numericPart = int.Parse(lastId.Substring(2));

                // Increment the numeric part
                int newNumericPart = numericPart + 1;

                // Format the new ID as "KHXX" where XX is the incremented number with leading zeros if needed
                newCustomerId = $"KH{newNumericPart:D2}";
            }
            else
            {
                // Default to KH01 if there are no existing customers
                newCustomerId = "KH001";
            }

            // Assign the new ID to the customer's MaKH
            kh.MaKH = newCustomerId;
            data.KhachHangs.InsertOnSubmit(kh);
            data.SubmitChanges();
            Session["khachhang"] = kh;
            return RedirectToAction("Index", "Home");
        }
    }
    
}