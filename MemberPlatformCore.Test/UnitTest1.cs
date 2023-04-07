using AutoMapper;
using MemberPlatformCore.Models;
using MemberPlatformCore.Services;
using MemberPlatformDAL.Entities;
using MemberPlatformDAL.Repositories;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace MemberPlatformCore.Test
{
    public class Tests
    {
        private PersonEntity GetDummyPerson()
        {
            return new PersonEntity
            {
                FirstName = "Jan",
                LastName = "Jansen",
                Gender = "Male",
                Address = new AddressEntity() { City = "Geel", Street = "Kerkstraat", Number = "4" }
            };
        }
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            Assert.Fail();
        }
        [Test]
        public void WhenAddingTwoByTwo_ThenResultShouldBeFour()
        {
            //Arrange (hier verzamelen we alle nodige data)
            int a = 2;
            int b = 2;

            //Act (Methode die we testen)
            int result = a + b;
            //Assert (Is het resultaat van de act wat we verwachten)
            Assert.AreEqual(4, result);

        }

        [Test]
        public async Task WhenRetrievingUserForDatabase_ThenUserIsMappedCorrect()
        {
            //Arrange
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            IMapper mapper = config.CreateMapper();
            // Mock van de repository = cardboard
            Mock<IPersonRepository> mock = new Mock<IPersonRepository>();
            // Als de functie opgeroepen wordt met eender welke integer, geef dan de dummy person terug.
            mock.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(GetDummyPerson);
            IPersonService service = new PersonService(mock.Object, mapper);

            //Act
            Person personResult = await service.GetPersonAsync(1);

            //Assert
            Assert.IsNotNull(personResult);
            Assert.AreEqual("Kerkstraat", personResult.Street);
            Assert.AreEqual("Jan Jansen", personResult.FullName);
            
        }
    }
}
