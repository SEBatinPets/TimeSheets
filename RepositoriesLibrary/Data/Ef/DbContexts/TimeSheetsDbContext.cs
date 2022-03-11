using Microsoft.EntityFrameworkCore;
using ModelsLibrary.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoriesLibrary.Data.Ef.DbContexts
{
    public class TimeSheetsDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public TimeSheetsDbContext(DbContextOptions options): base(options)
        {
            Database.EnsureCreated();
        }
    }
}
