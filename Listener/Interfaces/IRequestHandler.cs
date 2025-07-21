using System.Net;

namespace ListenerApp.Interfaces;

public interface IRequestHandler
{
    void Handle(HttpListenerRequest request, HttpListenerResponse response);
}
