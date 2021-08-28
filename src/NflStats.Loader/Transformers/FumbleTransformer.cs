using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NflStats.Data.DataObjects;
using NflStats.Loader.Models;
using NflStats.Loader.Helpers;

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
