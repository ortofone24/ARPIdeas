using System.ComponentModel.DataAnnotations;

namespace AplikacjaARPIdeas.Models
{
    public class Worker
    {
        public Worker()
        {
         
        }

        

        public Worker( int id, string name, string sureName, int age, decimal salary, int identyficationNumber)
        {
            Id = id;
            Name = name;
            SureName = sureName;
            Age = age;
            Salary = salary;
            IdentyficationNumber = identyficationNumber;
        }

        public int Id { get; set; }
        [Display(Name = "Imię")]
        public string Name { get; set; }
        [Display(Name = "Nazwisko")]
        public string SureName { get; set; }
        [Display(Name = "Wiek")]
        public int Age { get; set; }
        [Display(Name = "Wynagrodzenie")]
        public decimal Salary { get; set; }
        [Display(Name = "Numer NIP")]
        public int IdentyficationNumber { get; set; }

    }
}
