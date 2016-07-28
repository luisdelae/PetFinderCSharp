using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using PetFinder.Models;
using Newtonsoft.Json;

namespace PetFinder.Controllers
{
    public class RandomAnimalController : Controller
    {
        //// GET: RandomAnimal
        //public ActionResult Index()
        //{
        //    RunAsync().Wait();
        //    return View();
        //}

        HttpClient client;
        //The URL of the WEB API Service
        string url = "http://api.petfinder.com/pet.getRandom?key=8c5651bb1f65ed3b8e5163969b917f60&animal=&output=basic&format=json";
        //string url = "https://jsonplaceholder.typicode.com/posts/1";


        //The HttpClient Class, this will be used for performing 
        //HTTP Operations, GET, POST, PUT, DELETE
        //Set the base address and the Header Formatter
        public RandomAnimalController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: EmployeeInfo
        public async Task<ActionResult> Index()
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var RandomAnimal = JsonConvert.DeserializeObject(responseData);

                return View(RandomAnimal);
            }
            return View("Error");
        }

        //static async Task RunAsync()
        //{
        //    using (var client = new HttpClient())
        //    {
        //        //client.BaseAddress = new Uri("http://api.petfinder.com/pet.getRandom?key=8c5651bb1f65ed3b8e5163969b917f60&animal=&output=basic&format=json&callback=?");
        //        client.BaseAddress = new Uri("http://jsonplaceholder.typicode.com/");
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //        // HTTP GET
        //        try
        //        {
        //            HttpResponseMessage response = await client.GetAsync("/posts/1");
        //            response.EnsureSuccessStatusCode();
        //            if (response.IsSuccessStatusCode)
        //            {
        //                RandomAnimalModel randomAnimal = await response.Content.ReadAsAsync<RandomAnimalModel>();
        //                Console.WriteLine("{0}\t${1}\t{2}", randomAnimal.imageURL, randomAnimal.petName, randomAnimal.petDescription);
        //            }
        //        }
        //        catch(HttpRequestException e)
        //        {
        //            throw new Exception("Shit won't work");
        //        }
        //    }
        //}
    }
}