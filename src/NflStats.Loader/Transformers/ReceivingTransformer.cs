using NflStats.Data.DataObjects;
using NflStats.Loader.Helpers;
using NflStats.Loader.Models;

namespace NflStats.Loader.Transformers
{
    public class ReceivingTransformer : ITransformer<ReceivingModel, ReceivingStat>
    {
        public ReceivingStat Transform(ReceivingModel item)
        {
            return new ReceivingStat()
            {
                AveragePerReception = DataHelper.ParseDouble(item.ReceivingAverage),
                LongestReception = DataHelper.ParseInt(item.LongCatch),
                Receptions = DataHelper.ParseInt(item.Receptions),
                Targets = DataHelper.ParseInt(item.Targets),
                Yards = DataHelper.ParseInt(item.Yards),
                Touchdowns = DataHelper.ParseInt(item.Touchdowns)                             
            };
        }
    }
}
