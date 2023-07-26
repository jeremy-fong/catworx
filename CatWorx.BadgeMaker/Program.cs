using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatWorx.BadgeMaker
{
  class Program
  {
    static List<Employee> GetEmployees()
    {
        List<Employee> employees = new List<Employee>();
        while (true)
        {
        Console.WriteLine("Please enter a name: (leave empty to exit): ");
        string firstName = Console.ReadLine() ?? "";
        if (firstName == "")
        {
            break;
        }
        Console.WriteLine("Enter last name: ");
        string lastName = Console.ReadLine() ?? "";
        Console.WriteLine("Enter ID: ");
        int id = Int32.Parse(Console.ReadLine() ?? "");
        Console.WriteLine("Enter Photo URL: ");
        string photoUrl = Console.ReadLine() ?? "";
        // Create a new Employee instance
        Employee currentEmployee = new Employee(firstName, lastName, id, photoUrl);
          // Add currentEmployee, not a string
        employees.Add(currentEmployee);
        }
        return employees;
    }
    async static Task Main(string[] args)
    {
        List<Employee> employees = GetEmployees();
        Util.PrintEmployees(employees);
        Util.MakeCSV(employees);
        await Util.MakeBadges(employees);
    }
  }
}