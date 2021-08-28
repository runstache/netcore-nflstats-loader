using NflStats.Data.DataObjects;
using NflStats.Loader.Helpers;
using NflStats.Loader.Models;

namespace NflStats.Loader.Transformers
{
    public class FumbleTransformer : ITransformer<FumbleModel, FumbleStat>
    {
        public FumbleStat Transform(FumbleModel item)
        {
            return new FumbleStat()
            {
                Fumbles = DataHelper.ParseInt(item.Fumbles),
                FumblesLost = DataHelper.ParseInt(item.FumblesLost),
                FumblesRecovered = DataHelper.ParseInt(item.FumblesRecovered)
            };
        }
    }
}
