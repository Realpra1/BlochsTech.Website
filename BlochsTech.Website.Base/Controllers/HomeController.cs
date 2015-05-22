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
        public ActionResult PaypalIpn(FormCollection formVals)
        {
            formVals.Add("cmd", "_notify-validate");

            string response = GetPayPalResponse(formVals);

            if (response == "VERIFIED")
            {
                string transactionId = Request["txn_id"];
                string sAmountPaid = Request["mc_gross"];
                string orderString = Request["custom"];

                //_logger.Info("IPN Verified for order " + orderID);

                //validate the order
                Decimal amountPaid = 0;
                Decimal.TryParse(sAmountPaid, out amountPaid);

                int orderId = 0;
                Int32.TryParse(orderString, out orderId);

                try
                {
                    purchaseOrderService.CompleteOrder(orderId, transactionId);
                }
                catch (Exception ex)
                {
                    Bootstrap.Log.Error(ex);
                }
            }

            return RedirectToAction("Index", "Buy");
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
        public string GetPayPalResponse(FormCollection formVals)
        {
            string paypalUrl = System.Configuration.ConfigurationManager.AppSettings["PayPalLink"];

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(paypalUrl);

            // Set values for the request back
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";

            byte[] param = Request.BinaryRead(Request.ContentLength);
            string strRequest = Encoding.ASCII.GetString(param);

            StringBuilder sb = new StringBuilder();
            sb.Append(strRequest);

            foreach (string key in formVals.Keys)
            {
                sb.AppendFormat("&{0}={1}", key, formVals[key]);
            }
            strRequest += sb.ToString();
            req.ContentLength = strRequest.Length;

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