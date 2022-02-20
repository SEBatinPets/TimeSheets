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
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeRepository employeeRepository;
        public EmployeeManager(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public async Task CreateAsync(EmployeeDto item, CancellationToken token)
        {
            await employeeRepository.CreateAsync(item, token);
        }

        public async Task DeleteByIdAsync(int id, CancellationToken token)
        {
            await employeeRepository.DeleteByIdAsync(id, token);
        }

        public async Task<EmployeeDto> GetByIdAsync(int id, CancellationToken token)
        {
            return await employeeRepository.GetByIdAsync(id, token);
        }

        public async Task UpdateAsync(EmployeeDto item, CancellationToken token)
        {
            await employeeRepository.UpdateAsync(item, token);
        }
    }
}
