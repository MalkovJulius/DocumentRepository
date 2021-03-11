using DocumentRepository.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace DocumentRepository.Models.Services.EFCore
{
    public class ContextEF : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Document> Documents { get; set; }

        private readonly StreamWriter logger;

        public ContextEF()
        {
            Database.EnsureCreated();
            logger = new StreamWriter("ErrorLog.txt", true);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DocumentRepository;Trusted_Connection=True;");
            optionsBuilder.LogTo(logger.WriteLine, LogLevel.Error);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //использование Fluent API
            base.OnModelCreating(modelBuilder);
        }

        public override void Dispose()
        {
            base.Dispose();
            logger.Dispose();
        }

        public override async ValueTask DisposeAsync()
        {
            await base.DisposeAsync();
            await logger.DisposeAsync();
        }
    }
}
