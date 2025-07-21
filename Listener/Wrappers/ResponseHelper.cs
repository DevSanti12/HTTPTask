using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ListenerApp.Wrappers;

public static class ResponseHelper
{
    public static void EncodeStatusCode(HttpListenerResponse response, int statusCode, string message)
    {
        response.StatusCode = statusCode;
        byte[] buffer = Encoding.UTF8.GetBytes(message);
        response.ContentLength64 = buffer.Length;
        response.OutputStream.Write(buffer, 0, buffer.Length);
    }
}
