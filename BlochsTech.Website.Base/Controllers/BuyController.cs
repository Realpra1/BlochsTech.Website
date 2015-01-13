using System;
using System.Configuration;
using System.Web;
using System.Web.Mvc;
using BlochsTech.Website.Base.Helper;
using BlochsTech.Website.Base.ViewModel;
using BlochsTech.Website.Domain.EntityModel;
using BlochsTech.Website.Service.Service;

namespace BlochsTech.Website.Base.Controllers
{
    public class BuyController : Controller
    {
        //initialize service object
        IPurchaseOrderService _purchaseOrderService;

        public BuyController(IPurchaseOrderService purchaseOrderService)
        {
            _purchaseOrderService = purchaseOrderService;
        }

        public ActionResult Index()
        {
            ViewBag.CountryList = CountriesHelper.GetCountries();

            var model = new PurchaseOrderViewModel();

            return View(model);
        }

        //
        // GET: /Buy/
        // POST: /purchaseOrder/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PurchaseOrderViewModel purchaseOrder, string payPalLink)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var model = new PurchaseOrder
                    {
                        Email = purchaseOrder.Email,
                        Apartament = purchaseOrder.Apartament,
                        City = purchaseOrder.City,
                        Country = purchaseOrder.Country,
                        Name = purchaseOrder.Name,
                        Sreet = purchaseOrder.Sreet,
                        State = purchaseOrder.State,
                        ZipCode = purchaseOrder.ZipCode,
                    };

                    string url = "https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_xclick&business=" + HttpUtility.UrlPathEncode(ConfigurationManager.AppSettings["PayPalEmail"] +
                         "&item_name=Simple_Card&first_name=" + purchaseOrder.Name + "&address1=" + purchaseOrder.Sreet + "&address2=" +
                         purchaseOrder.Apartament + " &city=" + purchaseOrder.City + "&state=" + purchaseOrder.State + "&zip=" + purchaseOrder.ZipCode.ToString() + "&country=" + purchaseOrder.Country +
                         "&Simple_card=" + ConfigurationManager.AppSettings["PriceSimpleCard"] + "&currency_code=USD&amount=" + ConfigurationManager.AppSettings["PriceSimpleCard"] + "&email=" + purchaseOrder.Email);

                    MailHelper.SendEmail(model.Name, model.Email, url);
                    Bootstrap.Log.Info("Send email to client {0} and  email: {1}.", model.Name, model.Email);

                    _purchaseOrderService.Create(model);
                    Bootstrap.Log.Info("Client with name {0} and  email: {1}. Save to database.", model.Name, model.Email);

                    Bootstrap.Log.Info("Client with email: {0}. Redirect to {1}", model.Email, url);
                    Response.Redirect(url);
                }
                catch (Exception e)
                {
                    Bootstrap.Log.Error("Error message: {0}\n Stack Trace: {1}", e.Message, e.StackTrace);
                }
                return RedirectToAction("Index");
            }

            ViewBag.CountryList = CountriesHelper.GetCountries();
            return View("Index", purchaseOrder);
        }
    }
}