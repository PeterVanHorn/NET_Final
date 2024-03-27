using System.Collections.Generic;
using System.Net.Sockets;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace VanHorn_NET_Final.Models
{
    public class DomainContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }

        public DomainContext(DbContextOptions<DomainContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}

