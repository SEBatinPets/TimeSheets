using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.Models.Entities.Auth
{
    public sealed class AuthResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public RefreshToken LatestRefreshToken { get; set; }
    }
}
