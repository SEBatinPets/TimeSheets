using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.Models.Entities.Auth
{
    public sealed class AuthResponse
    {
        public int Id { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int UserId { get; set; }
        [Required]
        [MaxLength(40)]
        [MinLength(2)]
        public string Login { get; set; }
        [Required]
        [MaxLength(40)]
        [MinLength(2)]
        public string Password { get; set; }
        public RefreshToken LatestRefreshToken { get; set; }
    }
}
