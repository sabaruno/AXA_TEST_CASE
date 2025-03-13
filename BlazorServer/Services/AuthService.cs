using System.Text.Json.Serialization;
using BlazorServer.DTO;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace BlazorServer.Services
{
    public class AuthService
    {
        private readonly AccessTokenService _accessTokenService;
        private readonly NavigationManager _nav;
        private HttpClient client;
        public AuthService(AccessTokenService accessTokenService, 
            NavigationManager nav, IHttpClientFactory httpClientFactory)
        {
            this._accessTokenService = accessTokenService; 
            this._nav = nav;
            client = httpClientFactory.CreateClient("AppClient");
        }

        public async Task<bool> Login(string email, string password)
        {
            var status = await client.PostAsJsonAsync("auth", new { email, password });
            if(status.IsSuccessStatusCode)
            {
                var token = await status.Content.ReadAsStringAsync();
                var result =  JsonConvert.DeserializeObject<AuthResponse>(token);
                await _accessTokenService.SetToken(result.AccessToken);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task Logout()
        {
            await _accessTokenService.RemoveToken();
            _nav.NavigateTo("/Login", forceLoad: true);
        }
    }
}
