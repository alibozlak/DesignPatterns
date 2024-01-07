namespace Prototype
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee1 = new Employee
            {
                Id = 1,
                FirstName = "Engin",
                LastName = "Demiroğ",
                Salay = 78000
            };

            Employee employee2 = (Employee) employee1.Clone();
            employee2.FirstName = "Salih";

            Console.WriteLine(employee1.FirstName);
            Console.WriteLine(employee2.FirstName);
        }
    }

    public abstract class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName{ get; set; }

        public abstract Person Clone();
    }

    public class Employee : Person
    {
        public decimal Salay { get; set; }

        public override Person Clone()
        {
            return (Person) MemberwiseClone();
        }
    }
}
