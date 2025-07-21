using System.Net;
using ListenerApp.Interfaces;

namespace ListenerApp;

public class RequestRouter
{
    private readonly Dictionary<string, IRequestHandler> _handlers;

    public RequestRouter()
    {
        _handlers = new Dictionary<string, IRequestHandler>(StringComparer.OrdinalIgnoreCase)
        {
            { "mynamebyheader", new HeaderRequestHandler() },
            { "mynamebycookies", new CookiesRequestHandler() },
            { "myname", new NameRequestHandler() },
            { "information", new InformationRequestHandler() },
            { "success", new SuccessRequestHandler() },
            { "redirection", new RedirectionRequestHandler() },
            { "clienterror", new ClientErrorRequestHandler() },
            { "servererror", new ServerErrorRequestHandler() },
            { "notfound", new NotFoundRequestHandler() }
        };
    }

    public void RouteRequest(HttpListenerRequest request, HttpListenerResponse response)
    {
        string resourcePath = request.Url.AbsolutePath.Trim('/');
        Console.WriteLine($"Received request for: {resourcePath}");

        if (_handlers.TryGetValue(resourcePath, out IRequestHandler handler))
        {
            handler.Handle(request, response);
        }
        else
        {
            new NotFoundRequestHandler().Handle(request, response);
        }
    }
}
