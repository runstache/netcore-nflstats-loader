using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NflStats.Data.DataObjects;
using NflStats.Loader.Helpers;
using NflStats.Loader.Models;

namespace NflStats.Loader.Transformers
{
    public class DefenseTransformer : ITransformer<DefenseModel, DefensiveStat>
    {
        public DefensiveStat Transform(DefenseModel item)
        {
            return new DefensiveStat()
            {
                PassesDefended = DataHelper.ParseInt(item.PassesDefended),
                QbHits = DataHelper.ParseInt(item.QbHits),
                Sacks = DataHelper.ParseDouble(item.Sacks),
                SoloTackles = DataHelper.ParseDouble(item.SoloTackles),
                TacklesForLoss = DataHelper.ParseDouble(item.TacklesForLoss),
                TotalTackles = DataHelper.ParseDouble(item.TotalTackles),
                Touchdowns = DataHelper.ParseInt(item.Touchdowns)
            };
        }
    }
}
