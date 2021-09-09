using NflStats.Data.Contexts;
using NflStats.Data.DataObjects;
using NflStats.Data.Repositories;
using NflStats.Loader.Helpers;
using NflStats.Loader.Models;
using System.Linq;

namespace NflStats.Loader.Processors
{
    public class TeamStatProcessor : BaseProcessor
    {
        private readonly IRepository repo;
        public TeamStatProcessor(SqlContext ctx) : base(ctx)
        {
            repo = new SqlRespository(ctx);
        }

        public void ProcessItem(TeamStat stat, GameModel model, string team, string opponent, ScheduleItem schedule)
        {
            if (stat != null)
            {
                AddCommonInfo(stat, schedule);

                // Get the Box scores
                var boxscore = model.Matchup.Boxscore.Where(c => c.Team.ToLower() == team.ToLower()).FirstOrDefault();
                var opponentBoxScore = model.Matchup.Boxscore.Where(c => c.Team.ToLower() == opponent.ToLower()).FirstOrDefault();

                if (boxscore != null)
                {
                    stat.PointsScored = DataHelper.ParseInt(boxscore.Final);
                }

                if (opponentBoxScore != null)
                {
                    stat.PointsAllowed = DataHelper.ParseInt(opponentBoxScore.Final);
                }

                // Get the Big Plays
                stat.PassOverFifteen = model.BigPlays.Where(c => c.Team.ToLower() == team.ToLower()).Sum(c => c.Pass);
                stat.RushOverTen = model.BigPlays.Where(c => c.Team.ToLower() == team.ToLower()).Sum(c => c.Run);
                stat.TotalTurnovers = model.BigPlays.Where(c => c.Team.ToLower() == team.ToLower()).Sum(c => c.Turnover);

                AddOriginalId(stat, c => c.TeamId == stat.TeamId && c.ScheduleId == stat.ScheduleId);
                repo.Save(stat);
            }
        }
    }
}
