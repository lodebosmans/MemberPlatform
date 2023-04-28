using MemberPlatformDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace MemberPlatformDAL.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<OptionTypeEntity> OptionTypes { get; set; }
        public DbSet<OptionEntity> Options { get; set; }
        public DbSet<AddressEntity> Addresses { get; set; }
        public DbSet<SalesItemEntity> SalesItems { get; set; }
        public DbSet<PersonEntity> Persons { get; set; }
        public DbSet<TicketEntity> Tickets { get; set; }
        public DbSet<TicketItemEntity> TicketItems { get; set; }
        public DbSet<PersonPersonRelationEntity> PersonPersonRelations { get; set; }
        public DbSet<ProductDefinitionEntity> ProductDefinitions { get; set; }
        public DbSet<ProductUnitEntity> ProductUnits { get; set; }
        public DbSet<PriceAgreementEntity> PriceAgreements { get; set; }

        //public DbSet<Status> Statuses { get; set;}
        public DbSet<ContractEntity> Contracts { get; set; }

        public DbSet<ProductAgreementEntity> ProductAgreements { get; set; }
        public DbSet<ContractPersonInvolvementEntity> ContractPersonInvolvements { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MemberPlatformApi;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<PersonEntity>().HasAlternateKey(p => p.EmailAddress); // Disabled, as emailaddress should be nullable for children of parent person
            //modelBuilder.Entity<PersonEntity>().ToTable("Person");
            //modelBuilder.Entity<ContractPersonRole>().ToTable("ContractPersonRole");
            modelBuilder.Entity<OptionEntity>().ToTable("Option");
            modelBuilder.Entity<OptionTypeEntity>().ToTable("OptionType");
            modelBuilder.Entity<PersonPersonRelationEntity>().ToTable("PersonPersonRelation");
            //modelBuilder.Entity<Agreement>().ToTable("Agreement");
            //modelBuilder.Entity<AgreementDiscount>().ToTable("AgreementDiscount");
            //modelBuilder.Entity<AgreementStatus>().ToTable("AgreementStatus");
            modelBuilder.Entity<ContractEntity>().ToTable("Contract");
            modelBuilder.Entity<ProductDefinitionEntity>().ToTable("ProductDefinition");
            //modelBuilder.Entity<ProductUnit>().ToTable("ProductUnit");
            //modelBuilder.Entity<SalesItem>().ToTable("SalesItem");
            //modelBuilder.Entity<Ticket>().ToTable("Ticket");
            modelBuilder.Entity<TicketItemEntity>().ToTable("TicketItem");
            modelBuilder.Entity<AddressEntity>().ToTable("Address");

            // Person
            modelBuilder.Entity<PersonEntity>()
            .ToTable("Person")
            .HasOne(p => p.Parent)
            .WithMany(p => p.Children)
            .HasForeignKey(p => p.ParentId)
            .OnDelete(DeleteBehavior.NoAction);

            // ContractPersonInvolvement
            modelBuilder.Entity<ContractPersonInvolvementEntity>()
            .ToTable("ContractPersonInvolvement")
            .HasOne(cpr => cpr.Role)
            .WithMany()
            .HasForeignKey(cpr => cpr.RoleId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ContractPersonInvolvementEntity>()
            .HasOne(p => p.Person)
            .WithMany()
            .HasForeignKey(p => p.PersonId)
            .OnDelete(DeleteBehavior.NoAction);

            // Product Unit
            modelBuilder.Entity<ProductUnitEntity>()
            .ToTable("ProductUnit")
            .HasOne(cpr => cpr.Product)
            .WithMany()
            .HasForeignKey(cpr => cpr.ProductId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ProductUnitEntity>()
            .HasOne(p => p.Address)
            .WithMany()
            .HasForeignKey(p => p.AddressId)
            .OnDelete(DeleteBehavior.NoAction);

            // Discount type
            modelBuilder.Entity<PriceAgreementEntity>()
            .ToTable("PriceAgreement");
            //.HasOne(cpr => cpr.DiscountType)
            //.WithMany(o => o.DiscountType)
            //.HasForeignKey(cpr => cpr.DiscountTypeId)
            //.OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<PriceAgreementEntity>()
            //.HasOne(pa => pa.DiscountType)
            //.WithMany(o => o.DiscountType)
            //.HasForeignKey(pa => pa.DiscountTypeId);

            //modelBuilder.Entity<PriceAgreementEntity>()
            //    .HasOne(pa => pa.Approver)
            //    .WithMany()
            //    .HasForeignKey(pa => pa.ApproverId)
            //    .OnDelete(DeleteBehavior.NoAction);

            // Status price agreement
            modelBuilder.Entity<PriceAgreementEntity>()
            .ToTable("PriceAgreement")
            .HasOne(cpr => cpr.PriceAgreementStatus)
            .WithMany()
            .HasForeignKey(cpr => cpr.PriceAgreementStatusId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OptionEntity>()
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
            modelBuilder.Entity<ProductDefinitionEntity>()
            .ToTable("ProductDefinition")
            .HasOne(cpr => cpr.ProductDefinitionStatus)
            .WithMany()
            .HasForeignKey(cpr => cpr.ProductDefinitionStatusId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OptionEntity>()
            .HasMany(o => o.ProductDefinitionStatus)
            .WithOne(pd => pd.ProductDefinitionStatus)
            .HasForeignKey(pd => pd.ProductDefinitionStatusId);

            // Sport
            modelBuilder.Entity<ProductDefinitionEntity>()
            .ToTable("ProductDefinition")
            .HasOne(cpr => cpr.ProductDefinitionSport)
            .WithMany()
            .HasForeignKey(cpr => cpr.ProductDefinitionSportId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OptionEntity>()
            .HasMany(o => o.ProductDefinitionSport)
            .WithOne(pd => pd.ProductDefinitionSport)
            .HasForeignKey(pd => pd.ProductDefinitionSportId);

            // ProdutAgreement
            modelBuilder.Entity<ProductAgreementEntity>()
            .ToTable("ProductAgreement")
            .HasOne(cpr => cpr.ProductDefinition)
            .WithMany()
            .HasForeignKey(cpr => cpr.ProductDefinitionId)
            .OnDelete(DeleteBehavior.NoAction);

            //SalesItem
            modelBuilder.Entity<SalesItemEntity>()
            .ToTable("SalesItem")
            .HasOne(s => s.Person)
            .WithMany()
            .HasForeignKey(s => s.PersonId)
            .OnDelete(DeleteBehavior.NoAction);

            //Ticket
            modelBuilder.Entity<TicketEntity>()
            .ToTable("Ticket")
            .HasOne(s => s.Person)
            .WithMany()
            .HasForeignKey(s => s.PersonId)
            .OnDelete(DeleteBehavior.NoAction);

            ////TicketItem
            //modelBuilder.Entity<TicketItem>()
            //.ToTable("TicketItem")
            //.HasOne(s => s.Replier)
            //.WithMany()
            //.HasForeignKey(s => s.ReplierId)
            //.OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<TicketItem>()
            //.HasOne(s => s.Responsible)
            //.WithMany()
            //.HasForeignKey(s => s.ResponsibleId)
            //.OnDelete(DeleteBehavior.NoAction);
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
