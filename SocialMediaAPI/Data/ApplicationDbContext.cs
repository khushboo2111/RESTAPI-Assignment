using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SocialMediaAPI.Models;

namespace SocialMediaAPI.Data
{
    public class DbInitializer : DbContext
    {
        public DbInitializer(DbContextOptions<DbInitializer> options) : base(options)
        {

        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Comment> Comments { get; set; }       

    }
}
