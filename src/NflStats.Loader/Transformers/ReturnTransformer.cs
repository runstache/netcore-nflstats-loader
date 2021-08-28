using NflStats.Data.DataObjects;
using NflStats.Loader.Helpers;
using NflStats.Loader.Models;

namespace NflStats.Loader.Transformers
{
    public class ReturnTransformer : ITransformer<ReturnModel, ReturnStat>
    {
        public ReturnStat Transform(ReturnModel item)
        {
            return new ReturnStat()
            {
                AverageReturn = DataHelper.ParseDouble(item.AverageReturn),
                KickReturns = DataHelper.ParseInt(item.KickReturns),
                LongReturn = DataHelper.ParseInt(item.LongReturn),
                Touchdowns = DataHelper.ParseInt(item.Touchdowns),
                Yards = DataHelper.ParseInt(item.Yards)
            };
        }
    }
}
