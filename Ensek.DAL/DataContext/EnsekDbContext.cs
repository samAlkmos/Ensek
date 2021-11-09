using CsvHelper;
using Ensek.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.IO;

namespace Ensek.DAL.DataContext
{
    public class EnsekDbContext : DbContext
    {
        public EnsekDbContext(DbContextOptions<EnsekDbContext> options) : base(options) { }

        public DbSet<MeterReadingModel> MeterReadings { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            using var streamReader = File.OpenText("Test_Accounts.csv");
            using var csvReader = new CsvReader(streamReader, CultureInfo.CurrentCulture);

            var accounts = csvReader.GetRecords<Account>();


            modelBuilder.Entity<Account>().HasData(accounts);
        }
    }
}
