using DatingApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace DatingApp.DataContext
{
    public class DataBaseContext : IdentityDbContext<ApplicationUser, Role, Guid>
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }
        public DbSet<Value> Values { get; set; }
    }
}
