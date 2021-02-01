using CheapShark.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CheapShark.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _config;

        public HomeController(IConfiguration config)
        {
            _config = config;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(string q)
        {
            var rapidApiKey = _config["RapidApiKey"];
            List<Games> gamesInfo = new List<Games>();
            string Baseurl = "https://localhost:44326/";
            var gamesResponse = "";
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("x-rapidapi-key", rapidApiKey);
                client.DefaultRequestHeaders.Add("x-rapidapi-host", "cheapshark-game-deals.p.rapidapi.com");
                //Sending request to find web api REST service resource using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("https://cheapshark-game-deals.p.rapidapi.com/games?limit=60&title=" + q + "&exact=0");
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    gamesResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Model
                    gamesInfo = JsonConvert.DeserializeObject<List<Games>>(gamesResponse);
                }
            }
            return View(gamesInfo);
        }

        
        public async Task<IActionResult> GameDetails(string gameId)
        {
            var rapidApiKey = _config["RapidApiKey"];
            GameDetails gamesInfo = new GameDetails();
            string Baseurl = "https://localhost:44326/";
            var gamesResponse = "";
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("x-rapidapi-key", rapidApiKey);
                client.DefaultRequestHeaders.Add("x-rapidapi-host", "cheapshark-game-deals.p.rapidapi.com");
                //Sending request to find web api REST service resource using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("https://cheapshark-game-deals.p.rapidapi.com/games?id=" + gameId);
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    gamesResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Model
                    gamesInfo = JsonConvert.DeserializeObject<GameDetails>(gamesResponse);
                }
            }
            return View(gamesInfo);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
