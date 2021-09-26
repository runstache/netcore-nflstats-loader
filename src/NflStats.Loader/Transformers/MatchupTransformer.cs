using NflStats.Data.DataObjects;
using NflStats.Loader.Helpers;
using NflStats.Loader.Models;
using System.Collections.Generic;

namespace NflStats.Loader.Transformers
{
    public class MatchupTransformer
    {
        public static Dictionary<string,TeamStat> Transform(MatchupModel item)
        {
            var result = new Dictionary<string, TeamStat>();
            var home = new TeamStat()
            {
                DefensiveTouchdowns = DataHelper.ParseInt(item.DefensiveTouchdowns.Home),
                PassingFirstDowns = DataHelper.ParseInt(item.PassingFirstDowns.Home),
                PassingYards = DataHelper.ParseInt(item.TotalPassingYards.Home),
                PenaltyFirstDowns = DataHelper.ParseInt(item.PenaltyFirstDowns.Home),
                TotalPlays = DataHelper.ParseInt(item.TotalPlays.Home),
                FumblesLost = DataHelper.ParseInt(item.Fumbles.Home),
                Interceptions = DataHelper.ParseInt(item.Interceptions.Home),
                RushingAttempts = DataHelper.ParseInt(item.RushingAttempts.Home),
                RushingFirstDowns = DataHelper.ParseInt(item.RushingFirstDowns.Home),
                RushingYards = DataHelper.ParseInt(item.RushingYards.Home),
                YardsPerRush = DataHelper.ParseDouble(item.YardsPerRush.Home),
                TotalDrives = DataHelper.ParseInt(item.TotalDrives.Home),
                TotalTurnovers = DataHelper.ParseInt(item.Turnovers.Home),
                TotalYards = DataHelper.ParseInt(item.TotalYards.Home),
                YardsPerPass = DataHelper.ParseDouble(item.YardsPerPass.Home),
                YardsPerPlay = DataHelper.ParseDouble(item.YardsPerPlay.Home),
                FourthDownAttempt = DataHelper.SplitInteger(item.FourthDownEfficiency.Home, "-", 1),
                FourthDownConverted = DataHelper.SplitInteger(item.FourthDownEfficiency.Home, "-", 0),
                PassingAttempts = DataHelper.SplitInteger(item.PassingEfficiency.Home, "-", 1),
                PassingCompletions = DataHelper.SplitInteger(item.PassingEfficiency.Home, "-", 0),
                Penalties = DataHelper.SplitInteger(item.Penalties.Home, "-", 0),
                PenaltyYards = DataHelper.SplitInteger(item.Penalties.Home, "-", 1),
                TimeOfPossession = (DataHelper.SplitLong(item.PossessionTime.Home, ":", 0) * 60L) + DataHelper.SplitLong(item.PossessionTime.Home, ":", 1),
                RedzoneAttempts = DataHelper.SplitInteger(item.RedZoneEfficiency.Home, "-", 1),
                RedzoneConverted = DataHelper.SplitInteger(item.RedZoneEfficiency.Home, "-", 0),
                Sacks = DataHelper.SplitInteger(item.Sacks.Home, "-", 0),
                SackYardsLost = DataHelper.SplitInteger(item.Sacks.Home, "-", 1),
                ThirdDowns = DataHelper.SplitInteger(item.ThirdDownEfficiency.Home, "-", 1),
                ThirdDownsConverted = DataHelper.SplitInteger(item.ThirdDownEfficiency.Home, "-", 0)               
            };
            result.Add("home", home);

            var away = new TeamStat()
            {
                DefensiveTouchdowns = DataHelper.ParseInt(item.DefensiveTouchdowns.Away),
                PassingFirstDowns = DataHelper.ParseInt(item.PassingFirstDowns.Away),
                PassingYards = DataHelper.ParseInt(item.TotalPassingYards.Away),
                PenaltyFirstDowns = DataHelper.ParseInt(item.PenaltyFirstDowns.Away),
                TotalPlays = DataHelper.ParseInt(item.TotalPlays.Away),
                FumblesLost = DataHelper.ParseInt(item.Fumbles.Away),
                Interceptions = DataHelper.ParseInt(item.Interceptions.Away),
                RushingAttempts = DataHelper.ParseInt(item.RushingAttempts.Away),
                RushingFirstDowns = DataHelper.ParseInt(item.RushingFirstDowns.Away),
                RushingYards = DataHelper.ParseInt(item.RushingYards.Away),
                YardsPerRush = DataHelper.ParseDouble(item.YardsPerRush.Away),
                TotalDrives = DataHelper.ParseInt(item.TotalDrives.Away),
                TotalTurnovers = DataHelper.ParseInt(item.Turnovers.Away),
                TotalYards = DataHelper.ParseInt(item.TotalYards.Away),
                YardsPerPass = DataHelper.ParseDouble(item.YardsPerPass.Away),
                YardsPerPlay = DataHelper.ParseDouble(item.YardsPerPlay.Away),
                FourthDownAttempt = DataHelper.SplitInteger(item.FourthDownEfficiency.Away, "-", 1),
                FourthDownConverted = DataHelper.SplitInteger(item.FourthDownEfficiency.Away, "-", 0),
                PassingAttempts = DataHelper.SplitInteger(item.PassingEfficiency.Away, "-", 1),
                PassingCompletions = DataHelper.SplitInteger(item.PassingEfficiency.Away, "-", 0),
                Penalties = DataHelper.SplitInteger(item.Penalties.Away, "-", 0),
                PenaltyYards = DataHelper.SplitInteger(item.Penalties.Away, "-", 1),
                TimeOfPossession = (DataHelper.SplitLong(item.PossessionTime.Away, ":", 0) * 60L) + DataHelper.SplitLong(item.PossessionTime.Away, ":", 1),
                RedzoneAttempts = DataHelper.SplitInteger(item.RedZoneEfficiency.Away, "-", 1),
                RedzoneConverted = DataHelper.SplitInteger(item.RedZoneEfficiency.Away, "-", 0),
                Sacks = DataHelper.SplitInteger(item.Sacks.Away, "-", 0),
                SackYardsLost = DataHelper.SplitInteger(item.Sacks.Away, "-", 1),
                ThirdDowns = DataHelper.SplitInteger(item.ThirdDownEfficiency.Away, "-", 1),
                ThirdDownsConverted = DataHelper.SplitInteger(item.ThirdDownEfficiency.Away, "-", 0)
            };
            result.Add("away", away);
            return result;
        }


        
    }
}
