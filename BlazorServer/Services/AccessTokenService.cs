namespace BlazorServer.Services
{
    public class AccessTokenService
    {
        private readonly CookiesService _cookiesService;
        private readonly string _tokenKey = "access_token";
        public AccessTokenService(CookiesService cookiesService)
        {
             this._cookiesService = cookiesService;
        }

        public async  Task SetToken(string accessToken)
        {
            await _cookiesService.Set(_tokenKey, accessToken, 1);
        }

        public async Task<string> GetToken()
        {
            return await _cookiesService.Get(_tokenKey);
        }

        public async Task RemoveToken()
        {
            await _cookiesService.Remove(_tokenKey);
        }
    }
}
