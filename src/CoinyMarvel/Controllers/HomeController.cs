using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using RestSharp;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using CoinyMarvel.Models;

namespace CoinyMarvel.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string name)
        {

            var client = new RestClient("http://comicvine.gamespot.com/api/");
            var request = new RestRequest("characters/?api_key=85bcf9ab4e6f07fc814207cd668077b1d32b5a99&format=JSON&limit=5&filter=name:" + name);
            var response = client.Execute(request);
            //JObject jsonResponse = (JObject)JsonConvert.DeserializeObject(response.Content);

            dynamic jsonResponse = JObject.Parse(response.Content);

            List<CharacterInfo> characterList = new List<CharacterInfo>();
            foreach (var result in jsonResponse["results"])
            {
                CharacterInfo characterInfo = new CharacterInfo();
                characterInfo.name = result["name"].ToString();
                characterInfo.deck = result["deck"].ToString();
                try
                {
                    characterInfo.image = result.image["medium_url"].ToString();
                }
                catch (System.InvalidOperationException) { characterInfo.image = "../images/image-not-found.jpg"; };
                characterInfo.fame = result["count_of_issue_appearances"];
            characterList.Add(characterInfo);
            }

            return View("Characters", characterList);

        }
        //GET /Home/Characters
        public IActionResult Characters()
        {
            return View();
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

        public IActionResult Error()
        {
            return View();
        }

        [HttpGet]
        public IActionResult PingPong()
        {
            return View();
        }

       
    }
}

