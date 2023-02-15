using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using System.Diagnostics;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace Linhkiendientu_aspnetmvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public async Task<IActionResult> Index()
        {
            var options = new RestClientOptions("https://localhost:7299")
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/api/categories", RestSharp.Method.Get);
            RestResponse response = await client.ExecuteAsync(request);
            var objects = JArray.Parse(response.ToString());
            var a = "a";
            return View(objects);
        }


        /*        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
                public IActionResult Error()
                {
                    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
                }*/
    }
}