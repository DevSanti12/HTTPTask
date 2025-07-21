using ListenerApp.Interfaces;

namespace ListenerApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHttpServer httpServer = new HttpServer("http://localhost:8080/");
            httpServer.Start();

            Console.WriteLine("HTTP Listener is ready. Press Ctrl+C to stop the server.");
            Console.ReadLine();

            httpServer.Stop();
            Console.WriteLine("Quitting listener");
        }
    }
    //public class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        string urlPrefix = "http://localhost:8080/";
    //        HttpListener listener = new HttpListener();
    //        listener.Prefixes.Add(urlPrefix);

    //        try
    //        {
    //            listener.Start();
    //            Console.WriteLine("HTTP Listener is ready and listening on " + urlPrefix);
    //            Console.WriteLine("Press Ctrl+C to stop the server.");

    //            while (true)
    //            {
    //                HttpListenerContext context = listener.GetContext();
    //                ProcessRequest(context.Request, context.Response);
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine(ex.ToString());
    //        }
    //        finally
    //        {
    //            listener.Stop();
    //            Console.WriteLine("Quitting listener");
    //        }
    //    }

    //    public static void ProcessRequest(HttpListenerRequest request, HttpListenerResponse response)
    //    {
    //        string resourcePath = GetResourcePath(request);
    //        Console.WriteLine($"Received request for resource: {resourcePath}");

    //        switch (resourcePath.ToLower())
    //        {
    //            case "mynamebyheader":
    //                GetMyNameByHeader(response);
    //                break;
    //            case "mynamebycookies":
    //                MyNameByCookies(response);
    //                break;
    //            case "myname":
    //                EncodeStatusCode(response, 200, GetMyName());
    //                break;
    //            case "information":
    //                HandleInformationRequest(response);
    //                break;
    //            case "success":
    //                HandleSucessResponse(response);
    //                break;
    //            case "redirection":
    //                HandleRedirectionResponse(response);
    //                break;
    //            case "clienterror":
    //                HandleClientErrorResponse(response);
    //                break;
    //            case "servererror":
    //                HandleServerErrorResponse(response);
    //                break;
    //            default:
    //                HandleNotFound(response);
    //                break;
    //        }
    //    }

    //    public static void MyNameByCookies(HttpListenerResponse response)
    //    {
    //        response.StatusCode = 200;
    //        Cookie cookie = new Cookie("MyName", "Santiago")
    //        {
    //            Expires = DateTime.Now.AddMinutes(3),
    //            HttpOnly = true
    //        };
    //        response.Headers.Add(HttpResponseHeader.SetCookie, cookie.ToString());
    //        EncodeStatusCode(response, 200, "Cookie added with your name (check the MyName cookie).");
    //    }

    //    public static void GetMyNameByHeader(HttpListenerResponse response)
    //    {
    //        response.StatusCode = 200;
    //        response.Headers.Add("X-MyName", "Santiago_HTTPTask");
    //        EncodeStatusCode(response, 200, "Header added with your name (check the X-MyName header).");
    //    }

    //    public static void HandleInformationRequest(HttpListenerResponse response) =>
    //        EncodeStatusCode(response, 100, "This is an informational response");

    //    public static void HandleSucessResponse(HttpListenerResponse response) =>
    //        EncodeStatusCode(response, 200, "This is a successful response");

    //    public static void HandleRedirectionResponse(HttpListenerResponse response) =>
    //        EncodeStatusCode(response, 300, "This is a redirection response");

    //    public static void HandleClientErrorResponse(HttpListenerResponse response) =>
    //        EncodeStatusCode(response, 400, "This is a client error response");

    //    public static void HandleServerErrorResponse(HttpListenerResponse response) =>
    //        EncodeStatusCode(response, 500, "This is a server error response");

    //    public static void EncodeStatusCode(HttpListenerResponse response, int statusCode, string message)
    //    {
    //        response.StatusCode = statusCode;
    //        byte[] buffer = Encoding.UTF8.GetBytes(message);
    //        response.ContentLength64 = buffer.Length;
    //        response.OutputStream.Write(buffer, 0, buffer.Length);
    //    }

    //    public static string GetResourcePath(HttpListenerRequest request) =>
    //        request.Url.AbsolutePath.Trim('/');

    //    public static void HandleNotFound(HttpListenerResponse response) =>
    //        EncodeStatusCode(response, 404, "Resource not found");

    //    public static string GetMyName() => "Santiago";
    //}
}