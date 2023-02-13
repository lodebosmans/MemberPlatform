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
                        LastName = "Bosmans"
                    },
                    new Person 
                    {
                        FirstName = "Johnny",
                        LastName = "Urkens"
                    }

                ) ;
                context.SaveChanges();
                context.Relationships.AddRange(
                    new RelationShip
                    {
                        Name = "Partner"
                    }
                    );

                context.SaveChanges();
            }

        }
    }
}
