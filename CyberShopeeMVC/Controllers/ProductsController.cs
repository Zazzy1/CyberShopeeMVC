using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using CyberShopeeMVC.Models;
using System.Net.Http;

namespace CyberShopeeMVC.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            var products = GetProductsFromAPI();
            return View(products);
        }

        private List<Product> GetProductsFromAPI()
        {
            try
            {
                var resultList = new List<Product>();

                //use http client to retrieve data from api
                var client = new HttpClient();
                var getDataTask = client.GetAsync("http://localhost:56292/api/Products")
                    .ContinueWith(response =>
                    {
                        var result = response.Result;
                        if (result.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var readResult = result.Content.ReadAsAsync<List<Product>>();
                            readResult.Wait();
                            //Get the result
                            resultList = readResult.Result;
                        }
                    });
                //wait for the async method to complete
                getDataTask.Wait();

                return resultList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}