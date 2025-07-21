using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ClientApp;

namespace Client;

class Program
{
    static async Task Main(string[] args)
    {
        // Create HttpClient with a handler that supports cookies
        var handler = new HttpClientHandler
        {
            UseCookies = true, // Enable automatic cookie handling
            CookieContainer = new CookieContainer() // Create a cookie container
        };

        // Create HttpClient to send a request
        HttpClient client = new HttpClient(handler);

        var _Petitions = new Requests().Task2Requests;

        try
        {
            foreach(var myRequest in _Petitions)
            {
                Console.WriteLine($"Sending request to Listener {myRequest}...");

                // Send GET request to the Listener and wait for a response
                HttpResponseMessage response = await client.GetAsync(myRequest);
                Console.WriteLine($"Response received {response.Content})");
                // Extract cookies
                CookieCollection cookies = handler.CookieContainer.GetCookies(new Uri(myRequest));
                Cookie cookie = cookies["MyName"]; // Find the "MyName" cookie

                if (response.Headers.TryGetValues("X-MyName", out var values))
                {
                    foreach (var value in values)
                    {
                        Console.WriteLine($"Header X-MyName: {value}");
                    }
                }

                if (cookie != null)
                {
                    Console.WriteLine($"Cookie MyName: {cookie.Value}");
                }

                Console.WriteLine("Response from Listener:");
                Console.WriteLine($"Response Status Code: {(int)response.StatusCode} - {response.ReasonPhrase}");

                // Output status code and response description
                Console.WriteLine($"Response Status Code: {(int)response.StatusCode} - {response.ReasonPhrase}");
            }
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine("HTTP Request Error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("General Error: " + ex.Message);
        }
        finally
        {
            client.Dispose();
        }
    }
}