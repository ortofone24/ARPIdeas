using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AplikacjaARPIdeas.Models;
using AplikacjaARPIdeas.Repositories;
using Moq;
using Xunit;
using System.Collections.Generic;

namespace AplikacjaARPIdeas.Tests
{
    public class WorkerReposiotoryTests
    {
        [Fact]
        public void ValidateWorkerId()
        {

            var worker = new Mock<Worker>
            worker.Object

            Action act = () =>
            {
                var work = new Worker();
                Assert.Equal(1, work.Id);
                Assert.Equal("zxc", work.Name);
            };

           

            //Arrange
            //var mock = new Mock<WorkerRepository>();
            //mock.Object.GetWorkersById(1).Name = ";
            //mock.Setup(m => m.GetAllWorkers()).Returns((new Worker[]
            //{
            //    new Worker{Id = 1, Age = 54, IdentyficationNumber = 4567457, Name = "Jan", Salary = 34554, SureName = "Kowalski"},
            //    new Worker{Id = 2, Age = 34, IdentyficationNumber = 434237457, Name = "Johb", Salary = 3234554, SureName = "Jankowski"},
            //}).AsEnumerable());


            //Action zxc = () =>
            //{

            //};


        }


    }
}
