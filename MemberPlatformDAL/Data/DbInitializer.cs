using MemberPlatformDAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                        Name = "Format"
                    },
                    new OptionTypeEntity
                    {
                        Name = "Sport"
                    },
                    new OptionTypeEntity
                    {
                        Name = "ContractType"
                    },
                    new OptionTypeEntity
                    {
                        Name = "Role"
                    },
                    new OptionTypeEntity
                    {
                        Name = "PersonRole"
                    },
                    new OptionTypeEntity
                    {
                        Name = "Status"
                    },
                    new OptionTypeEntity
                    {
                        Name = "DocumentType"
                    },
                    new OptionTypeEntity
                    {
                        Name = "Address"
                    },
                    new OptionTypeEntity
                    {
                        Name = "DiscountType"
                    },
                    new OptionTypeEntity
                    {
                        Name = "SalesItem"
                    }
                    );
                context.SaveChanges();
                context.Options.AddRange(
                    new OptionEntity
                    {
                        Name = "Single day event",
                        OptionTypeId = 1,
                    },
                    new OptionEntity
                    {
                        Name = "Triatlon",
                        OptionTypeId = 2,
                    },
                    new OptionEntity
                    {
                        Name = "Runnning",
                        OptionTypeId = 2,
                    },
                    new OptionEntity
                    {
                        Name = "Swimming",
                        OptionTypeId = 2,
                    },
                     new OptionEntity
                     {
                         Name = "Approved",
                         OptionTypeId = 6,
                     },
                    new OptionEntity
                    {
                        Name = "Subscription",
                        OptionTypeId = 3
                    },
                    new OptionEntity
                    {
                        Name = "TrainingFacilities",
                        OptionTypeId = 8
                    },
                    new OptionEntity
                    {
                        Name = "Residential",
                        OptionTypeId = 8
                    },
                    new OptionEntity
                    {
                        Name = "Sponsor reduction",
                        OptionTypeId = 9
                    },
                    new OptionEntity
                    {
                        Name = "Family",
                        OptionTypeId = 9
                    },
                    new OptionEntity
                    {
                        Name = "Pending",
                        OptionTypeId = 6
                    },
                    new OptionEntity
                    {
                        Name = "Bikes",
                        OptionTypeId = 6
                    }


                 ); ;
                context.SaveChanges();
                context.Addresses.AddRange(
                    new AddressEntity
                    {
                        Name = "Boswachtershuis",
                        Street = "Bosstraat",
                        Number = "1",
                        City = "Westerlo",
                        PostalCode = "2260",
                        Country = "België",
                        AddressTypeId = 7,
                    },
                    new AddressEntity
                    {
                        Street = "Zandstraat",
                        Number = "2",
                        City = "Geel",
                        PostalCode = "2440",
                        Country = "België",
                        AddressTypeId = 8,
                    },
                    new AddressEntity
                    {
                        Street = "Bergstraat",
                        Number= "3",
                        City = "Turnhout",
                        PostalCode = "2300",
                        Country = "België",
                        AddressTypeId = 8,
                    }
                    );
                context.SaveChanges();
                context.Persons.AddRange(
                    new PersonEntity
                    {
                        FirstName = "Lode",
                        LastName = "Bosmans",
                        Gender = "male",
                        DateOfBirth = DateTime.Parse("1985-01-01"),
                        InsuranceCompany = "CM",
                        MobilePhone = "0485785013",
                        EmailAddress = "bosmanslode@hotmail.com",
                        IdentityNumber = "85010111991",
                        PrivacyApproval = true,
                        AddressId = 2
                    },
                    new PersonEntity
                    {
                        FirstName = "Ive",
                        LastName = "Verstappen",
                        Gender = "male",
                        DateOfBirth = DateTime.Now,
                        InsuranceCompany = "De Voorzorg",
                        MobilePhone = "0485785011",
                        EmailAddress = "Ive@hotmail.com",
                        IdentityNumber = "75010111991",
                        PrivacyApproval = true,
                        AddressId = 2
                    },new PersonEntity
                    {
                        FirstName = "Johnny",
                        LastName = "Urkens",
                        Gender = "Male",
                        DateOfBirth = DateTime.Parse("1974-04-09"),
                        InsuranceCompany = "De Voorzorg",
                        MobilePhone = "0476989727",
                        EmailAddress = "johnny@gmail.com",
                        IdentityNumber = "71040944569",
                        PrivacyApproval = true,
                        AddressId = 3

                    }
                ); ;
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
                        StartTimeScheduled = DateTime.Now,
                        EndTimeScheduled = DateTime.Now,
                        StartTimeActual = DateTime.Now,
                        EndTimeActual = DateTime.Now,
                        ProductUnitStatusId = 5,
                        ProductId = 1,
                        AddressId = 1
                    }
                    );
                context.SaveChanges();
                context.Contracts.AddRange(
                    new ContractEntity
                    {
                        ContractDate = DateTime.Now,
                        StartDate = DateTime.Now.AddDays(5),
                        EndDate = DateTime.Now.AddDays(50),
                        ContractTypeId = 6,
                    }
                    );
                context.SaveChanges();
                context.ProductAgreements.AddRange(
                    new ProductAgreementEntity
                    {
                        ContractId = 1,
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
                        PriceAgreementStatusId = 5,
                    }
                    );
                context.SaveChanges();
                context.PersonPersonRelations.AddRange(
                    new PersonPersonRelationEntity
                    {
                        ParentId = 1,
                        ChildId = 2,
                        RelationId = 10,
                    }
                    );
                context.SaveChanges();
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

