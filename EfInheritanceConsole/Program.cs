using EfInheritanceConsole.TPT;
using EfInheritanceConsole.TPT.Entities;
using System;
using System.Linq;

namespace EfInheritanceConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //AddToDb();

            using (var context = new TPTPeopleDbContext())
            {
                foreach (var person in context.People)
                {
                    Console.WriteLine($"Person: {person.Name} Type: {person.GetType().Name}");
                }
            }

            using (var context = new TPTPeopleDbContext())
            {
                foreach (Customer cust in context.People.Where(p => p.GetType() == typeof(Customer)))
                {
                    Console.WriteLine($"Customer: {cust.Name}");
                }

                foreach (Customer cust in context.People.Where(p => p is Customer))
                {
                    Console.WriteLine($"Customer: {cust.Name}");
                }

                foreach (Employee emp in context.People.OfType<Employee>())
                {
                    Console.WriteLine($"Emloyee: {emp.Name}");
                }

            }

            Console.WriteLine("\nPress <ENTER> to exit..");
            Console.ReadLine();
        }

        private static void AddToDb()
        {
            using (var context = new TPTPeopleDbContext())
            {
                var customer = new Customer() { Name = "Kees Klant", CustomerNumber = "Klant 1" };
                var employee = new Employee() { Name = "Willem Werknemer", JobTitle = "Putjesschepper" };
                var person = new Person() { Name = "Piet Persoon" };

                //This way needs a DbSet collection in DbContext
                context.People.Add(person);
                context.People.Add(employee);
                context.People.Add(customer);

                ////This one goes directly on the type to add no need for DbSet in DbContext
                context.Set<Person>().Add(person);
                context.Set<Employee>().Add(employee);
                context.Set<Customer>().Add(customer);

                ////This one goes directly on the type to add
                context.Add(customer);
                context.Add<Customer>(customer);

                context.SaveChanges();
            }
        }
    }
}
