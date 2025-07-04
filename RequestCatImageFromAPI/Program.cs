using RequestCatImageFromAPI.Models;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace RequestCatImageFromAPI
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                // Setting up HTTP request to API

                try
                {
                    string urlString = "https://api.thecatapi.com/v1/images/search".Trim();
                    var apiURL = new Uri(urlString);

                    Console.WriteLine("Fetching cat image from API...");
                    var requestResult = await client.GetAsync(apiURL);

                    requestResult.EnsureSuccessStatusCode();
                    Console.WriteLine("Image fetched successfully!");

                    // Deserializing response into cat image

                    var requestResponseJSON = await requestResult.Content.ReadAsStringAsync();
                    var catApiService = new CatApiService(requestResponseJSON);

                    var catImage = catApiService.GetCatImage();

                    // Saving image

                    Console.WriteLine("Saving image to desired path...");

                    string projectRoot = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\"));
                    string outputFolder = Path.Combine(projectRoot, "Images");
                    Directory.CreateDirectory(outputFolder);
                    string fileExtension = catImage.ImageURL.Substring(catImage.ImageURL.Length - 3, 3);
                    
                    string outputPath = Path.Combine(outputFolder, $"cat-image.{fileExtension}");
                    await catImage.SaveAsync(outputPath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error while making request: {ex.Message}");
                    return;
                }




            }
        }
    }
}
