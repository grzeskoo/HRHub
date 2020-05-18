using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRHub_UI.Static
{
    public static class EndPoints
    {
        public static string BaseUrl = "https://localhost:44326/";
        public static string reg_eu_SectorEndpoint = $"{BaseUrl}api/reg_eu_Sector/";
        public static string RegisterEndpoint = $"{BaseUrl}api/user/register";
        public static string LoginEndpoint = $"{BaseUrl}api/user/login";

    }
}
