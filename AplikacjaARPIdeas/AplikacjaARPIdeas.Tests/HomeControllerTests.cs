using AplikacjaARPIdeas.Models;
using AplikacjaARPIdeas.Repositories;
using Moq;
using Xunit;

namespace AplikacjaARPIdeas.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void GetWorkerById()
        {
            var mock = new Mock<IWorkerRepository>();
            mock.Setup(m => m.GetWorkersById(1)).Returns(new Worker
            {
                Id = 1,
                Age = 34,
                IdentyficationNumber = 24524524,
                Name = "Jan",
                Salary = 245245,
                SureName = "Kowalski"
            });


            var result = mock.Object.GetWorkersById(1).Id;
            var result2 = mock.Object.GetWorkersById(1).Age;
            var result3 = mock.Object.GetWorkersById(1).IdentyficationNumber;
            var result4 = mock.Object.GetWorkersById(1).Name;
            var result5 = mock.Object.GetWorkersById(1).Salary;
            var result6 = mock.Object.GetWorkersById(1).SureName;

            Assert.Equal(1, result);
            Assert.Equal(34, result2);
            Assert.Equal(24524524, result3);
            Assert.Equal("Jan", result4);
            Assert.Equal(245245, result5);
            Assert.Equal("Kowalski", result6);
        }
        
    }
}
