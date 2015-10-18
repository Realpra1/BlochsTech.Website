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
    /// <summary>
    ///  Buy controller for purchase item.
    /// </summary>
    public class BuyController : Controller
    {
        //initialize service object
        IPurchaseOrderService _purchaseOrderService;

        /// <summary>
        /// Initializes a new instance of the <see cref="BuyController"/> class.
        /// </summary>
        /// <param name="purchaseOrderService">The purchase order service.</param>
        public BuyController(IPurchaseOrderService purchaseOrderService)
        {
            _purchaseOrderService = purchaseOrderService;
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.CountryList = CountriesHelper.GetCountries();

            var model = new PurchaseOrderViewModel();

            return View(model);
        }

        /// <summary>
        /// Creates the specified purchase order.
        /// </summary>
        /// <param name="purchaseOrder">The purchase order.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(PurchaseOrderViewModel purchaseOrder)
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
                        Status = PurchaseOrderStatus.Initial
                    };

                    string url = ConfigurationManager.AppSettings["PayPalLink"] + "?cmd=_xclick&business=" + HttpUtility.UrlPathEncode(ConfigurationManager.AppSettings["PayPalEmail"] +
                         "&item_name=BlochsTech Bitcoin Card&first_name=" + purchaseOrder.Name + "&address1=" + purchaseOrder.Sreet + "&address2=" +
                         purchaseOrder.Apartament + "&city=" + purchaseOrder.City + "&state=" + purchaseOrder.State + "&zip=" + purchaseOrder.ZipCode.ToString() + "&country=" + purchaseOrder.Country +
                         "&quantity=1&currency_code=EUR&amount=" + ConfigurationManager.AppSettings["PriceSimpleCard"] + "&email=" + purchaseOrder.Email +
                         "&return=" + Url.Action("Thankyou", "Home", null, protocol: Request.Url.Scheme) + "&notify_url=" + Url.Action("PaypalIpn", "Home", null, protocol: Request.Url.Scheme));

                    MailHelper.SendEmail(model.Name, model.Email, url);
                    Bootstrap.Log.Info("Send email to client {0} and  email: {1}.", model.Name, model.Email);

                    model = _purchaseOrderService.Create(model);
                    url += "&custom=" + model.Id;
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