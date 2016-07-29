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
        // GET: RandomAnimal
        //public ActionResult Index(Request request)
        //{
        //    GetRequest(request.requestURL).Wait();
        //    return View();
        //}

        public async Task<ActionResult> Index(Request request)
        {
            using (HttpClient client = new HttpClient()) // using is for disposable things
            {
                client.BaseAddress = new Uri("http://api.petfinder.com/pet.getRandom?key=8c5651bb1f65ed3b8e5163969b917f60&animal=&output=basic&format=json");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (HttpResponseMessage response = await client.GetAsync(request.requestURL).ConfigureAwait(false))
                { 
                    using (HttpContent content = response.Content)
                    {
                        string myContent = await content.ReadAsStringAsync();
                        RandomAnimalModel RandomAnimal = JsonConvert.DeserializeObject<RandomAnimalModel>(myContent);

                        return View("Index", RandomAnimal);

                    }
                }
                
            }
        }
    }
}

//RandomAnimalModel RandomAnimal = await response.Content.ReadAsAsync<RandomAnimalModel>();

// http://api.petfinder.com/pet.getRandom?key=8c5651bb1f65ed3b8e5163969b917f60&animal=&output=basic&format=json
// http://api.petfinder.com/?key=8c5651bb1f65ed3b8e5163969b917f60&animal=&output=basic&format=json