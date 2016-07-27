using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using PetFinder.Models;

namespace PetFinder.Controllers
{
    public class RandomAnimalController : Controller
    {
        // GET: RandomAnimal
        public ActionResult Index()
        {
            return View();
        }

        static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.petfinder.com/pet.getRandom?key=8c5651bb1f65ed3b8e5163969b917f60&animal=&output=basic&format=json&callback=?");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET
                HttpResponseMessage response = await client.GetAsync("api/products/1");
                if (response.IsSuccessStatusCode)
                {
                    RandomAnimalModel randomAnimal = await response.Content.ReadAsAsync<RandomAnimalModel>();
                    Console.WriteLine("{0}\t${1}\t{2}", randomAnimal.imageURL, randomAnimal.petName, randomAnimal.petDescription);
                }
            }
        }
    }
}