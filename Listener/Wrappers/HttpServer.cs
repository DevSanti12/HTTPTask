using System.Net;
using ListenerApp.Interfaces;

namespace ListenerApp
{
    public class HttpServer : IHttpServer
    {
        private readonly string _urlPrefix;
        private readonly HttpListener _listener;
        private readonly RequestRouter _router;

        public HttpServer(string urlPrefix)
        {
            _urlPrefix = urlPrefix;
            _listener = new HttpListener();
            _listener.Prefixes.Add(_urlPrefix);
            _router = new RequestRouter();
        }

        public void Start()
        {
            try
            {
                _listener.Start();
                Console.WriteLine("HTTP Listener started on " + _urlPrefix);

                while (true)
                {
                    HttpListenerContext context = _listener.GetContext();
                    _router.RouteRequest(context.Request, context.Response);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
            finally
            {
                Stop();
            }
        }

        public void Stop()
        {
            _listener.Stop();
        }
    }
}