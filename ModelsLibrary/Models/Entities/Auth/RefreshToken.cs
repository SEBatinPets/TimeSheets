using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.Models.Entities.Auth
{
    public sealed class RefreshToken
    {
        public int Id { get; set; }
        public int AuthResponseId { get; set; }
        public AuthResponse AuthResponse { get; set; }
        public string Token { get; set; }

        public DateTime Expires { get; set; }

        public bool IsExpired => DateTime.UtcNow >= Expires;

    }
}
