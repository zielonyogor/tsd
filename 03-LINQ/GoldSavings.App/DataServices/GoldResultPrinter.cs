using GoldSavings.App.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GoldSavings.App.Services
{
    public static class GoldResultPrinter
    {
        public static void PrintPrices(List<GoldPrice> prices, string title)
        {
            Console.WriteLine($"\n--- {title} ---");
            foreach (var price in prices)
            {
                Console.WriteLine($"{price.Date:yyyy-MM-dd} - {price.Price} PLN");
            }
        }

		public static void PrintSingleValue<T>(T value, string title)
        {
            Console.WriteLine($"\n{title}: {value}");
        }

        public static void PrintDates(List<DateTime> dates, string title)
        {
            Console.WriteLine($"\n--- {title} ---");
            foreach (var date in dates)
            {
                Console.WriteLine($"{date:yyyy-MM-dd}");
            }
		}

        public static void PrintTwoDates(Tuple<DateTime, DateTime> datePair, string title)
        {
            Console.WriteLine($"\n{title}:");
            Console.WriteLine($"{datePair.Item1:yyyy-MM-dd} <--> {datePair.Item2:yyyy-MM-dd}");
		}
	}
}