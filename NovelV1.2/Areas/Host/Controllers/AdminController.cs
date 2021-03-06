using NovelV1._2.Models.DTO;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NovelV1._2.Areas.Host.Controllers
{
    public class AdminController : Controller
    {
        NovelDb context = new NovelDb();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult listSach(int? page)
        {
            if (page == null)
                page = 1;
            var listSach = context.Saches.ToList();
            int pageSize = 4;
            int pageNum = page ?? 1;
            return View(listSach.ToPagedList(pageNum, pageSize));
        }
        public ActionResult listTheLoai()
        {
            var listTheLoai = context.TheLoais.ToList();
            return View(listTheLoai);
        }
        public ActionResult Edit_TheLoai(int id)
        {
            var sach = context.TheLoais.First(m => m.TheLoai_ma == id);
            return View(sach);
        }
        [HttpPost]
        public ActionResult Edit_TheLoai(int id, FormCollection collection)
        {
            var s = context.TheLoais.First(m => m.TheLoai_ma == id);
            var tenLoai = collection["TheLoai_ten"];
            s.TheLoai_ma = id;
            if (string.IsNullOrEmpty(tenLoai))
                ViewData["Error"] = "Không Được Để Trống!!";
            else
            {

                s.TheLoai_ten = tenLoai;
                UpdateModel(s);
                context.SaveChanges();
                return RedirectToAction("listSach");
            }
            return this.Edit_TheLoai(id);
        }

        public ActionResult Detail_Sach(int id)
        {
            var book = context.NoiDungSaches.Where(p => p.Sach_ma == id).ToList();
            if(book == null || !book.Any())
            {
                ViewBag.empty = "";
            }
            return View(book);
        }
        public ActionResult Edit_Sach(int id)
        {
            var listLoai = context.TheLoais.ToList();
            ViewBag.theloai = new SelectList(listLoai, "TheLoai_ma", "TheLoai_ten");
            var sach = context.Saches.First(m => m.Sach_ma == id);
            return View(sach);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit_Sach(int id, FormCollection collection)
        {
            var s = context.Saches.First(m => m.Sach_ma == id);
            var loaiSach = collection["type"];
            var tenSach = collection["Sach_ten"];
            var tacGia = collection["Sach_TacGia"];
            var gia = collection["Sach_gia"];
            var ngaySanXuat = collection["Sach_ngaySanXuat"];
            var tinhTrang = collection["Sach_TinhTrang"];
            var hinh = collection["Sach_anh"];
            var tomTat = collection["Sach_TomTat"];
            s.Sach_ma = id;
            if (string.IsNullOrEmpty(tenSach) || string.IsNullOrEmpty(ngaySanXuat))
                ViewData["Error"] = "Không Được Để Trống!!";
            else
            {
                decimal check = 0;
                if (!decimal.TryParse(gia, out check))
                {
                    ViewBag.Notification = "Vui Lòng Nhập Đúng Giá";
                }
                s.TheLoai_ma = int.Parse(loaiSach);
                s.Sach_ten = tenSach;
                s.Sach_TacGia = tacGia;
                s.Sach_anh = hinh;
                s.Sach_gia = decimal.Parse(gia);
                s.Sach_ngaySanXuat = DateTime.Parse(ngaySanXuat);
                s.Sach_TinhTrang = bool.Parse(tinhTrang);
                s.Sach_TomTat = tomTat;
                UpdateModel(s);
                context.SaveChanges();
                return RedirectToAction("listSach");
            }
            return this.Edit_Sach(id);
        }

        public ActionResult Edit_noiDung(int id, int ep)
        {
            var sach = context.NoiDungSaches.First(m => m.Sach_ma == id && m.NoiDungSach_Tap == ep);
            return View(sach);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit_noiDung(int id, int ep, FormCollection collection)
        {
            var s = context.NoiDungSaches.First(m => m.Sach_ma == id && m.NoiDungSach_Tap == ep);
            var NoiDung = collection["NoiDungSach_NoiDung"];

            s.Sach_ma = id;
            s.NoiDungSach_Tap = ep;
            if (string.IsNullOrEmpty(NoiDung))
                ViewData["Error"] = "Không Được Để Trống!!";
            else
            {
                s.NoiDungSach_NoiDung = NoiDung;
                s.NoiDungSach_ngayUp = DateTime.Now;
                UpdateModel(s);
                context.SaveChanges();
                return RedirectToAction("listSach");
            }
            return this.Edit_noiDung(id, ep);
        }
        public ActionResult Create_Sach()
        {
            var listLoai = context.TheLoais.ToList();
            ViewBag.theloai = new SelectList(listLoai, "TheLoai_ma", "TheLoai_ten");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create_Sach(FormCollection collection, Sach s)
        {
            var loaiSach = collection["type"];
            var tenSach = collection["Sach_ten"];
            var tacGia = collection["Sach_TacGia"];
            var ngaySanXuat = collection["Sach_ngaySanXuat"];
            var tinhTrang = collection["Sach_TinhTrang"];
            var gia = collection["Sach_gia"];
            var hinh = collection["Sach_anh"];
            var tomTat = collection["Sach_TomTat"];
            if (string.IsNullOrEmpty(tenSach)) ViewData["Error"] = "Không Được Để Trống!!";
            else
            {
                decimal check = 0;
                if (!decimal.TryParse(gia, out check))
                {
                    ViewBag.Notification = "Vui Lòng Nhập Đúng Giá";
                }
                else
                {
                    s.TheLoai_ma = int.Parse(loaiSach);
                    s.Sach_ten = tenSach;
                    s.Sach_TacGia = tacGia;
                    s.Sach_anh = hinh;
                    s.Sach_ngaySanXuat = DateTime.Parse(ngaySanXuat);
                    s.Sach_TinhTrang = bool.Parse(tinhTrang);
                    s.Sach_gia = decimal.Parse(gia);
                    s.Sach_LuotDoc = 0;
                    s.Sach_TomTat = tomTat;
                    context.Saches.Add(s);
                    context.SaveChanges();
                    return RedirectToAction("listSach");
                }
            }
            return this.Create_Sach();
        }

        public ActionResult Create_TheLoai()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create_TheLoai(FormCollection collection, TheLoai tl)
        {
            var tenLoai = collection["TheLoai_ten"];
            if (string.IsNullOrEmpty(tenLoai)) ViewData["Error"] = "Không Được Để Trống!!";
            else
            {
                tl.TheLoai_ten = tenLoai;
                context.TheLoais.Add(tl);
                context.SaveChanges();
                return RedirectToAction("listSach");
            }
            return this.Create_TheLoai();
        }

        public ActionResult Delete_Sach(int id)
        {
            var sach = context.Saches.Where(p => p.Sach_ma == id).First();
            var sach_YeuThich = context.Sach_YeuThich.Where(p => p.Sach_ma == id).ToList();
            var sach_NoiDung = context.NoiDungSaches.Where(p => p.Sach_ma == id).ToList();
            var sach_DanhGia = context.DanhGias.Where(p => p.Sach_ma == id).ToList();
            var TT = context.ThanhToans.Where(p=>p.Sach_ma==id).ToList();
            foreach(var ele in TT)
            {
                var CT = context.ctThanhToans.Where(p=>p.ThanhToan_ma==ele.ThanhToan_ma).ToList();
                foreach(var ele2 in CT)
                {
                    if (ele2 != null)
                    {
                        context.ctThanhToans.Remove(ele2);
                    }
                }
                context.ThanhToans.Remove(ele); 
            }
            foreach (var ele in sach_YeuThich)
            {
                if (ele != null)
                {
                    context.Sach_YeuThich.Remove(ele);
                }
            }
            foreach(NovelV1._2.Models.DTO.DanhGia ele in sach_DanhGia)
            {
                if (ele != null)
                {
                    context.DanhGias.Remove(ele);
                }
            }
            foreach (var ele in sach_NoiDung)
            {
                if (ele != null)
                {
                    context.NoiDungSaches.Remove(ele);
                }
            }
            context.Saches.Remove(sach);
            context.SaveChanges();
            return RedirectToAction("listSach");
        }
        public ActionResult Create_NoiDung(int id)
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create_NoiDung(int id, FormCollection collection, NoiDungSach nd)
        {
            var ep = 1;
            var prevEp = context.NoiDungSaches.Where(p=>p.Sach_ma == id).OrderByDescending(p => p.NoiDungSach_Tap).FirstOrDefault();
            if(prevEp != null)
            {
                ep = prevEp.NoiDungSach_Tap+1;
            }
            var maSach = id;
            var NoiDung = collection["NoiDungSach_NoiDung"];
            if (string.IsNullOrEmpty(NoiDung)) ViewData["Error"] = "Không Được Để Trống!!";
            else
            {
                nd.Sach_ma = maSach;
                nd.NoiDungSach_Tap = ep;
                nd.NoiDungSach_ngayUp = DateTime.Now;
                context.NoiDungSaches.Add(nd);
                context.SaveChanges();
                return RedirectToAction("listSach");
            }
            return this.Create_NoiDung(id);
        }
        public ActionResult DashBoard()
        {
            var hoaDon = context.ThanhToans.ToList();
            return View(hoaDon);
        }
        public ActionResult getTotal(int year,int? month)
        {
            if (month == null)
            {
            var hoaDon = from ele in context.ctThanhToans
                         where ele.ThanhToan.ThanhToan_ngay.Year == year
                         group ele by new {Thang = ele.ThanhToan.ThanhToan_ngay.Month} into d
                         select new {Thang = d.Key.Thang, Tong = d.Sum(p=>p.ctThanhToan_tien)};
            return new JsonResult() { Data = hoaDon, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            else
            {
                var hoaDon = from ele in context.ctThanhToans
                             where ele.ThanhToan.ThanhToan_ngay.Year == year && ele.ThanhToan.ThanhToan_ngay.Month == month
                             group ele by new { Ngay = ele.ThanhToan.ThanhToan_ngay.Day } into d
                             select new { Ngay = d.Key.Ngay,Thang = "", Tong = d.Sum(p => p.ctThanhToan_tien) };
                return new JsonResult() { Data = hoaDon, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
    }
}