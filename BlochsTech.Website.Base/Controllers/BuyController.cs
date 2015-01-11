using System;
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
        public ActionResult Create(PurchaseOrderViewModel purchaseOrder)
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
                        ZipCode = purchaseOrder.ZipCode
                    };

                    _purchaseOrderService.Create(model);
                    Bootstrap.Log.Info("Client with name {0} and  email: {1}. Save to database.", model.Name, model.Email);

                    MailHelper.SendEmail(model.Name, model.Email, model.Sreet);
                   // Bootstrap.Log.Info("Client with email: {0}. Save to database.", model.Email);
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