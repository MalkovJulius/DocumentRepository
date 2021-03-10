using DocumentRepository.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentRepository.Models.Services.EFCore
{
    public class ContextEF : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Document> Documents { get; set; }

        public ContextEF()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DocumentRepository;Trusted_Connection=True;");
        }
    }
}
