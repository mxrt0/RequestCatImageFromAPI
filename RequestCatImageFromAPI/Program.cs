using static System.Net.WebRequestMethods;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace RequestCatImageFromAPI
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                // Setting up HTTP request to API

                var apiURL = new Uri("https://aws.random.cat/meow");

                Console.WriteLine("Fetching cat image from API...");
                var requestResult = await client.GetAsync(apiURL);

                try
                {
                    requestResult.EnsureSuccessStatusCode();
                    Console.WriteLine("Image fetched successfully!");
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }

                // Deserializing response
                var requestResponse =  await requestResult.Content.ReadAsStringAsync();

            }
        }
    }
}
