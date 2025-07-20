using System;
using System.Net.Http;
using System.Threading.Tasks;
using ClientApp;

namespace Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Create HttpClient to send a request
            HttpClient client = new HttpClient();

            var _Petitions = new Requests().Task2Requests;

            try
            {
                foreach(var myRequest in _Petitions)
                {
                    Console.WriteLine($"Sending request to Listener {myRequest}...");

                    // Send GET request to the Listener and wait for a response
                    HttpResponseMessage response = await client.GetAsync(myRequest);
                    Console.WriteLine($"Response received {response.Content})");

                    if (response.Headers.TryGetValues("X-MyName", out var values))
                    {
                        foreach (var value in values)
                        {
                            Console.WriteLine($"Header X-MyName: {value}");
                        }
                    }

                    Console.WriteLine("Response from Listener:");
                    // Output status code and response description
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
}