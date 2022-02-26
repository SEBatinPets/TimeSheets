using Microsoft.IdentityModel.Tokens;
using ModelsLibrary.Models.Entities.Auth;
using RepositoriesLibrary.Repositories.Interfaces;
using ServiceLibrary.AuthorizationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceLibrary.AuthorizationServices.Implementation
{
    public class AuthService: IAuthService
    {
        public const string SecretCode = "THIS IS SOME VERY SECRET STRING!!! Im blue da ba dee da ba di da ba dee da ba di da d ba dee da ba di da ba dee";
        private readonly IAuthResponseRepository authRepository;

        public AuthService(IAuthResponseRepository authRepository)
        {
            this.authRepository = authRepository;
        }

        public async Task<TokenResponse> Authenticate(string user, string password, CancellationToken token)
        {
            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(password))
            {
                return null;
            }
            TokenResponse tokenResponse = new TokenResponse();

            //получаем логин и пароль
            var pair = await authRepository.GetByLogin(user, token);
            //если такого логина нет
            if(pair == null)
            {
                //возвращаем null
                return null;
            }
            if (string.CompareOrdinal(pair.Login, user) == 0 && string.CompareOrdinal(pair.Password, password) == 0)
            {
                tokenResponse.Token = GenerateJwtToken(pair.Id, 15);
                RefreshToken refreshToken = GenerateRefreshToken(pair.Id);
                await authRepository.UpdateLatestRefreshToken(pair.Id, refreshToken, token);
                tokenResponse.RefreshToken = refreshToken.Token;
                return tokenResponse;
            }
            
            return null;
        }

        public async Task<string> RefreshToken(string token, CancellationToken cancellationToken)
        {
            var pair = await authRepository.GetByToken(token, cancellationToken);
            {
                if (pair.LatestRefreshToken.IsExpired is false)
                {
                    var refreshToken = GenerateRefreshToken(pair.Id);
                    await authRepository.UpdateLatestRefreshToken(pair.Id, refreshToken, cancellationToken);
                    return refreshToken.Token;
                }
            }
            return string.Empty;
        }

        private string GenerateJwtToken(int id, int minutes)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(SecretCode);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(minutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public RefreshToken GenerateRefreshToken(int id)
        {
            RefreshToken refreshToken = new RefreshToken();
            refreshToken.Expires = DateTime.Now.AddMinutes(360);
            refreshToken.Token = GenerateJwtToken(id, 360);
            return refreshToken;
        }


    }
}
