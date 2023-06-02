using MemberPlatformDAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MemberPlatformDAL.Data
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DataContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<DataContext>>()))
            {
                //if (context.Persons.Any())
                //{
                //    return;   // DB has been seeded
                //}
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.OptionTypes.AddRange(
                    new OptionTypeEntity
                    {
                        // id = 1
                        Name = "Format"
                    },
                    new OptionTypeEntity
                    {
                        // id = 2
                        Name = "Sport"
                    },
                    // Contract type (Subscription, trainer, sponsor, admin)
                    new OptionTypeEntity
                    {
                        // id = 3
                        Name = "ContractType"
                    },
                    // Contract involvement role (Westfit, sponsor, participant, trainer)
                    new OptionTypeEntity
                    {
                        // id = 4
                        Name = "Role"
                    },
                    // Platform role (member, trainer, admin)
                    new OptionTypeEntity
                    {
                        // id = 5
                        Name = "PlatformRole"
                    },
                    new OptionTypeEntity
                    {
                        // id = 6
                        Name = "Status"
                    },
                    new OptionTypeEntity
                    {
                        // id = 7
                        Name = "DocumentType"
                    },
                    new OptionTypeEntity
                    {
                        // id = 8
                        Name = "Address"
                    },
                    new OptionTypeEntity
                    {
                        // id = 9
                        Name = "DiscountType"
                    },
                    new OptionTypeEntity
                    {
                        // id = 10
                        Name = "SalesItem"
                    }
                    );
                context.SaveChanges();

                context.Options.AddRange(
                    // Type of events
                    new OptionEntity
                    {
                        // id = 1
                        Name = "Single day event",
                        OptionTypeId = 1,
                    },
                    new OptionEntity
                    {
                        // id = 2
                        Name = "Multi day event",
                        OptionTypeId = 1,
                    },
                    new OptionEntity
                    {
                        // id = 3
                        Name = "Training series",
                        OptionTypeId = 1,
                    },

                    // Sports
                    new OptionEntity
                    {
                        // id = 4
                        Name = "Triatlon",
                        OptionTypeId = 2,
                    },
                    new OptionEntity
                    {
                        // id = 5
                        Name = "Runnning",
                        OptionTypeId = 2,
                    },
                    new OptionEntity
                    {
                        // id = 6
                        Name = "Swimming",
                        OptionTypeId = 2,
                    },
                    new OptionEntity
                    {
                        // id = 7
                        Name = "Mountainbike",
                        OptionTypeId = 2,
                    },
                    new OptionEntity
                    {
                        // id = 8
                        Name = "Start to triatlon",
                        OptionTypeId = 2,
                    },

                    // Contract types
                    new OptionEntity
                    {
                        // id = 9
                        Name = "Subscription",
                        OptionTypeId = 3
                    },
                    new OptionEntity
                    {
                        // id = 10
                        Name = "Trainer",
                        OptionTypeId = 3
                    },
                    new OptionEntity
                    {
                        // id = 11
                        Name = "Sponsor",
                        OptionTypeId = 3
                    },
                    new OptionEntity
                    {
                        // id = 12
                        Name = "Admin",
                        OptionTypeId = 3
                    },

                    // Involvement roles
                    new OptionEntity
                    {
                        // id = 13
                        Name = "Participant",
                        OptionTypeId = 4
                    },
                    new OptionEntity
                    {
                        // id = 14
                        Name = "Trainer",
                        OptionTypeId = 4
                    },
                    new OptionEntity
                    {
                        // id = 15
                        Name = "Sponsor",
                        OptionTypeId = 4
                    },
                    new OptionEntity
                    {
                        // id = 16
                        Name = "Westfit",
                        OptionTypeId = 4
                    },

                    // Platform roles
                    new OptionEntity
                    {
                        // id = 17
                        Name = "Member",
                        OptionTypeId = 5
                    },
                    new OptionEntity
                    {
                        // id = 18
                        Name = "Trainer",
                        OptionTypeId = 5
                    },
                    new OptionEntity
                    {
                        // id = 19
                        Name = "Admin",
                        OptionTypeId = 5
                    },

                    // Statuses
                    new OptionEntity
                    {
                        // id = 20
                        Name = "Submitted",
                        OptionTypeId = 6,
                    },
                    new OptionEntity
                    {
                        // id = 21
                        Name = "Cancelled",
                        OptionTypeId = 6,
                    },
                    new OptionEntity
                    {
                        // id = 22
                        Name = "Approved",
                        OptionTypeId = 6,
                    },
                    new OptionEntity
                    {
                        // id = 23
                        Name = "Not approved",
                        OptionTypeId = 6,
                    },
                    new OptionEntity
                    {
                        // id = 24
                        Name = "Action needed",
                        OptionTypeId = 6,
                    },
                    new OptionEntity
                    {
                        // id = 25
                        Name = "Pending",
                        OptionTypeId = 6
                    },

                    // Address types
                    new OptionEntity
                    {
                        // id = 26
                        Name = "Training facility",
                        OptionTypeId = 8
                    },
                    new OptionEntity
                    {
                        // id = 27
                        Name = "Residential",
                        OptionTypeId = 8
                    },

                    // Reduction types
                    new OptionEntity
                    {
                        // id = 28
                        Name = "Sponsor reduction",
                        OptionTypeId = 9
                    },
                    // Sales item types
                    new OptionEntity
                    {
                        // id = 29
                        Name = "Bikes",
                        OptionTypeId = 10
                    },
                    new OptionEntity
                    {
                        // id = 30
                        Name = "Bike shoes",
                        OptionTypeId = 10
                    },
                    new OptionEntity
                    {
                        // id = 31
                        Name = "Trisuit",
                        OptionTypeId = 10
                    },
                    new OptionEntity
                    {
                        // id = 32
                        Name = "Wetsuit",
                        OptionTypeId = 10
                    }
                 );
                context.SaveChanges();

                context.Addresses.AddRange(
                    new AddressEntity
                    {
                        // id = 1
                        Name = "Boswachtershuis",
                        Street = "Bosstraat",
                        Number = "1",
                        City = "Westerlo",
                        PostalCode = "2260",
                        Country = "België",
                        AddressTypeId = 26,
                    },
                    new AddressEntity
                    {
                        // id = 2
                        Street = "Kerkstraat",
                        Number = "4",
                        Box = "3",
                        City = "Geel",
                        PostalCode = "2440",
                        Country = "België",
                        AddressTypeId = 27,
                    },
                    new AddressEntity
                    {
                        // id = 3
                        Street = "Bergstraat",
                        Number = "3",
                        City = "Turnhout",
                        PostalCode = "2300",
                        Country = "België",
                        AddressTypeId = 27,
                    },
                    new AddressEntity
                    {
                        // id = 4
                        Street = "Lennostraat",
                        Number = "4",
                        Box = "3",
                        City = "Geel",
                        PostalCode = "2440",
                        Country = "België",
                        AddressTypeId = 27,
                    },
                    new AddressEntity
                    {
                        // id = 5
                        Street = "Lyasstraat",
                        Number = "4",
                        Box = "3",
                        City = "Geel",
                        PostalCode = "2440",
                        Country = "België",
                        AddressTypeId = 27,
                    },
                    new AddressEntity
                    {
                        // id = 6
                        Street = "Westfit Admin straat",
                        Number = "1",
                        Box = "1",
                        City = "Geel",
                        PostalCode = "2440",
                        Country = "België",
                        AddressTypeId = 27,
                    },
                    new AddressEntity
                    {
                        // id = 7
                        Street = "Westfit Member straat",
                        Number = "1",
                        Box = "2",
                        City = "Geel",
                        PostalCode = "2440",
                        Country = "België",
                        AddressTypeId = 27,
                    });
                context.SaveChanges();

                context.Persons.AddRange(
                    new PersonEntity
                    {
                        // id = 1
                        FirstName = "Lode",
                        LastName = "Bosmans",
                        Gender = "male",
                        DateOfBirth = DateTime.Parse("1985-01-01"),
                        InsuranceCompany = "CM",
                        MobilePhone = "0485785013",
                        EmailAddress = "bosmanslode@gmail.com",
                        IdentityNumber = "85010111991",
                        PrivacyApproval = true,
                        AddressId = 2,
                        ParentId = null
                    },
                    new PersonEntity
                    {
                        // id = 2
                        FirstName = "Ive",
                        LastName = "Verstappen",
                        Gender = "male",
                        DateOfBirth = DateTime.Now,
                        InsuranceCompany = "De Voorzorg",
                        MobilePhone = "0485785011",
                        EmailAddress = "Ive@hotmail.com",
                        IdentityNumber = "75010111991",
                        PrivacyApproval = true,
                        AddressId = 2,
                        ParentId = null
                    }, new PersonEntity
                    {
                        // id = 3
                        FirstName = "Johnny",
                        LastName = "Urkens",
                        Gender = "Male",
                        DateOfBirth = DateTime.Parse("1974-04-09"),
                        InsuranceCompany = "De Voorzorg",
                        MobilePhone = "0476989727",
                        EmailAddress = "be90242@gmail.com",
                        IdentityNumber = "71040944569",
                        PrivacyApproval = true,
                        AddressId = 3,
                        ParentId = null
                    }, new PersonEntity
                    {
                        // id = 4
                        FirstName = "Admin",
                        LastName = "Westfit",
                        Gender = "Female",
                        DateOfBirth = DateTime.Parse("1979-01-01"),
                        InsuranceCompany = "CM",
                        MobilePhone = "0495123456",
                        EmailAddress = "admin@westfit.com",
                        IdentityNumber = "01234567890",
                        PrivacyApproval = true,
                        AddressId = 6,
                        ParentId = null
                    }, new PersonEntity
                    {
                        // id = 5
                        FirstName = "Member",
                        LastName = "Westfit",
                        Gender = "Male",
                        DateOfBirth = DateTime.Parse("1983-01-01"),
                        InsuranceCompany = "CM",
                        MobilePhone = "0495654321",
                        EmailAddress = "member@westfit.com",
                        IdentityNumber = "09876543210",
                        PrivacyApproval = true,
                        AddressId = 7,
                        ParentId = null
                    },
                    new PersonEntity
                    {
                        // id = 6
                        FirstName = "Lenno",
                        LastName = "Bosmans",
                        Gender = "male",
                        DateOfBirth = DateTime.Parse("2015-01-01"),
                        InsuranceCompany = "CM",
                        MobilePhone = "0485785013",
                        EmailAddress = null,
                        IdentityNumber = "85010111991",
                        PrivacyApproval = true,
                        AddressId = 4,
                        ParentId = 1
                    },
                    new PersonEntity
                    {
                        // id = 7
                        FirstName = "Lyas",
                        LastName = "Bosmans",
                        Gender = "male",
                        DateOfBirth = DateTime.Parse("2010-01-01"),
                        InsuranceCompany = "CM",
                        MobilePhone = "0485785013",
                        EmailAddress = null,
                        IdentityNumber = "85010111991",
                        PrivacyApproval = true,
                        AddressId = 5,
                        ParentId = 1
                    },
                     new PersonEntity
                     {
                         // id = 8
                         FirstName = "Emiel",
                         LastName = "Urkens",
                         Gender = "male",
                         DateOfBirth = DateTime.Parse("2015-03-12"),
                         InsuranceCompany = "Solidaris",
                         MobilePhone = "0485785013",
                         EmailAddress = null,
                         IdentityNumber = "85010111991",
                         PrivacyApproval = true,
                         AddressId = 3,
                         ParentId = 3
                     },
                    new PersonEntity
                    {
                        // id = 9
                        FirstName = "Warre",
                        LastName = "Urkens",
                        Gender = "male",
                        DateOfBirth = DateTime.Parse("2008-01-01"),
                        InsuranceCompany = "Solidaris",
                        MobilePhone = "0485785013",
                        EmailAddress = null,
                        IdentityNumber = "85010111991",
                        PrivacyApproval = true,
                        AddressId = 3,
                        ParentId = 3
                    }
                );
                context.SaveChanges();

                context.ProductDefinitions.AddRange(
                     new ProductDefinitionEntity
                     {
                         Name = "Triatlon",
                         Description = "Start to triatlon",
                         StartDate = DateTime.Parse("2022-01-01"),
                         EndDate = DateTime.Parse("2022-12-31"),
                         NumberOfSessions = 10,
                         MaxAmountMembers = 50,
                         Price = 100,
                         SubscriptionOpening = DateTime.Parse("2021-12-01"),
                         SubscriptionClosing = DateTime.Parse("2021-12-31"),

                         ProductDefinitionStatusId = 5,
                         ProductDefinitionFormatId = 1,
                         ProductDefinitionSportId = 2
                     });
                context.SaveChanges();
                context.ProductDefinitions.AddRange(
            new ProductDefinitionEntity
            {
                Name = "Running",
                Description = "Running",
                StartDate = DateTime.Parse("2022-02-01"),
                EndDate = DateTime.Parse("2022-12-31"),
                NumberOfSessions = 5,
                MaxAmountMembers = 20,
                Price = 50,
                SubscriptionOpening = DateTime.Parse("2022-01-01"),
                SubscriptionClosing = DateTime.Parse("2022-01-31"),
                ParentProductDefinitionId = 1,
                ProductDefinitionStatusId = 5,
                ProductDefinitionFormatId = 1,
                ProductDefinitionSportId = 3
            });
                context.SaveChanges();
                context.ProductUnits.AddRange(
                    new ProductUnitEntity
                    {
                        Date = DateTime.Now,
                        Comment = "looptrainingen",
                        StartTimeScheduled = new TimeSpan(9, 0, 0),
                        EndTimeScheduled = new TimeSpan(10, 0, 0),
                        StartTimeActual = new TimeSpan(18, 0, 0),
                        EndTimeActual = new TimeSpan(19, 0, 0),
                        ProductUnitStatusId = 5,
                        ProductId = 1,
                        AddressId = 1
                    }
                    );
                context.SaveChanges();
                context.Contracts.AddRange(
                    new ContractEntity
                    {
                        // id = 1
                        ContractDate = DateTime.Now,
                        StartDate = new DateTime(2023, 1, 1),
                        EndDate = new DateTime(2023, 12, 31),
                        ContractTypeId = 9,
                    },
                    new ContractEntity
                    {
                        // id = 2
                        ContractDate = new DateTime(2022, 02, 20),
                        StartDate = new DateTime(2023, 1, 1),
                        EndDate = new DateTime(2023, 12, 31),
                        ContractTypeId = 9,
                    },
                    new ContractEntity
                    {
                        // id = 3
                        ContractDate = new DateTime(2022, 02, 20),
                        StartDate = new DateTime(2023, 1, 1),
                        EndDate = new DateTime(2023, 12, 31),
                        ContractTypeId = 9,
                    },
                    new ContractEntity
                    {
                        // id = 4
                        // Contract Lode
                        ContractDate = new DateTime(2023, 02, 20),
                        StartDate = new DateTime(2023, 1, 1),
                        EndDate = new DateTime(2099, 12, 31),
                        ContractTypeId = 12,
                    },
                    new ContractEntity
                    {
                        // id = 5
                        // Contract Johnny
                        ContractDate = new DateTime(2023, 02, 20),
                        StartDate = new DateTime(2023, 1, 1),
                        EndDate = new DateTime(2099, 12, 31),
                        ContractTypeId = 12,
                    },
                    new ContractEntity
                    {
                        // id = 6
                        // Contract Admin westfit
                        ContractDate = new DateTime(2023, 02, 20),
                        StartDate = new DateTime(2023, 1, 1),
                        EndDate = new DateTime(2099, 12, 31),
                        ContractTypeId = 12,
                    },
                    new ContractEntity
                    {
                        // id = 7
                        // Contract member westfit
                        ContractDate = new DateTime(2023, 02, 20),
                        StartDate = new DateTime(2023, 1, 1),
                        EndDate = new DateTime(2099, 12, 31),
                        ContractTypeId = 12,
                    }
                    );
                context.SaveChanges();
                context.ProductAgreements.AddRange(
                    new ProductAgreementEntity
                    {
                        ContractId = 1,
                        ProductDefinitionId = 1,
                    },
                    new ProductAgreementEntity
                    {
                        ContractId = 2,
                        ProductDefinitionId = 2,
                    },
                    new ProductAgreementEntity
                    {
                        ContractId = 3,
                        ProductDefinitionId = 1,
                    }
                    );
                context.SaveChanges();
                context.ContractPersonInvolvements.AddRange(
                    new ContractPersonInvolvementEntity
                    {
                        ContractId = 1,
                        PersonId = 1,
                        RoleId = 6,
                    },
                    new ContractPersonInvolvementEntity
                    {
                        ContractId = 2,
                        PersonId = 8,
                        RoleId = 6,
                    },
                    new ContractPersonInvolvementEntity
                    {
                        ContractId = 3,
                        PersonId = 9,
                        RoleId = 6,
                    },
                    new ContractPersonInvolvementEntity
                    {
                        // Contract Lode admin
                        ContractId = 4,
                        PersonId = 1,
                        RoleId = 19,
                    },
                    new ContractPersonInvolvementEntity
                    {
                        // Contract Johnny admin
                        ContractId = 5,
                        PersonId = 3,
                        RoleId = 19,
                    },
                    new ContractPersonInvolvementEntity
                    {
                        // Contract westfit admin
                        ContractId = 6,
                        PersonId = 4,
                        RoleId = 19,
                    },
                    new ContractPersonInvolvementEntity
                    {
                        // Contract westfit member
                        ContractId = 7,
                        PersonId = 5,
                        RoleId = 17,
                    }
                    );
                context.SaveChanges();
                context.PriceAgreements.AddRange(
                    new PriceAgreementEntity
                    {
                        DiscountAmount = 10,
                        PriceBillable = 150,
                        StructuredMessage = "Message",
                        PaymentDate = DateTime.Now.AddDays(30),
                        Comment = "Commentaar",
                        ContractId = 1,
                        DiscountTypeId = 9,
                        ApproverId = 1,
                        PriceAgreementStatusId = 16,
                    },
                    new PriceAgreementEntity
                    {
                        DiscountAmount = 10,
                        PriceBillable = 150,
                        StructuredMessage = "Message",
                        PaymentDate = DateTime.Now.AddDays(30),
                        Comment = "Commentaar",
                        ContractId = 2,
                        DiscountTypeId = 9,
                        ApproverId = 1,
                        PriceAgreementStatusId = 16,
                    },
                    new PriceAgreementEntity
                    {
                        DiscountAmount = 10,
                        PriceBillable = 150,
                        StructuredMessage = "Message",
                        PaymentDate = DateTime.Now.AddDays(30),
                        Comment = "geupdate",
                        ContractId = 1,
                        DiscountTypeId = 9,
                        ApproverId = 1,
                        PriceAgreementStatusId = 18,
                    },
                    new PriceAgreementEntity
                    {
                        DiscountAmount = 10,
                        PriceBillable = 150,
                        StructuredMessage = "Message",
                        PaymentDate = DateTime.Now.AddDays(30),
                        Comment = "geupdate",
                        ContractId = 2,
                        DiscountTypeId = 9,
                        ApproverId = 1,
                        PriceAgreementStatusId = 18,
                    }
                    );
                context.SaveChanges();
                //context.PersonPersonRelations.AddRange(
                //    new PersonPersonRelationEntity
                //    {
                //        ParentId = 1,
                //        ChildId = 2,
                //        RelationId = 10,
                //    }
                //    );
                //context.SaveChanges();
                //context.PersonPersonRelations.AddRange(
                //    new PersonPersonRelationEntity
                //    {
                //        ParentId = 1,
                //        ChildId = 2,
                //        RelationId = 10,
                //    }
                //    );
                //context.SaveChanges();
                context.Tickets.AddRange(
                    new TicketEntity
                    {
                        PersonId = 1,
                    }
                    );
                context.SaveChanges();
                context.TicketItems.AddRange(
                    new TicketItemEntity
                    {
                        Message = "Question of a member",
                        ReplierId = 1,
                        ResponsibleId = 1,
                        TicketItemStatusId = 11,
                        TicketId = 1,
                    }
                    );
                context.SaveChanges();
                context.SalesItems.AddRange(
                    new SalesItemEntity
                    {
                        Name = "koersfiets",
                        Description = "kinderfiets maat 10",
                        Price = 150,
                        EndDate = DateTime.Now.AddDays(30),
                        SalesItemTypeId = 1,
                        PersonId = 1,
                    }
                    );
            };
        }
    }
}
