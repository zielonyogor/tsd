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

        public static void PrintPrice(GoldPrice price, string title)
        {
			Console.WriteLine($"\n--- {title} ---");
			Console.WriteLine($"{price.Date:yyyy-MM-dd} - {price.Price} PLN");
		}
	}
}