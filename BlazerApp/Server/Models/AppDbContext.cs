using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BlazerApp.Shared;
namespace BlazerApp.Server.Models
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options) { 
        
        }

        public DbSet<Assignment> Assignments { get; set; }
    }
}
