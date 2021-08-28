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
    public class PassingTransformer : ITransformer<PassingModel, PassingStat>
    {
        public PassingStat Transform(PassingModel item)
        {
            return new PassingStat()
            {
                Attempts = DataHelper.ParseInt(item.Attempts),
                AveragePerAttempt = DataHelper.ParseDouble(item.PassingAverage),
                Completions = DataHelper.ParseInt(item.Completions),
                Interceptions = DataHelper.ParseInt(item.Interceptions),
                Qbr = DataHelper.ParseDouble(item.QbRating),
                Rating = DataHelper.ParseDouble(item.Rating),
                Sacks = DataHelper.ParseInt(item.Sacks),
                Touchdowns = DataHelper.ParseInt(item.Touchdowns),
                Yards = DataHelper.ParseInt(item.Yards)
            };
        }
    }
}
