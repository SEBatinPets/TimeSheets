using ModelsLibrary.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.Models.DTO
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public bool IsDeleted { get; set; }
        public string Comment { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public static implicit operator User(UserDto userDto)
        {
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
