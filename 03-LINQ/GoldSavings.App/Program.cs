using GoldSavings.App.Client;
using GoldSavings.App.Model;
using GoldSavings.App.Services;
using System.Diagnostics;
namespace GoldSavings.App;

class Program
{
    static void Main(string[] args)
	{
        Func<DateTime, string> isLeapYear = (date) => {
            return DateTime.IsLeapYear(date.Year) ? "Yes" : "No";
        };
		Console.WriteLine("Is it a leap year? " + isLeapYear(DateTime.Now));


		var randomCollection = new RandomCollection<GoldPrice>();

		Console.WriteLine("Generic List test\n");
		Console.WriteLine($"Is the collection empty? {randomCollection.isEmpty()}");
		Console.WriteLine("Adding some gold prices to the collection...");

		randomCollection.Add(new GoldPrice { Date = DateTime.Now, Price = 100 });
		randomCollection.Add(new GoldPrice { Date = DateTime.Now - TimeSpan.FromDays(10), Price = 200 });
		randomCollection.Add(new GoldPrice { Date = DateTime.Now - TimeSpan.FromDays(20), Price = 300 });
		randomCollection.Add(new GoldPrice { Date = DateTime.Now - TimeSpan.FromDays(30), Price = 400 });
		randomCollection.Add(new GoldPrice { Date = DateTime.Now - TimeSpan.FromDays(40), Price = 500 });

		Console.WriteLine($"Is the collection empty? {randomCollection.isEmpty()}");
		GoldResultPrinter.PrintPrice(randomCollection.Get(2), "Retrieving gold prices from the collection:");
	}
}
