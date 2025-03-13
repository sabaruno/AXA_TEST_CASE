using Microsoft.JSInterop;

namespace BlazorServer.Services
{
    public class CookiesService
    {
        private readonly IJSRuntime _jSRuntime;
        public CookiesService(IJSRuntime jSRuntime)
        {
            this._jSRuntime = jSRuntime;

        }

        public async Task<string> Get(string key)
        {
            return await _jSRuntime.InvokeAsync<string>("getCookie", key);
        }

        public async Task Remove(string key)
        {
             await _jSRuntime.InvokeAsync<string>("deleteCookie", key);
        }

        public async Task Set(string key, string value, int days)
        {
            await _jSRuntime.InvokeAsync<string>("setCookie", key, value, days);
        }

    }
}
