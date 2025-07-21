using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ListenerApp
{
    public class HttpListenerWrapper : IHttpListener
    {
        private readonly HttpListener _innerListener = new HttpListener();

        public void Start() => _innerListener.Start();
        public void Stop() => _innerListener.Stop();
        public HttpListenerContext GetContext() => _innerListener.GetContext();
        public bool IsListening => _innerListener.IsListening;
    }
}
