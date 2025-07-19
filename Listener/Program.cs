using System;
using System.Net;
using System.Text;
using System.Net.Http;

namespace ListenerApp;
public class Program
{
    static void Main(string[] args)
    {
        //define the servers HTTP endpoint
        string urlPrefix = "http://localhost:8080/";

        //Create the listener
        HttpListener listener = new HttpListener();
        listener.Prefixes.Add(urlPrefix);

        try
        {
            listener.Start();
            Console.WriteLine("HTTP Listener is ready and listening on " + urlPrefix);
            Console.WriteLine("press Ctrl+C to stop the server");

            while (true) 
            {
                //wait for request from client
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;

                //using GetResourcePath to parse the request
                string resourcePath = GetResourcePath(request);

                Console.WriteLine($"Received request for resource: {resourcePath}");

                //process the request, send appropiate response
                HttpListenerResponse response = context.Response;
                string responseMessage;

                if (resourcePath.Equals("MyName", StringComparison.OrdinalIgnoreCase))
                {
                    responseMessage = GetMyName();
                }
                else
                {
                    //No such resource
                    responseMessage = "Resource not found";
                    response.StatusCode = 404;
                }

                byte[] buffer = Encoding.UTF8.GetBytes(responseMessage);
                response.ContentLength64 = buffer.Length;
                response.OutputStream.Write(buffer, 0, buffer.Length);
                response.OutputStream.Close();
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        finally 
        {
            listener.Stop();
            Console.WriteLine("Quitting listener");
        }
    }

    /// <summary>
    /// Parses the request URL and extracts the resource path.
    /// </summary>
    /// <param name="request">The HttpListenerRequest object.</param>
    /// <returns>The extracted resource path (e.g., "MyName").</returns>
    static string GetResourcePath(HttpListenerRequest request)
    {
        return request.Url.AbsolutePath.Trim('/');
    }

    /// <summary>
    /// Returns my name
    /// </summary>
    /// <returns>Santiago</returns>
    static string GetMyName()
    {
        return "Santiago";
    }
}

