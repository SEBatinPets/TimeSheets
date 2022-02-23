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
    public class UsersRepository : IUsersRepository
    {
        private readonly TimeSheetsDbContext context;
        public UsersRepository(TimeSheetsDbContext context)
        {
            this.context = context;
        }
        public async Task<int> CreateAsync(User item, CancellationToken token)
        {
            try
            {
                await context.Users.AddAsync(item, token);
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
            var user = await GetByIdAsync(id, token);
            if (user != null)
            {
                context.Users.Remove(user);
                await context.SaveChangesAsync();
                return 200;
            }
            return 400;
        }

        public Task<User> GetByIdAsync(int id, CancellationToken token)
        {
            var result = context.Users.Where(p => p.Id == id).FirstOrDefault();
            return Task.FromResult(result);
        }

        public async Task<int> UpdateAsync(User item, CancellationToken token)
        {
            var employee = await GetByIdAsync(item.Id, token);
            if (employee != null)
            {
                context.Users.Update(item);
                await context.SaveChangesAsync();
                return 200;
            }
            return 400;
        }
    }
}
