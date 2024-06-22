using KutuphaneSistemiApi.Application.Abstractions;
using KutuphaneSistemiApi.Application.DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemiApi.Infrastructure.Services.Token
{
    public class TokenHandler : ITokenHandler
    {
        readonly IConfiguration _configuration;
        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public TokenDTO CreateToken(int seconds)
        {
            TokenDTO token = new TokenDTO();
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SigningKey"]));
            SigningCredentials signingCredentials = new(securityKey,SecurityAlgorithms.HmacSha256);
            token.ExpireDate = DateTime.UtcNow.AddSeconds(seconds);
            JwtSecurityToken securityToken = new(
                audience: _configuration["Token:Audience"],
                issuer: _configuration["Token:Issuer"],
                expires: token.ExpireDate,
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredentials
                );
            JwtSecurityTokenHandler tokenHandler = new();
            token.Jwtoken = tokenHandler.WriteToken(securityToken);
            return token;
        }
        public RefreshTokenDto CreateRefreshToken(DateTime JwtExpireDate, int addSeconds)
        {
            RefreshTokenDto refreshTokenDto = new RefreshTokenDto();
            Random rand = new();
            string letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";
            char[] chars = new char[256];
            for( int i = 0; i < chars.Length; i++) 
            {
                chars[i] = letters[rand.Next(letters.Length)];
            }
            refreshTokenDto.RefreshToken= new string(chars);
            refreshTokenDto.RefreshTokenExpireDate = JwtExpireDate.AddSeconds(addSeconds);
            return refreshTokenDto;
        }
    }
}
