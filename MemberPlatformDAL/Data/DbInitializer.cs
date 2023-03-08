using MemberPlatformDAL.Models;
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

                context.Persons.AddRange(
                    new Person
                    {
                        FirstName = "Lode",
                        LastName = "Bosmans",
                        Street = "Kerkstraat",
                        HouseNumber = "4",
                        Box = "3",
                        PostalCode = "2440",
                        City = "Geel",
                        Country = "België",
                        Gender = "male",
                        DateOfBirth = DateTime.Now,
                        InsuranceCompany = "CM",
                        MobilePhone = "0485785013",
                        EmailAddress = "bosmanslode@hotmail.com",
                        IdentityNumber = "85010111991",
                        PrivacyApproval = true
                    },
                    new Person
                    {
                        FirstName = "Lode",
                        LastName = "Bosmans",
                        Street = "Broekstraat",
                        HouseNumber = "14",
                        Box = "2",
                        PostalCode = "2260",
                        City = "Westerlo",
                        Country = "België",
                        Gender = "male",
                        DateOfBirth = DateTime.Now,
                        InsuranceCompany = "De Voorzorg",
                        MobilePhone = "0485785011",
                        EmailAddress = "Lode@hotmail.com",
                        IdentityNumber = "75010111991",
                        PrivacyApproval = true
                    }
                );
                context.SaveChanges();
                context.OptionTypes.AddRange(
                    new OptionType
                    {
                        Name = "Format"
                    },
                    new OptionType
                    {
                        Name = "Sport"
                    },
                    new OptionType
                    {
                        Name = "ContractType"
                    },
                    new OptionType
                    {
                        Name = "Role"
                    },
                    new OptionType
                    {
                        Name = "PersonRole"
                    },
                    new OptionType
                    {
                        Name = "Status"
                    },
                    new OptionType
                    {
                        Name = "DocumentType"
                    }
                    );
                context.SaveChanges();
                context.Options.AddRange(
                    new Option
                    {
                        Name = "Single day event",
                        OptionTypeId = 1,
                    },
                    new Option
                    {
                        Name = "Triatlon",
                        OptionTypeId = 2,
                    },
                    new Option
                    {
                        Name = "Runnning",
                        OptionTypeId = 2,
                    },
                    new Option
                    {
                        Name = "Swimming",
                        OptionTypeId = 2,
                    },
                     new Option
                     {
                         Name = "Approved",
                         OptionTypeId = 6,
                     },
                    new Option
                    {
                        Name = "Subscription",
                        OptionTypeId = 3
                    }
                 ); ;
                context.SaveChanges();
                context.ProductDefinitions.AddRange(

             new ProductDefinition
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
            new ProductDefinition
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
                    new ProductUnit
                    {
                        Date = DateTime.Now,
                        Comment = "looptrainingen",
                        Location = "boswachtershuis",
                        StartTimeScheduled = DateTime.Now,
                        EndTimeScheduled = DateTime.Now,
                        StartTimeActual = DateTime.Now,
                        EndTimeActual = DateTime.Now,
                        ProductUnitStatusId = 5,
                        ProductId=1,
                    }
                    );
                context.SaveChanges();
                context.Contracts.AddRange(
                    new Contract
                    {
                        ContractDate = DateTime.Now,
                        StartDate = DateTime.Now.AddDays(5),
                        EndDate = DateTime.Now.AddDays(50),
                        ContractTypeId = 6,
                    }
                    );
                context.SaveChanges();
                context.ProductAgreements.AddRange(
                    new ProductAgreement
                    {
                        ContractId = 1,
                        ProductDefinitionId = 1,
                    }
                    );
                context.ContractPersonInvolvements.AddRange(
                    new ContractPersonInvolvement
                    {
                        ContractId = 1,
                        PersonId = 1,
                        RoleId = 6,

                    }
                    );

            };



        


            }

        }
    }

