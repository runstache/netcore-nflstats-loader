using NflStats.Data.DataObjects;
using NflStats.Loader.Helpers;
using NflStats.Loader.Models;

namespace NflStats.Loader.Transformers
{
    public class InterceptionTransformer : ITransformer<InterceptionModel, InterceptionStat>
    {
        public InterceptionStat Transform(InterceptionModel item)
        {
            return new InterceptionStat()
            {
                Interceptions = DataHelper.ParseInt(item.Interceptions),
                Touchdowns = DataHelper.ParseInt(item.Touchdowns),
                Yards = DataHelper.ParseInt(item.Yards)
            };
        }
    }
}
