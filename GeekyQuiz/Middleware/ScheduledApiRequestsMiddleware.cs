using Microsoft.AspNetCore.Http;
using System;
using System.Net.Http;
//using System.Threading.Tasks;
namespace GeekyQuiz.Middleware
{
    public class ScheduledApiRequestsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly HttpClient _httpClient;
        private DateTime _lastApiRequestTime;
        private int _requestsSent;

        public ScheduledApiRequestsMiddleware(RequestDelegate next)
        {
            _next = next;
            _next = next;
            _httpClient = new HttpClient();
            _lastApiRequestTime = DateTime.MinValue;
            _requestsSent = 0;
        }
        public async Task Invoke(HttpContext context)
        {
            // Set the desired interval (6 minutes in milliseconds)
            int intervalMilliseconds = 6 * 60 * 1000;

            if (DateTime.Now - _lastApiRequestTime >= TimeSpan.FromMilliseconds(intervalMilliseconds))
            {
                // Execute the API request
                await SendApiRequest();
            }

            await _next(context);
        }

        private async Task SendApiRequest()
        {
            // Implement the logic to send API requests to ChatGPT
            // You can use _httpClient to make the requests
            // Example:
            // HttpResponseMessage response = await _httpClient.PostAsync(apiUrl, content);

            // Update the last request time and request count
            _lastApiRequestTime = DateTime.Now;
            _requestsSent++;

            // Add your request handling logic here

        }
    }
}
