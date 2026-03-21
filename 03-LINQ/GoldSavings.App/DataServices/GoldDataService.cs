using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GoldSavings.App.Client;
using GoldSavings.App.Model;

namespace GoldSavings.App.Services
{
    public class GoldDataService
    {
        private readonly GoldClient _goldClient;

        public GoldDataService()
        {
            _goldClient = new GoldClient();
        }

        public async Task<List<GoldPrice>> GetGoldPrices(DateTime startDate, DateTime endDate)
        {
            List<GoldPrice> prices = new List<GoldPrice>();
            if (endDate - startDate > TimeSpan.FromDays(365))
            {
                var steps = (int)((endDate - startDate).TotalDays / 365) + 1;
                for(int i = 0; i < steps; i++)
                {
                    var stepStart = startDate.AddDays(i * 365);
                    var stepEnd = (i == steps - 1) ? endDate : stepStart.AddDays(364);
                    var stepPrices = await _goldClient.GetGoldPrices(stepStart, stepEnd);
                    if (stepPrices != null)
                    {
                        prices.AddRange(stepPrices);
                    }
				}
			}
            else
            {
                prices = await _goldClient.GetGoldPrices(startDate, endDate);
            }
            return prices ?? new List<GoldPrice>();  // Prevent null values
        }

	}
}
