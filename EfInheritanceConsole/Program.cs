using EfInheritanceConsole.TPT;
using EfInheritanceConsole.TPT.Entities;
using System;

namespace EfInheritanceConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new TPTPeopleDbContext())
            {
                var customer = new Customer() { Name = "Kees Klant", CustomerNumber = "Klant 1" };
                var employee = new Employee() { Name = "Willem Werknemer", JobTitle = "Putjesschepper" };
                var person = new Person() { Name = "Piet Persoon"};

                //This way needs a collection
                context.People.Add(person);
                context.People.Add(employee);
                context.People.Add(customer);

                ////This one goes directly on the type to add
                //context.Set<Person>().Add(person);
                //context.Set<Employee>().Add(employee);
                //context.Set<Customer>().Add(customer);

                context.SaveChanges();
            }

            Console.WriteLine("\nPress <ENTER> to exit..");
            Console.ReadLine();
        }
    }
}
