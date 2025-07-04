using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestCatImageFromAPI.Models.Interfaces
{
    public interface IApiService
    {
        CatImage GetCatImage();
    }
}
