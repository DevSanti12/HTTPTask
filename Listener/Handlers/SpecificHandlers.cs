using System.Net;
using ListenerApp.Interfaces;
using ListenerApp.Wrappers;

namespace ListenerApp;

public class CookiesRequestHandler : IRequestHandler
{
    public void Handle(HttpListenerRequest request, HttpListenerResponse response)
    {
        response.StatusCode = 200;
        Cookie cookie = new Cookie("MyName", "Santiago")
        {
            Expires = DateTime.Now.AddMinutes(3),
            HttpOnly = true
        };
        response.Headers.Add(HttpResponseHeader.SetCookie, cookie.ToString());
        ResponseHelper.EncodeStatusCode(response, 200, "Cookie added with your name.");
    }
}

public class HeaderRequestHandler : IRequestHandler
{
    public void Handle(HttpListenerRequest request, HttpListenerResponse response)
    {
        response.StatusCode = 200;
        response.Headers.Add("X-MyName", "Santiago_HTTPTask");
        ResponseHelper.EncodeStatusCode(response, 200, "Header added with your name.");
    }
}

public class NameRequestHandler : IRequestHandler
{
    public void Handle(HttpListenerRequest request, HttpListenerResponse response)
    {
        ResponseHelper.EncodeStatusCode(response, 200, GetMyName());
    }

    private string GetMyName() => "Santiago";
}

public class SuccessRequestHandler : IRequestHandler
{
    public void Handle(HttpListenerRequest request, HttpListenerResponse response)
    {
        ResponseHelper.EncodeStatusCode(response, 200, "This is a successful response.");
    }
}

public class ClientErrorRequestHandler : IRequestHandler
{
    public void Handle(HttpListenerRequest request, HttpListenerResponse response)
    {
        ResponseHelper.EncodeStatusCode(response, 400, "This is a client error response.");
    }
}

public class ServerErrorRequestHandler : IRequestHandler
{
    public void Handle(HttpListenerRequest request, HttpListenerResponse response)
    {
        ResponseHelper.EncodeStatusCode(response, 500, "This is a server error response.");
    }
}

public class RedirectionRequestHandler : IRequestHandler
{
    public void Handle(HttpListenerRequest request, HttpListenerResponse response)
    {
        ResponseHelper.EncodeStatusCode(response, 300, "This is a redirection response.");
    }
}

public class NotFoundRequestHandler : IRequestHandler
{
    public void Handle(HttpListenerRequest request, HttpListenerResponse response)
    {
        ResponseHelper.EncodeStatusCode(response, 404, "Resource not found.");
    }
}
