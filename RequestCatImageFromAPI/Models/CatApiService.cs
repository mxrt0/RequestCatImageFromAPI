using RequestCatImageFromAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RequestCatImageFromAPI.Models
{
    // Deserialize JSON response into Cat Image
    public class CatApiService : IApiService
    {
        public CatApiService(string jsonResponse)
        {
            JsonResponse = jsonResponse;
        }
        public string JsonResponse { get; private set; }
        public CatImage GetCatImage()
        {
            Console.WriteLine(JsonResponse);
            var catResponse = JsonSerializer.Deserialize<CatApiResponse[]>(JsonResponse); // response returns array
            //if (catResponse is null || catResponse.Count == 0 )
            //{
            //    throw new Exception("No cat images found in the response.");
            //}
            //Console.WriteLine($"Count: {catResponse?.Count}");
            //if (catResponse?.Count > 0)
            //{
            //    Console.WriteLine($"First Url: {catResponse[0].Url}");
            //}
            var catImageURL = catResponse?[0]?.Url; // we only need the URL of the (only) array object
            if (string.IsNullOrEmpty(catImageURL))
            {
                throw new Exception("Cat image URL is empty.");

            }
           return new CatImage(catImageURL);   
        }
    }
}
