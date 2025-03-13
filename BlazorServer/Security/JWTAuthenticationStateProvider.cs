using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BlazorServer.Services;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorServer.Security
{
    public class JWTAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly AccessTokenService _accessTokenService;
        public JWTAuthenticationStateProvider(AccessTokenService accessTokenService)
        {
            this._accessTokenService = accessTokenService;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var token = await _accessTokenService.GetToken();
                if (string.IsNullOrWhiteSpace(token))
                {
                    MarkAsUnauthorize();
                }

                var readJWT = new JwtSecurityTokenHandler().ReadJwtToken(token);
                var identity = new ClaimsIdentity(readJWT.Claims, "JWT");
                var principal = new ClaimsPrincipal(identity);
                return await Task.FromResult(new AuthenticationState(principal));

            }
            catch (Exception ex)
            {
                return await MarkAsUnauthorize();
            }
        }

        public async Task<AuthenticationState> MarkAsUnauthorize()
        {
            try
            {
                var state = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
                NotifyAuthenticationStateChanged(Task.FromResult(state));
                return state;
            }
            catch (Exception ex) 
            { 
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

        }
    }
}
