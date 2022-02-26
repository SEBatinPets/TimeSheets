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
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly TimeSheetsDbContext context;
        public EmployeesRepository(TimeSheetsDbContext context)
        {
            this.context = context;
        }
        public async Task<int> CreateAsync(Employee item, CancellationToken token)
        {
            try
            {
                await context.Employees.AddAsync(item, token);
                await context.SaveChangesAsync();
                return 200;
            }
            catch
            {
                return 400;
            }
        }

        public async Task<int> DeleteByIdAsync(int id, CancellationToken token)
        {
            var employee = await GetByIdAsync(id, token);
            if(employee != null)
            {
                context.Employees.Remove(employee);
                await context.SaveChangesAsync();
                return 200;
            }
            return 400;
        }

        public Task<Employee> GetByIdAsync(int id, CancellationToken token)
        {
            var result = context.Employees.Where(p => p.Id == id).FirstOrDefault();
            return Task.FromResult(result);
        }

        public async Task<int> UpdateAsync(Employee item, CancellationToken token)
        {
            //проверяем что такой объект существует
            var employee = await GetByIdAsync(item.Id, token);
            if(employee != null)
            {
                context.Employees.Update(item);
                await context.SaveChangesAsync();
                return 200;
            }
            return 400;
        }
    }
}
