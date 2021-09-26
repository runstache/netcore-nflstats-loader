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
    public class ScoringTransformer : ITransformer<ScoreValueModel, ScoringStat>
    {
        public ScoringStat Transform(ScoreValueModel item)
        {
            return new ScoringStat()
            {
                Quarter = item.Quarter,
                Points = DataHelper.ParseInt(item.Points)
            };
        }
    }
}
