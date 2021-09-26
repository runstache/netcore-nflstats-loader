using NflStats.Data.DataObjects;
using NflStats.Loader.Helpers;
using NflStats.Loader.Models;

namespace NflStats.Loader.Transformers
{
    public class RushingTransformer : ITransformer<RushingModel, RushingStat>
    {
        public RushingStat Transform(RushingModel item)
        {
            return new RushingStat()
            {
                AveragePerCarry = DataHelper.ParseDouble(item.RushingAverage),
                Carries = DataHelper.ParseInt(item.Carries),
                LongestCarry = DataHelper.ParseInt(item.LongRush),
                Touchdowns = DataHelper.ParseInt(item.Touchdowns),
                Yards = DataHelper.ParseInt(item.Yards)
            };
        }
    }
}
