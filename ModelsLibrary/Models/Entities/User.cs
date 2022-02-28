using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        [MinLength(2)]
        public string UserName { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
        [MaxLength(200)]
        [MinLength(2)]
        public string Comment { get; set; }
        [Required]
        [MaxLength(40)]
        [MinLength(2)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(40)]
        [MinLength(2)]
        public string LastName { get; set; }
        [MaxLength(40)]
        [MinLength(2)]
        public string MiddleName { get; set; }
    }
}
