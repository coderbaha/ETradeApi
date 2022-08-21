using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Core.Utilities.Security
{
    public class TokenService
    {
        public static string GenerateToken(string jwtKey, DateTime expires,
            IEnumerable<Claim> claims, string issuer = "site.com", string audience = "site.com")
        {
            byte[] Key = Encoding.UTF8.GetBytes(jwtKey);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Key);
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            JwtSecurityToken jwtSecurityToken =
                new JwtSecurityToken(issuer, audience, claims, expires: DateTime.Now.AddDays(30), signingCredentials: credentials);
            string token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return token;
        }
    }
}
