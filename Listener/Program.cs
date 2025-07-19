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

                switch (resourcePath.ToLower())
                {
                    case "myname":
                        responseMessage = GetMyName();
                        response.StatusCode = 200; // OK
                        break;
                    case "information":
                        HandleInformationRequest(response);
                        break;
                    case "success":
                        HandleSucessResponse(response);
                        break;
                    case "redirection":
                        HandleRedirectionResponse(response);
                        break;
                    case "clienterror":
                        HandleClientErrorResponse(response);
                        break;
                    case "servererror":
                        HandleServerErrorResponse(response);
                        break;
                    default:
                        // Default: Unknown resource, return 404
                        response.StatusCode = 404;
                        byte[] notFoundBuffer = Encoding.UTF8.GetBytes("Resource not found");
                        response.ContentLength64 = notFoundBuffer.Length;
                        response.OutputStream.Write(notFoundBuffer, 0, notFoundBuffer.Length);
                        break;
                }

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

    private static void HandleInformationRequest(HttpListenerResponse response)
    {
        EncodeStatusCode(response, 100, "This is an informational repsonse");
    }

    private static void HandleSucessResponse(HttpListenerResponse response)
    {
        EncodeStatusCode(response, 200, "This is a successful response");
    }
    private static void HandleRedirectionResponse(HttpListenerResponse response)
    {
        EncodeStatusCode(response, 300, "This is a redirection response");
    }
    private static void HandleServerErrorResponse(HttpListenerResponse response)
    {
        EncodeStatusCode(response, 500, "This is a server error response");
    }
    private static void HandleClientErrorResponse(HttpListenerResponse response)
    {
        EncodeStatusCode(response, 400, "This is a client error response");
    }

    static void EncodeStatusCode(HttpListenerResponse response, int statusCode, string message)
    {
        response.StatusCode = statusCode;
        byte[] buffer = Encoding.UTF8.GetBytes(message);
        response.ContentLength64 = buffer.Length;
        response.OutputStream.Write(buffer, 0, buffer.Length);
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

