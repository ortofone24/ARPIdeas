using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplikacjaARPIdeas.Models
{
    public class Worker
    {
        public Worker()
        {
            Id = 0;
            Name = null;
            SureName = null;
            Age = 0;
            Salary = 0;
            IdentyficationNumber = 0;
        }

        

        public Worker( int id, string name, string sureName, int age, decimal salary, float identyficationNumber)
        {
            Id = id;
            Name = name;
            SureName = sureName;
            Age = age;
            Salary = salary;
            IdentyficationNumber = identyficationNumber;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string SureName { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public float IdentyficationNumber { get; set; }

    }
}
