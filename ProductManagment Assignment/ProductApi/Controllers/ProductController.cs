using NLog;
using ProductAccessLayer.Interface;
using ProductApi.Authentication;
using ProductModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Authorization = ProductApi.Authentication.Authorization;

namespace ProductApi.Controllers
{
    
    public class ProductController : ApiController
    {
        private readonly IProductManager _productManager;

        private static Logger Product_Logger = LogManager.GetCurrentClassLogger();

        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }
        // GET: api/Product
        [HttpGet]
        [Authorization]
        public HttpResponseMessage GetAllProduct() {
            Product_Logger.Info("GetAllProduct Get Request"); 
            return Request.CreateResponse(HttpStatusCode.OK, _productManager.GetAllProducts());
        }


        [HttpGet]
        [Authorization]
        public HttpResponseMessage GetOneProduct(int id)
        {
            Product_Logger.Info("GetoneProduct Get Request of id: "+id.ToString());
            return Request.CreateResponse(HttpStatusCode.OK, _productManager.GetOneProduct(id));
        }


        // POST: api/Product
        [HttpPost]
        [Authorization]
        public HttpResponseMessage Post([FromBody]Product value)
        {
            if (value != null)
            {
                var l = _productManager.InsertProduct(value);
                if (l == 1)
                {
                    Product_Logger.Info("Post Request");
                    return Request.CreateResponse(HttpStatusCode.OK, "1");
                }
                else
                {
                    Product_Logger.Info("Post Request Failed");
                    return Request.CreateResponse(HttpStatusCode.BadRequest ,"0");
                }
            }
            else
            {
                Product_Logger.Warn("Post Request Failed Due to Null Values");
                return Request.CreateResponse(HttpStatusCode.NotFound, "-1");
            }
        }


        // PUT: api/Product/5
        [HttpPut]
        [Authorization]
        public HttpResponseMessage Put([FromBody]Product value)
        {
            if (value != null)
            {
                var l = _productManager.UpdateProduct(value);
                if (l == 1)
                {
                    Product_Logger.Info("Put Request");
                    return Request.CreateResponse(HttpStatusCode.OK, "1");
                }
                else
                {
                    Product_Logger.Info("Put Request Failed");
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "0");
                }
            }
            else
            {
                Product_Logger.Warn("Post Request Failed Due to Null Value");
                return Request.CreateResponse(HttpStatusCode.NotFound, "-1");
            }
        }

        [HttpDelete]
        [Authorization]
        public HttpResponseMessage Delete(int id)
        {
            if (id != 0)
            {
                var l = _productManager.DeleteProduct(id);
                if (l == 1)
                {
                    Product_Logger.Info("Delete Request");
                    return Request.CreateResponse(HttpStatusCode.OK, "1");
                }
                else
                {
                    Product_Logger.Info("Delete Request Failed");
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "0");
                }
            }
            else
            {
                Product_Logger.Warn("Delete Request Failed Due to Null Value");
                return Request.CreateResponse(HttpStatusCode.NotFound, "-1");
            }
        }

        [HttpDelete]
        [Route("api/Product/RemoveMany/{id}")]
        [Authorization]
        public HttpResponseMessage RemoveMany(string id)
        {
            string [] ids = id.Split(',');
            var l = _productManager.DeleteMany(ids);
            if (l == 1)
            {
                Product_Logger.Info("Delete Many Request");
                return Request.CreateResponse(HttpStatusCode.OK, "1");
                
            }
            else
            {
                Product_Logger.Info("Delete Many Request Failed");
                return Request.CreateResponse(HttpStatusCode.NotFound, "-1");
            }
        }
    }
}
