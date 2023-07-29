using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatWorx.BadgeMaker
{
  class Program
  {
    async static Task Main(string[] args)
    {
        List<Employee> employees = new List<Employee>();

        Console.WriteLine("Welcome to the CatWorx BadgeMaker Program!");
        Console.WriteLine("Do you want to manually enter employees? (Enter Y or y to proceed or leave blank to proceed with random data)");
        string answer = Console.ReadLine() ?? "";
        if (answer == "y" || answer == "Y")
        {
          employees = PeopleFetcher.GetEmployees();
        }
        else
        {
          Console.WriteLine("Generating 10 badges using an API that provides random data");
          employees = await PeopleFetcher.GetFromApi();
        }
        Util.PrintEmployees(employees);
        Util.MakeCSV(employees);
        await Util.MakeBadges(employees);
        Console.WriteLine("Badges and CSV files complete, check data folder");
    }
  }
}