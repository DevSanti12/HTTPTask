using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ListenerApp.Interfaces;
using ListenerApp.Wrappers;

namespace ListenerApp;

public class InformationRequestHandler : IRequestHandler
{
    public void Handle(HttpListenerRequest request, HttpListenerResponse response)
    {
        ResponseHelper.EncodeStatusCode(response, 100, "This is an informational response.");
    }
}
