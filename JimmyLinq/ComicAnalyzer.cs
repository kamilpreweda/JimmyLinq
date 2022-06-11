using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JimmyLinq
{
    public static class ComicAnalyzer
    {
        private static PriceRange CalculatePriceRange(Comic comic)
        {
            if (Comic.Prices[comic.Issue] < 100)
            {
                return PriceRange.Tanie;
            }
            else
            {
                return PriceRange.Drogie;
            }
        }

        public static IEnumerable<IGrouping<PriceRange, Comic>> GroupComicsByPrice(IEnumerable<Comic> comics, IReadOnlyDictionary<int, decimal> prices)
        {
            IEnumerable<IGrouping<PriceRange, Comic>> grouped =
                from comic in comics
                orderby prices[comic.Issue]
                group comic by CalculatePriceRange(comic) into priceGroup
                select priceGroup;

            return grouped;
        }
        
        
    }
}
