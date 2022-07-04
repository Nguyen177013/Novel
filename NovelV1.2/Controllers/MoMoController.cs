using Newtonsoft.Json.Linq;
using NovelV1._2.Models.DTO;
using NovelV1._2.Models.MoMo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NovelV1._2.Controllers
{
    public class MoMoController : Controller
    {
        NovelDb context = new NovelDb();
        // GET: MoMo
        public ActionResult Index()
        {
            return View();
        }
        static decimal gia = 0;
        static int sachMa = 0;
        public ActionResult Payment(decimal price,int ma)
        {
            gia = price;
            sachMa = ma;
            string endpoint = ConfigurationManager.AppSettings["endpoint"].ToString();
            string partnerCode = ConfigurationManager.AppSettings["partnerCode"].ToString();
            string accessKey = ConfigurationManager.AppSettings["accessKey"].ToString();
            string serectkey = ConfigurationManager.AppSettings["serectkey"].ToString();
            string orderInfo = "DH" + DateTime.Now.ToString("yyyyMMddHHmmss");
            string returnUrl = ConfigurationManager.AppSettings["returnUrl"].ToString();
            string notifyurl = ConfigurationManager.AppSettings["notifyurl"].ToString(); //lưu ý: notifyurl không được sử dụng localhost, có thể sử dụng ngrok để public localhost trong quá trình test

            string amount = price.ToString();
            string orderid = Guid.NewGuid().ToString();
            string requestId = Guid.NewGuid().ToString();
            string extraData = "";

            //Before sign HMAC SHA256 signature
            string rawHash = "partnerCode=" +
                partnerCode + "&accessKey=" +
                accessKey + "&requestId=" +
                requestId + "&amount=" +
                amount + "&orderId=" +
                orderid + "&orderInfo=" +
                orderInfo + "&returnUrl=" +
                returnUrl + "&notifyUrl=" +
                notifyurl + "&extraData=" +
                extraData;

            MoMoSecurity crypto = new MoMoSecurity();
            //sign signature SHA256
            string signature = crypto.signSHA256(rawHash, serectkey);

            //build body json request
            JObject message = new JObject
            {
                { "partnerCode", partnerCode },
                { "accessKey", accessKey },
                { "requestId", requestId },
                { "amount", amount },
                { "orderId", orderid },
                { "orderInfo", orderInfo },
                { "returnUrl", returnUrl },
                { "notifyUrl", notifyurl },
                { "extraData", extraData },
                { "requestType", "captureMoMoWallet" },
                { "signature", signature }

            };

            string responseFromMomo = PaymentRequest.sendPaymentRequest(endpoint, message.ToString());
            JObject jmessage = JObject.Parse(responseFromMomo);
            return Redirect(jmessage.GetValue("payUrl").ToString());

        }
        [HttpGet]
        public ActionResult ReturnUrl()
        {
            string param = Request.QueryString.ToString().Substring(0, Request.QueryString.ToString().IndexOf("signature") - 1);
            param = Server.UrlDecode(param);
            MoMoSecurity crypto = new MoMoSecurity();
            string serectKey = ConfigurationManager.AppSettings["serectKey"].ToString();
            string signature = crypto.signSHA256(param, serectKey);
            if (signature != Request["signature"].ToString())
            {
                ViewBag.message = "Thong tin request khong hop le";
                return View();
            }
            if (!Request.QueryString["errorCode"].Equals("0"))
            {
                ViewBag.message = "Thanh toán thất bại";
                return View();
            }
            else
            {
                ThanhToan tt = new ThanhToan();
                ctThanhToan ct = new ctThanhToan();
                var a = int.Parse(Session["TaiKhoan_maSS"].ToString());
                var check = context.ThanhToans.Where(p => p.TaiKhoan_ma == a && p.Sach_ma == sachMa).FirstOrDefault();
                if (check == null)
                {
                tt.TaiKhoan_ma = a;
                tt.ThanhToan_ngay = DateTime.Now;
                tt.Sach_ma = sachMa;
                context.ThanhToans.Add(tt);
                context.SaveChanges();
                var detail = context.ThanhToans.Where(p => p.TaiKhoan_ma == a && p.Sach_ma == sachMa).FirstOrDefault();
                ct.ThanhToan_ma = detail.ThanhToan_ma;
                ct.ctThanhToan_tien = gia;
                context.ctThanhToans.Add(ct);
                context.SaveChanges();
                }
            return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public JsonResult NotifyUrl(FormCollection collection, int id)
        {
            string param = "";
            param = "partner_code=" + Request["partner_code"] +
                "&access_key=" + Request["access_key"] +
                "&amount=" + Request["amount"] +
                "&order_id=" + Request["order_id"] +
                "&order_type=" + Request["order_type"] +
                "&transaction_id=" + Request["transaction_id"] +
                "&message=" + Request["message"] +
                "&response_time=" + Request["response_time"] +
                "&status_code=" + Request["status_code"];
            param = Server.UrlDecode(param);
            MoMoSecurity crypto = new MoMoSecurity();
            string serectKey = ConfigurationManager.AppSettings["serectKey"].ToString();
            string signature = crypto.signSHA256(param, serectKey);
            if (signature != Request["signature"].ToString())
            {
                ViewBag.message = "Thong tin request khong hop le";
            }
            string status_code = Request["status_code"].ToString();
            if (status_code != "0")
            {
                ViewBag.message = "Thanh toán thành công";
            }
            else
            {

            }

            return Json("", JsonRequestBehavior.AllowGet);
        }

    }
}