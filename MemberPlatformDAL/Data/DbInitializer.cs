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
            }

        }
    }
}
