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
        public async Task CreateAsync(User item, CancellationToken token)
        {
            await context.Users.AddAsync(item);
            await context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id, CancellationToken token)
        {
            var user = await GetByIdAsync(id, token);
            if (user != null)
            {
                context.Users.Remove(user);
                await context.SaveChangesAsync();
            }
        }

        public Task<User> GetByIdAsync(int id, CancellationToken token)
        {
            var result = context.Users.Where(p => p.Id == id).FirstOrDefault();
            return Task.FromResult(result);
        }

        public async Task UpdateAsync(User item, CancellationToken token)
        {
            var employee = await GetByIdAsync(item.Id, token);
            if (employee != null)
            {
                context.Users.Update(item);
                await context.SaveChangesAsync();
            }
        }
    }
}
