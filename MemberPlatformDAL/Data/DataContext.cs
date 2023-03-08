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
        public DbSet<OptionType> OptionTypes { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<SalesItem> SalesItems { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketItem> TicketItems { get; set; }
        public DbSet<PersonPersonRelation> PersonPersonRelations { get; set; }
        public DbSet<ProductDefinition> ProductDefinitions { get; set; }
        public DbSet<ProductUnit> ProductUnits { get; set; }
        public DbSet<PriceAgreement> PriceAgreements { get; set;}
        //public DbSet<Status> Statuses { get; set;}
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<ProductAgreement> ProductAgreements { get; set; }
        public DbSet<ContractPersonInvolvement> ContractPersonInvolvements { get; set; }







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
            //modelBuilder.Entity<ContractPersonRole>().ToTable("ContractPersonRole");
            modelBuilder.Entity<Option>().ToTable("Option");
            modelBuilder.Entity<OptionType>().ToTable("OptionType");
            modelBuilder.Entity<PersonPersonRelation>().ToTable("PersonPersonRelation");
            //modelBuilder.Entity<Agreement>().ToTable("Agreement");
            //modelBuilder.Entity<AgreementDiscount>().ToTable("AgreementDiscount");
            //modelBuilder.Entity<AgreementStatus>().ToTable("AgreementStatus");
            modelBuilder.Entity<Contract>().ToTable("Contract");
            modelBuilder.Entity<ProductDefinition>().ToTable("ProductDefinition");
            //modelBuilder.Entity<ProductUnit>().ToTable("ProductUnit");
            modelBuilder.Entity<SalesItem>().ToTable("SalesItem");
            modelBuilder.Entity<Ticket>().ToTable("Ticket");
            modelBuilder.Entity<TicketItem>().ToTable("TicketItem");

            // ContractPersonInvolvement
            modelBuilder.Entity<ContractPersonInvolvement>()
            .ToTable("ContractPersonInvolvement")
            .HasOne(cpr => cpr.Role)
            .WithMany()
            .HasForeignKey(cpr => cpr.RoleId)
            .OnDelete(DeleteBehavior.NoAction);

            // Product Unit
            modelBuilder.Entity<ProductUnit>()
            .ToTable("ProductUnit")
            .HasOne(cpr => cpr.Product)
            .WithMany()
            .HasForeignKey(cpr => cpr.ProductId)
            .OnDelete(DeleteBehavior.NoAction);

            // Discount type
            modelBuilder.Entity<PriceAgreement>()
            .ToTable("PriceAgreement")
            .HasOne(cpr => cpr.DiscountType)
            .WithMany()
            .HasForeignKey(cpr => cpr.DiscountTypeId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PriceAgreement>()
            .HasOne(pa => pa.DiscountType)
            .WithMany(o => o.DiscountType)
            .HasForeignKey(pa => pa.DiscountTypeId);

            // Status price agreement
            modelBuilder.Entity<PriceAgreement>()
            .ToTable("PriceAgreement")
            .HasOne(cpr => cpr.PriceAgreementStatus)
            .WithMany()
            .HasForeignKey(cpr => cpr.PriceAgreementStatusId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Option>()
            .HasMany(o => o.PriceAgreementStatus)
            .WithOne(pd => pd.PriceAgreementStatus)
            .HasForeignKey(pd => pd.PriceAgreementStatusId);


            //modelBuilder.Entity<Status>()
            //.ToTable("Status")
            //.HasOne(cpr => cpr.StatusType)
            //.WithMany()
            //.HasForeignKey(cpr => cpr.StatusTypeId)
            //.OnDelete(DeleteBehavior.NoAction);

            // Status productdefinition
            modelBuilder.Entity<ProductDefinition>()
            .ToTable("ProductDefinition")
            .HasOne(cpr => cpr.ProductDefinitionStatus)
            .WithMany()
            .HasForeignKey(cpr => cpr.ProductDefinitionStatusId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Option>()
            .HasMany(o => o.ProductDefinitionStatus)
            .WithOne(pd => pd.ProductDefinitionStatus)
            .HasForeignKey(pd => pd.ProductDefinitionStatusId);

            // Sport
            modelBuilder.Entity<ProductDefinition>()
            .ToTable("ProductDefinition")
            .HasOne(cpr => cpr.ProductDefinitionSport)
            .WithMany()
            .HasForeignKey(cpr => cpr.ProductDefinitionSportId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Option>()
            .HasMany(o => o.ProductDefinitionSport)
            .WithOne(pd => pd.ProductDefinitionSport)
            .HasForeignKey(pd => pd.ProductDefinitionSportId);

     
            // ProdutAgreement
            modelBuilder.Entity<ProductAgreement>()
            .ToTable("ProductAgreement")
            .HasOne(cpr => cpr.ProductDefinition)
            .WithMany()
            .HasForeignKey(cpr => cpr.ProductDefinitionId)
            .OnDelete(DeleteBehavior.NoAction);


        }
    }
}





// Parent ID
//    modelBuilder.Entity<ProductDefinition>()
//    .ToTable("ProductDefinition")
//    .HasOne(cpr => cpr.ParentProductDefinition)
//    .WithMany()
//    .HasForeignKey(cpr => cpr.ParentProductDefinitionId)
//    .OnDelete(DeleteBehavior.NoAction);

//    modelBuilder.Entity<ProductDefinition>()
//.HasData(new ProductDefinition
//{
//    ProductDefinitionId = 1,
//    // set other properties here
//    Name = "Product A",
//    Description = "This is product A",
//    StartDate = DateTime.Parse("2022-01-01"),
//    EndDate = DateTime.Parse("2022-12-31"),
//    NumberOfSessions = 10,
//    MaxAmountMembers = 50,
//    Price = 100,
//    SubscriptionOpening = DateTime.Parse("2021-12-01"),
//    SubscriptionClosing = DateTime.Parse("2021-12-31"),
//    ParentProductDefinitionId = 1, // set to null for the root product definition
//    ProductDefinitionStatusId = 1,
//    ProductDefinitionFormatId = 1,
//    ProductDefinitionSportId = 1,

//});

//// Parent ID
//modelBuilder.Entity<ProductDefinition>()
//.ToTable("ProductDefinition")
//.HasMany(cpr => cpr.ChildProductDefinitions)
//.WithOne(cpr => cpr.ParentProductDefinition)
//.HasForeignKey(cpr => cpr.ParentProductDefinitionId)
//.OnDelete(DeleteBehavior.NoAction);

//modelBuilder.Entity<ProductDefinition>()
//.ToTable("ProductDefinition")
//.HasOne(p => p.ParentProductDefinition)
//.WithMany(p => p.ChildProductDefinitions)
//.HasForeignKey(p => p.ParentProductDefinitionId)
//.OnDelete(DeleteBehavior.Restrict);
//modelBuilder.Entity<ProductDefinition>()
//    .ToTable("ProductDefinition")
//.HasKey(p => p.Id);

//modelBuilder.Entity<ProductDefinition>()
//    .Property(p => p.Name)
//    .IsRequired();

//modelBuilder.Entity<ProductDefinition>()
//    .HasOne(p => p.ParentProductDefinition)
//    .WithMany()
//    .HasForeignKey(p => p.ParentProductDefinitionId)
//    .OnDelete(DeleteBehavior.Restrict);
