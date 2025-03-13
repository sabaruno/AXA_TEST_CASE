﻿using System.Security.Claims;
using System.Text;
using WebAPI.Model;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace AXA_TEST_CASE.Infrastructure
{
    public class TokenProvider
    {
        private readonly IConfiguration configuration;

        public TokenProvider(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Token GenerateToken(UserAccount userAccount)
        {
            var accessToken = GenerateAccessToken(userAccount);
            return new Token { AccessToken = accessToken };
        }

        private string GenerateAccessToken(UserAccount userAccount) 
        {
            string secretKey = configuration["JWT:SecretKey"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity([
                    new Claim(ClaimTypes.Email, userAccount.Email)
                    ]),
                Expires = DateTime.Now.AddMinutes(1),
                SigningCredentials = credentials,
                Issuer = configuration["JWT:Issuer"],
                Audience = configuration["JWT:Audience"]
            };

            return new JsonWebTokenHandler().CreateToken(tokenDescriptor);
        }

    }

    public class Token
    {
        public string AccessToken { get; set; }
    }

}
