using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Define the Listener's HTTP endpoint
            string url = "http://localhost:8080/MyName/";

            // Create HttpClient to send a request
            HttpClient client = new HttpClient();

            try
            {
                Console.WriteLine("Sending request to Listener...");

                // Send GET request to the Listener and wait for a response
                HttpResponseMessage response = await client.GetAsync(url);

                // Ensure success status code
                response.EnsureSuccessStatusCode();

                // Read response content (your name)
                string responseString = await response.Content.ReadAsStringAsync();

                Console.WriteLine("Response from Listener:");
                Console.WriteLine(responseString);
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