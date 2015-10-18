using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Mvc;
using NLog.Internal;
using BlochsTech.Website.Service.Service;

namespace BlochsTech.Website.Base.Controllers
{
    public class HomeController : Controller
    {
        private IPurchaseOrderService purchaseOrderService;
        public HomeController(IPurchaseOrderService purchaseOrderService)
        {
            this.purchaseOrderService = purchaseOrderService;
        }

        public ActionResult TerminalApps()
        {
            return View();
        }

        public ActionResult Info()
        {
            return View();
        }

        public ActionResult Company()
        {
            return View();
        }

        [HttpPost]
        public JsonResult PaypalIpn(FormCollection formVals)
        {
            foreach (var formVal in formVals.Keys)
            {
                Bootstrap.Log.Info(string.Format("{0}:{1}", formVal, formVals[formVal.ToString()]));
            }
            
            string response = GetPayPalResponse();
            Bootstrap.Log.Info(string.Format("{0}:{1}", "response", response));
            if (response == "VERIFIED")
            {
                string transactionId = formVals["txn_id"];
                string sAmountPaid = formVals["mc_gross"];
                string orderString = formVals["custom"];

                //_logger.Info("IPN Verified for order " + orderID);

                //validate the order
                Decimal amountPaid = 0;
                Decimal.TryParse(sAmountPaid, out amountPaid);

                int orderId = 0;
                Int32.TryParse(orderString, out orderId);

                try
                {
                    purchaseOrderService.CompleteOrder(orderId, transactionId);
                    return Json(true);
                }
                catch (Exception ex)
                {
                    Bootstrap.Log.Error(ex);
                }
            }

            return Json(false);
        }

        public ActionResult Thankyou()
        {
            return View();
        }

        public ActionResult Go()
        {
            return RedirectToAction("Index", "Buy");
        }

        /// <summary>
        /// Utility method for handling PayPal Responses
        /// </summary>
        public string GetPayPalResponse()
        {
            string paypalUrl = System.Configuration.ConfigurationManager.AppSettings["PayPalLink"];
            Bootstrap.Log.Info(string.Format("{0}:{1}", "paypalUrl", paypalUrl));
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(paypalUrl);

            // Set values for the request back
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            byte[] param = Request.BinaryRead(Request.ContentLength);
            string strRequest = Encoding.ASCII.GetString(param);
            strRequest += "&cmd=_notify-validate";
            req.ContentLength = strRequest.Length;
            Bootstrap.Log.Info(string.Format("{0}:{1}", "strRequest", strRequest));
            //for proxy
            //WebProxy proxy = new WebProxy(new Uri("http://urlort#");
            //req.Proxy = proxy;
            //Send the request to PayPal and get the response
            string response = "";
            using (StreamWriter streamOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII))
            {
                streamOut.Write(strRequest);
                streamOut.Close();
                using (StreamReader streamIn = new StreamReader(req.GetResponse().GetResponseStream()))
                {
                    response = streamIn.ReadToEnd();
                }
            }

            return response;
        }
    }
}