using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ListenerApp
{
    public interface IHttpListener
    {
        void Start();
        void Stop();
        HttpListenerContext GetContext();
        bool IsListening { get; }
    }

}
