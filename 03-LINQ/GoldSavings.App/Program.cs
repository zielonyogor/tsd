using GoldSavings.App.Model;
using GoldSavings.App.Client;
using GoldSavings.App.Services;
using GoldSavings.App.DataServices;
namespace GoldSavings.App;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, Gold Investor!");

        // Step 1: Get gold prices
        GoldDataService dataService = new GoldDataService();
        DateTime startDate = new DateTime(2025,03,17);
        DateTime endDate = DateTime.Now;
        List<GoldPrice> goldPrices = dataService.GetGoldPrices(startDate, endDate).GetAwaiter().GetResult();

        if (goldPrices.Count == 0)
        {
            Console.WriteLine("No data found. Exiting.");
            return;
        }

        Console.WriteLine($"Retrieved {goldPrices.Count} records. Ready for analysis.");

		var jan2020Date = new DateTime(2020, 1, 1);
		var priceJan2020 = dataService.GetGoldPrices(jan2020Date, jan2020Date.AddDays(1)).GetAwaiter().GetResult().FirstOrDefault();

        var prices2019_2022 = dataService.GetGoldPrices(new DateTime(2019, 1, 1), new DateTime(2022, 12, 31)).GetAwaiter().GetResult();
		Console.WriteLine($"Retrieved {prices2019_2022.Count} records from 2019-2022. Ready for analysis.");

        var prices_2020 = dataService.GetGoldPrices(new DateTime(2020, 1, 1), new DateTime(2020, 12, 31)).GetAwaiter().GetResult();
        var prices_2023 = dataService.GetGoldPrices(new DateTime(2023, 1, 1), new DateTime(2023, 12, 31)).GetAwaiter().GetResult();
        var prices_2024 = dataService.GetGoldPrices(new DateTime(2024, 1, 1), new DateTime(2024, 12, 31)).GetAwaiter().GetResult();

        var prices_2020_2024 = dataService.GetGoldPrices(new DateTime(2020, 1, 1), new DateTime(2024, 12, 31)).GetAwaiter().GetResult();

		// Step 2: Perform analysis
		GoldAnalysisService analysisService = new GoldAnalysisService(goldPrices);
        var avgPrice = analysisService.GetAveragePrice();

        var maxPrice = analysisService.GetMaxPrice();
        var minPrice = analysisService.GetMinPrice();
        var maxPriceQuery = analysisService.GetMaxPriceQuery();
        var minPriceQuery = analysisService.GetMinPriceQuery();

		var bestDays = analysisService.BestDaysToSell(priceJan2020.Price, 5);

		GoldAnalysisService analysisService_2019_2022 = new GoldAnalysisService(prices2019_2022);
        var dates_2019_2022 = analysisService_2019_2022.Get3DatesFromStartOf2ndTenRanking();

        GoldAnalysisService analysisService_2020 = new GoldAnalysisService(prices_2020);
        var price_2020 = analysisService_2020.GetAveragePriceQuery();
        GoldAnalysisService analysisService_2023 = new GoldAnalysisService(prices_2023);
        var price_2023 = analysisService_2023.GetAveragePriceQuery();
        GoldAnalysisService analysisService_2024 = new GoldAnalysisService(prices_2024);
        var price_2024 = analysisService_2024.GetAveragePriceQuery();

        GoldAnalysisService analysisService_2020_2024 = new GoldAnalysisService(prices_2020_2024);
        var best = analysisService_2020_2024.GetBestToBuyAndSell();

		// Step 3: Print results
		GoldResultPrinter.PrintSingleValue(Math.Round(avgPrice, 2), "Average Gold Price Last Half Year");

		GoldResultPrinter.PrintSingleValue(Math.Round(maxPrice, 2), "Max Gold Price Last Year");
		GoldResultPrinter.PrintSingleValue(Math.Round(minPrice, 2), "Min Gold Price Last Year");
		GoldResultPrinter.PrintSingleValue(Math.Round(maxPriceQuery, 2), "Max Gold Price Last Year (Query)");
		GoldResultPrinter.PrintSingleValue(Math.Round(minPriceQuery, 2), "Min Gold Price Last Year (Query)");

        GoldResultPrinter.PrintSingleValue(Math.Round(priceJan2020.Price, 2), "Gold Price on Jan 1, 2020");
		GoldResultPrinter.PrintPrices(bestDays.ToList(), "Best Days to Sell Gold");

        GoldResultPrinter.PrintDates(dates_2019_2022, "Top three from 11-20 (2019-2022)");

        GoldResultPrinter.PrintSingleValue(price_2020, "Average Price in 2020");
        GoldResultPrinter.PrintSingleValue(price_2023, "Average Price in 2023");
        GoldResultPrinter.PrintSingleValue(price_2024, "Average Price in 2024");

        GoldResultPrinter.PrintTwoDates(best, "Best to buy and sell");

		Console.WriteLine("\nGold Analyis Queries with LINQ Completed.");

        Console.WriteLine("Saving some data to XML at data.xml...");
        XMLPriceHandler.SaveToXML(bestDays, "data.xml");

        Console.WriteLine("Reading data back from XML...");

        var loadedPrices = XMLPriceHandler.LoadFromXML("data.xml").Take(3).ToList();
        GoldResultPrinter.PrintPrices(loadedPrices, "Loaded Prices from XML (first 3)");
	}

}
