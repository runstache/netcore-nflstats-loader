using NflStats.Data.DataObjects;
using NflStats.Loader.Helpers;
using NflStats.Loader.Models;

namespace NflStats.Loader.Transformers
{
    public class PuntingTransformer : ITransformer<PuntingModel, KickingStat>
    {
        public KickingStat Transform(PuntingModel item)
        {
            return new KickingStat()
            {
                Punts = DataHelper.ParseInt(item.Punts),
                PuntInsideTwenty = DataHelper.ParseInt(item.InsideTwenty),
                PuntLongest = DataHelper.ParseInt(item.LongPunt),
                PuntTotalYards = DataHelper.ParseInt(item.Yards),
                AveragePunt = DataHelper.ParseDouble(item.AveragePunt),
                Touchbacks = DataHelper.ParseInt(item.Touchbacks)
            };
        }
    }
}
