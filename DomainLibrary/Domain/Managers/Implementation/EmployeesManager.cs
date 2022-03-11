using DomainLibrary.Domain.Managers.Interfaces;
using ModelsLibrary.Models.DTO;
using ModelsLibrary.Models.Entities;
using RepositoriesLibrary.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DomainLibrary.Domain.Managers.Implementation
{
    public class EmployeesManager : IEmployeesManager
    {
        private readonly IEmployeesRepository employeeRepository;
        public EmployeesManager(IEmployeesRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public async Task<int> CreateAsync(EmployeeDto item, CancellationToken token)
        {
            return await employeeRepository.CreateAsync(item, token);
        }

        public async Task<int> DeleteByIdAsync(int id, CancellationToken token)
        {
            return await employeeRepository.DeleteByIdAsync(id, token);
        }

        public async Task<EmployeeDto> GetByIdAsync(int id, CancellationToken token)
        {
            return await employeeRepository.GetByIdAsync(id, token);
        }

        public async Task<int> UpdateAsync(EmployeeDto item, CancellationToken token)
        {
            return await employeeRepository.UpdateAsync(item, token);
        }
    }
}
