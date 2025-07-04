using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RequestCatImageFromAPI.Models
{
    // JSON object mapper
    public class CatApiResponse
    {
        public string Id { get; set; } // unused
        [JsonPropertyName("url")] // force mapping to avoid mismatch of JSON and C# URL property
        public string Url { get;  set; } 
        public int Width { get; set; } // unused
        public int Height { get; set; } // unused
    }
}
