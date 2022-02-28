using ModelsLibrary.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.Models.DTO
{
    public class UserDto
    {
        [Range(1, int.MaxValue)]
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

        public static implicit operator User(UserDto userDto)
        {
            if(userDto == null)
            {
                return null;
            }
            return new User()
            {
                Id = userDto.Id,
                UserName = userDto.UserName,
                IsDeleted = userDto.IsDeleted,
                Comment = userDto.Comment,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                MiddleName = userDto.MiddleName
            };
        }
        public static implicit operator UserDto(User user)
        {
            if (user == null)
            {
                return null;
            }
            return new UserDto()
            {
                Id=user.Id,
                UserName=user.UserName,
                IsDeleted=user.IsDeleted,
                Comment=user.Comment,
                FirstName=user.FirstName,
                LastName=user.LastName,
                MiddleName=user.MiddleName
            };
        }
    }
}
