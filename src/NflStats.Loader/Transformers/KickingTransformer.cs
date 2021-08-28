using NflStats.Data.DataObjects;
using NflStats.Loader.Helpers;
using NflStats.Loader.Models;

namespace NflStats.Loader.Transformers
{
    public class KickingTransformer : ITransformer<KickingModel, KickingStat>
    {
        public KickingStat Transform(KickingModel item)
        {
            return new KickingStat()
            {
                FieldGoals = DataHelper.ParseInt(item.FieldGoalMade),
                LongFieldGoal = DataHelper.ParseInt(item.LongFieldGoal),
                Attempts = DataHelper.ParseInt(item.FieldGoalAttempts),
                ExtraPointAttempts = DataHelper.ParseInt(item.XpAttempted),
                ExtraPoints = DataHelper.ParseInt(item.XpMade),
                Points = DataHelper.ParseInt(item.Points)                             
            };
        }
    }
}
