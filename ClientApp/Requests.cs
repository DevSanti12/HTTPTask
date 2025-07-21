using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp
{
    public class Requests
    {
        public const string BaseUrl = "http://localhost:8080";
        public List<string> Task2Requests => new List<string>
        {
            $"{BaseUrl}/MyNameByHeader",
            $"{BaseUrl}/MyNameByCookies",
            $"{BaseUrl}/MyName",
            $"{BaseUrl}/Success",
            $"{BaseUrl}/Redirection",
            $"{BaseUrl}/Clienterror",
            $"{BaseUrl}/Servererror",
            $"{BaseUrl}/Information"
        };
    }
}
