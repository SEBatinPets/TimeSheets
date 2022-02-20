using ModelsLibrary.Models.Entities;
using RepositoriesLibrary.Data.Ef.DbContexts;
using RepositoriesLibrary.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RepositoriesLibrary.Repositories.Implementation
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly TimeSheetsDbContext context;
        public EmployeeRepository(TimeSheetsDbContext context)
        {
            this.context = context;
        }
        public async Task CreateAsync(Employee item, CancellationToken token)
        {
            await context.Employees.AddAsync(item, token);
            await context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id, CancellationToken token)
        {
            var employee = await GetByIdAsync(id, token);
            if(employee != null)
            {
                context.Employees.Remove(employee);
                await context.SaveChangesAsync();
            }
        }

        public Task<Employee> GetByIdAsync(int id, CancellationToken token)
        {
            var result = context.Employees.Where(p => p.Id == id).FirstOrDefault();
            return Task.FromResult(result);
        }

        public async Task UpdateAsync(Employee item, CancellationToken token)
        {
            //проверяем что такой объект существует
            var employee = await GetByIdAsync(item.Id, token);
            if(employee != null)
            {
                context.Employees.Update(item);
                await context.SaveChangesAsync();
            }
        }
    }
}
