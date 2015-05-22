using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using BlochsTech.Website.Domain.EntityModel;
using BlochsTech.Website.Service.Service;

namespace BlochsTech.Website.Base.Controllers.Api
{
    public class OrderController : ApiController
    {
        [System.Web.Http.HttpGet]
        public PurchaseOrder Index(int id)
        {
            try
            {
                var order = DependencyResolver.Current.GetService<IPurchaseOrderService>().GetById(id);
                if (order == null)
                {
                    var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent(string.Format("No order with ID = {0}", id)),
                        ReasonPhrase = "Order ID Not Found"
                    };
                    throw new HttpResponseException(resp);
                }
                return order;
            }
            catch (Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.Message),
                    ReasonPhrase = ex.Message
                };
                throw new HttpResponseException(resp);
            }
        }
    }
}