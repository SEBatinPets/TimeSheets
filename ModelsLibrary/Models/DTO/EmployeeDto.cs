using ModelsLibrary.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.Models.DTO
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool IsDeleted { get; set; }

        public static implicit operator Employee(EmployeeDto employeeDto)
        {
            if(employeeDto == null)
            {
                return null;
            }
            return new Employee()
            {
                Id = employeeDto.Id,
                UserId = employeeDto.UserId,
                IsDeleted = employeeDto.IsDeleted
            };
        }
        public static implicit operator EmployeeDto(Employee employee)
        {
            if (employee == null)
            {
                return null;
            }
            return new EmployeeDto()
            {
                Id =employee.Id,
                UserId=employee.UserId,
                IsDeleted=employee.IsDeleted
            };
        }
    }
}
