using ModelsLibrary.Models.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.Models.DTO.Auth
{
    public class AuthResponseDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public RefreshTokenDto LatestRefreshToken { get; set; }

        public static implicit operator AuthResponse(AuthResponseDto authDto)
        {
            if (authDto == null)
            {
                return null;
            }
            return new AuthResponse()
            {
                Id = authDto.Id,
                UserId = authDto.UserId,
                Login = authDto.Login,
                Password = authDto.Password,
                LatestRefreshToken = authDto.LatestRefreshToken
            };
        }
        public static implicit operator AuthResponseDto(AuthResponse auth)
        {
            if (auth == null)
            {
                return null;
            }
            return new AuthResponseDto()
            {
                Id=auth.Id,
                UserId=auth.UserId,
                Login=auth.Login,
                Password=auth.Password,
                LatestRefreshToken=auth.LatestRefreshToken
            };
        }
    }
}
