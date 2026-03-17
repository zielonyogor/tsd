using System;
using System.Collections.Generic;
using System.Linq;
using GoldSavings.App.Model;

namespace GoldSavings.App.Services
{
    public class GoldAnalysisService
    {
        private readonly List<GoldPrice> _goldPrices;

        public GoldAnalysisService(List<GoldPrice> goldPrices)
        {
            _goldPrices = goldPrices;
        }
        public double GetAveragePrice()
        {
            return _goldPrices.Average(p => p.Price);
        }

        public double GetMaxPrice()
        {
            return _goldPrices.Max(p => p.Price);
        }

        public double GetMinPrice()
        {
            return _goldPrices.Min(p => p.Price);
        }

        public double GetMaxPriceQuery()
        {
            var maxPrice = (from p in _goldPrices
                            select p.Price).Max();
            return maxPrice;
        }
        public double GetMinPriceQuery()
        {
            var minPrice = (from p in _goldPrices
                            select p.Price).Min();
            return minPrice;
        }

        public IEnumerable<GoldPrice> BestDaysToSell(double previousPrice, float expectedPercentageIncrease)
        {
            var minTargetPrice = previousPrice * (1 + expectedPercentageIncrease / 100);
            var bestDays = _goldPrices.Where(p => p.Price >= minTargetPrice)
                                       .OrderBy(p => p.Date)
                                       .ToList();
            return bestDays;
		}

        public List<DateTime> Get3DatesFromStartOf2ndTenRanking()
        {
            var top3From2ndTen = _goldPrices.OrderByDescending(p => p.Price)
                                            .Skip(10)
                                            .Take(3)
                                            .Select(p => p.Date)
                                            .ToList();
			return top3From2ndTen;
		}

        public double GetAveragePriceQuery()
        {
            var averagePrice = (from p in _goldPrices
                                select p.Price).Average();
            return averagePrice;
		}

        public Tuple<DateTime, DateTime> GetBestToBuyAndSell()
        {
            var bestPair = _goldPrices.Join(_goldPrices, buy => 1, sell => 1, (buy, sell) => new { Buy = buy, Sell = sell })
                                        .Where(pair => pair.Sell.Date > pair.Buy.Date)
                                        .OrderByDescending(pair => pair.Sell.Price - pair.Buy.Price)
                                        .FirstOrDefault();
            if (bestPair != null)
            {
                return Tuple.Create(bestPair.Buy.Date, bestPair.Sell.Date);
            }
            else
            {
                throw new InvalidOperationException("No valid buy/sell pair found.");
			}
		}
    }
}
