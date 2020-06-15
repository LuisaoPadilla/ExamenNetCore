using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Authentication;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class ProductsController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var handler = new HttpClientHandler()
            {
                SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls
            };
            using (var client = new HttpClient(handler))
            {
                Uri BaseAddress = new Uri("https://localhost:5001/api/");
                client.BaseAddress = BaseAddress;
                client.DefaultRequestHeaders.Accept.Clear();
                HttpResponseMessage response = client.GetAsync("Login").Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsAsync<IEnumerable<Products>>().Result;
                    return View(data);
                }

                return View();

            }
        }
    }
}