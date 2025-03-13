using BlazorServer.DTO;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace BlazorServer.Services
{
    public class RegisterService
    {
        private HttpClient client;
        public RegisterService(IHttpClientFactory httpClientFactory)
        {
            client = httpClientFactory.CreateClient("AppClient");
        }

        public async Task<bool> Register(RegisterRequest req)
        {
            var products = await client.PostAsJsonAsync("auth/register", req);
            if (products.IsSuccessStatusCode)
            {


                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
