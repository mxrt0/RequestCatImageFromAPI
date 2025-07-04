using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestCatImageFromAPI.Models
{
    public class CatImage
    {
        public string ImageURL { get; private set; }

        public CatImage(string url)
        {
            ImageURL = url;
        }
        
        
        public async Task SaveAsync(string outputPath)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    // Send GET request to image URL

                    Console.WriteLine("Downloading cat image...");
                    var requestResult = await client.GetAsync(ImageURL);

                    requestResult.EnsureSuccessStatusCode();

                    // Save image to desired path

                    Console.WriteLine("Saving cat image...");
                    using var imageStream = await requestResult.Content.ReadAsStreamAsync();

                    int bufferSize = 1024; // Set buffer size as desired

                    byte[] buffer = new byte[bufferSize];

                    using FileStream fileStream = new FileStream(outputPath, FileMode.Create);

                    int bytesRead;
                    while ((bytesRead = await imageStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        await fileStream.WriteAsync(buffer, 0, bytesRead);
                    }
                    Console.WriteLine($"Successfully saved cat image at {Path.GetFullPath(outputPath)}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error while downloading/saving image: " + ex.Message);
                    return;
                }
            }
        }
    }
}
