using ModelsLibrary.Models.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.Models.DTO.Auth
{
    public class RefreshTokenDto
    {
        public string Token { get; set; }

        public DateTime Expires { get; set; }

        public bool IsExpired => DateTime.UtcNow >= Expires;

        public static implicit operator RefreshToken(RefreshTokenDto tokenDto)
        {
            if (tokenDto == null)
            {
                return null;
            }
            return new RefreshToken()
            {
                Token = tokenDto.Token,
                Expires = tokenDto.Expires
            };
        }
        public static implicit operator RefreshTokenDto(RefreshToken refreshToken)
        {
            if (refreshToken == null)
            {
                return null;
            }
            return new RefreshTokenDto()
            {
                Token = refreshToken.Token,
                Expires = refreshToken.Expires
            };
        }
    }
}
