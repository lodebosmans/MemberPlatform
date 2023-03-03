using MemberPlatformDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberPlatformDAL.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<ContractPersonRole> ContractRoles { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<OptionType> OptionTypes { get; set; }
        public DbSet<PersonRelationship> PersonRelationships { get; set; }
        public DbSet<Agreement> Agreements { get; set; }
        public DbSet<AgreementDiscount> AgreementsDiscount { get; set;}
        public DbSet<AgreementFormat> AgreementsFormat { get; set;}
        public DbSet<AgreementProduct> AgreementsProduct { get; set;}
        public DbSet<AgreementSport> AgreementSports { get; set; }
        public DbSet<AgreementStatus> AgreementsStatus { get; set;}
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SalesItem> SalesItems { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketItem> TicketItems { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MemberPlatformApi;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<ContractPersonRole>().ToTable("ContractPersonRole");
            modelBuilder.Entity<Option>().ToTable("Option");
            modelBuilder.Entity<OptionType>().ToTable("OptionType");
            modelBuilder.Entity<PersonRelationship>().ToTable("PersonRelationship");
            modelBuilder.Entity<Agreement>().ToTable("Agreement");
            modelBuilder.Entity<AgreementDiscount>().ToTable("AgreementDiscount");
            modelBuilder.Entity<AgreementFormat>().ToTable("AgreementFormat");
            modelBuilder.Entity<AgreementProduct>().ToTable("AgreementProduct");
            modelBuilder.Entity<AgreementSport>().ToTable("AgreementSport");
            modelBuilder.Entity<AgreementStatus>().ToTable("AgreementStatus");
            modelBuilder.Entity<Contract>().ToTable("Contract");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<SalesItem>().ToTable("SalesItem");
            modelBuilder.Entity<Ticket>().ToTable("Ticket");
            modelBuilder.Entity<TicketItem>().ToTable("TicketItem");


        }
    }
}
