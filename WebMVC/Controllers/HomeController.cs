using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            string url = @"https://localhost:5001/api/Login";
            var resultado = Send<User>(url, user, "POST");
            if (resultado == "OK")
            {
                RedirectToAction("Products", "Index");
            }
            return View(user);
        }

        public string Send<T>(string url, T objectRequest, string method = "POST")
        {
            string result = "";

            try
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(objectRequest);
                var uri = new Uri("url");
                WebRequest request = WebRequest.Create(uri);
                request.Method = method;
                request.PreAuthenticate = true;
                request.ContentType = "application/json;charset=utf-8'";
                request.Timeout = 10000;

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }
                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }

            }
            catch (Exception e)
            {
                result = e.Message;

            }

            return result;
        }
    }
}
