using NovelV1._2.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NovelV1._2.Controllers
{
    public class HomeController : Controller
    {
        NovelDb context = new NovelDb();
        public ActionResult Index(string id = "")
        {
            // p1.with context entity
            var likeMost = context.DanhGias.GroupBy(p => p.Sach_ma).OrderByDescending(p=>p.Average(x=>x.DanhGia_Sao)).Select(p => p.FirstOrDefault()).Take(3);

            //p2.with linq from sf
            /*  var likeMost = from ele in context.Sach_YeuThich
                group ele by ele.Sach_ma into copy
                orderby copy.Count() descending
                select copy.FirstOrDefault();*/
            var updateWeek = context.NoiDungSaches.Where(p => DbFunctions.DiffDays(p.NoiDungSach_ngayUp, DateTime.Now) <=7).GroupBy(p=>p.Sach_ma).Select(p=>p.FirstOrDefault());
            if (updateWeek.Any())
            {
            ViewBag.updateWeek = updateWeek;
            }
            if (likeMost.Any())
            {
            ViewBag.totalLike = likeMost;
            }
            if (id == "")
            {
                var listSach = context.Saches.ToList();
                return View(listSach);
            }
            else
            {
                return RedirectToAction("Type", "Home", new { id = id });
            }
        }
        public ActionResult topRead()
        {
            var listSach = context.Saches.ToList();
            return View(listSach);
        }
        public ActionResult timSach(string ten)
        {
            var find = (from ele in context.Saches select ele);
            find = (IOrderedQueryable<Sach>)find.Where(p => p.Sach_ten.Contains(ten));
            if (!find.Any())
            {
                ViewBag.check = "";
                return View() ;
            }
            else
            {
                ViewBag.Find = ten;
                ViewBag.check = ten;
                return View(find);
            }
        }
        public ActionResult Type(string id)
        {
            ViewBag.Type = id;

            var find = context.Saches.Where(p => p.TheLoai.TheLoai_ten == id).ToList();
            return View(find);
        }
        public ActionResult Author(string id)
        {
            ViewBag.Author = id;
            var find = context.Saches.Where(p => p.Sach_TacGia == id).ToList();
            return View(find);
        }
        public bool isBuy(int? userId)
        {
            var check = context.ThanhToans.Where(p => p.TaiKhoan_ma == userId).FirstOrDefault();
            if (check != null)
                return true;
            return false;
        }
        public ActionResult Detail(int? id, int? userId)
        {
            var buyed = context.ThanhToans.Where(p => p.Sach_ma == id && p.TaiKhoan_ma == userId).FirstOrDefault();
            if (buyed != null)
            {
                ViewBag.buyed = "wasBuy";
            }
            var rate = (from ele in context.DanhGias where ele.Sach_ma == id select ele).AsEnumerable().Average(p=>p.DanhGia_Sao);
            var totalRater = context.DanhGias.Where(p => p.Sach_ma == id).Count();
            ViewBag.totalRater = totalRater;
            if(rate!=null)
            ViewBag.rating = (int)rate;
            else
            ViewBag.rating = 0;
            var detailBook = context.Saches.Where(p => p.Sach_ma == id).First();
            var totalLike = (from ele in context.Sach_YeuThich where ele.Sach_ma == id select ele).Count();
            ViewBag.TotalLike = totalLike;
            var read = context.NoiDungSaches.FirstOrDefault(p => p.Sach_ma == id);
            if (read != null)
            {
                ViewBag.read = "yes";
            }
            if (userId == null)
            {
                return View(detailBook);
            }
            else
            {
                if (isBuy(userId))
                {
                    ViewBag.isBuy = userId;
                }
                var check = context.Sach_YeuThich.FirstOrDefault(p => p.Sach_ma == id && p.TaiKhoan_ma == userId);
                if (check != null)
                {
                    ViewBag.check = userId;
                }
                return View(detailBook);
            }
        }
        public ActionResult SachYeuThich(int sach, int? user)
        {
                Sach_YeuThich s = new Sach_YeuThich();
                s.Sach_ma = sach;
                s.TaiKhoan_ma = user;
                context.Sach_YeuThich.Add(s);
                context.SaveChanges();
                return RedirectToAction("Detail", "Home", new { id = sach, userId = user });
        }
        public ActionResult BoYeuThich(int sach, int? user)
        {
            var check = context.Sach_YeuThich.Where(p => p.TaiKhoan_ma == user && p.Sach_ma == sach).FirstOrDefault();
            context.Sach_YeuThich.Remove(check);
            context.SaveChanges();
            return RedirectToAction("Detail", "Home", new { id = sach, userId = user });
        }
        public ActionResult listYeuThich(int? userID)
        {
                var list = context.Sach_YeuThich.Where(p => p.TaiKhoan_ma == userID).ToList();
                return View(list);
        }
        public ActionResult Read(int id, int? user, int ep)
        {
            var maxep = context.NoiDungSaches.Where(p => p.Sach_ma == id).Max(p => p.NoiDungSach_Tap);
            var listChapter = context.NoiDungSaches.Where(p=>p.Sach_ma == id).ToList();
            ViewBag.listChapter = listChapter;
            ViewBag.maxEp = maxep;
            ViewBag.scroll = 0;
            foreach(var ele in listChapter)
            {
                
            }
            if (user == null)
            {
                ViewBag.scroll = 0;
            }
            else
            {
                var check = context.LichSu_Doc.Where(p => p.TaiKhoan_ma == user && p.Sach_ma == id).FirstOrDefault();
                if (check != null)
                {
                    var continute = context.NoiDungSaches.Where(p => p.NoiDungSach_ma == check.NoiDungSach_ma).First() ;
                    ViewBag.scroll = check.LichSu_dong;
                    return View(continute);
                }
            }
            var reader = context.Saches.Where(p => p.Sach_ma == id).First();
            var read = context.NoiDungSaches.Where(p => p.Sach_ma == id && p.NoiDungSach_Tap == ep).First();
            reader.Sach_LuotDoc += 1;           
            context.SaveChanges();
            return View(read);
        }

        public ActionResult rating(int id, int user, int rate)
        {
            var check = context.DanhGias.Where(p => p.TaiKhoan_ma == user && p.Sach_ma == id).FirstOrDefault();
            if(check != null)
            {
                check.DanhGia_Sao = rate;
                context.SaveChanges();
            }
            else
            {
            DanhGia rating = new DanhGia();
            rating.Sach_ma = id;
            rating.TaiKhoan_ma = user;
            rating.DanhGia_Sao = rate;
            rating.DanhGia_ngay = DateTime.Now;
            context.DanhGias.Add(rating);
            context.SaveChanges();
            }
            return RedirectToAction("Detail", "Home", new { id = id, userId = user });
        }
        public ActionResult SaveReader(int? id, int user, int ep, string scroll)
        {
            var check = context.LichSu_Doc.Where(p => p.TaiKhoan_ma == user && p.Sach_ma == id).FirstOrDefault();
            if (check!=null)
            {
                check.LichSu_dong = scroll;
                check.NoiDungSach_ma = ep;
                context.SaveChanges();
            }
            else
            {
            LichSu_Doc bl = new LichSu_Doc();
            bl.Sach_ma = id;
            bl.TaiKhoan_ma = user;
            bl.NoiDungSach_ma = ep;
            bl.LichSu_dong = scroll;
            context.LichSu_Doc.Add(bl);
            context.SaveChanges();
            ViewBag.Notification = "lưu thành công";
            }
            return Json(ViewBag.Notification, JsonRequestBehavior.AllowGet);
        }
        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/img/" + file.FileName));
            return "/Content/img/" + file.FileName;
        }
    }
}