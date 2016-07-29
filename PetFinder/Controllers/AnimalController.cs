using Newtonsoft.Json;
using PetFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Routing;

namespace PetFinder.Controllers
{
    public class AnimalController : ApiController
    {
        public async Task<RandomAnimalModel> GetRequest(string url)
        {
            using (HttpClient client = new HttpClient()) // using is for disposable things
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (HttpResponseMessage response = await client.GetAsync(url).ConfigureAwait(false))
                {
                    using (HttpContent content = response.Content)
                    {
                        string myContent = await content.ReadAsStringAsync();
                        RandomAnimalModel RandomAnimal = JsonConvert.DeserializeObject<RandomAnimalModel>(myContent);

                        return RandomAnimal;

                    }
                }
            }
        }
    }
}
