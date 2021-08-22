using NflStats.Data.Contexts;
using NflStats.Data.DataObjects;
using System.Linq;

namespace NflStats.Data.Repositories
{
    public class SqlRespository : BaseRepository, IRepository
    {
        private readonly SqlContext ctx;
        protected SqlRespository(SqlContext ctx) : base(ctx)
        {
            this.ctx = ctx;
        }

        public bool Exists(DefensiveStat stat)
        {
            var result = base.Query<DefensiveStat>(c => c.PlayerId == stat.PlayerId && c.ScheduleId == stat.ScheduleId);
            return result.Any();
        }

        public bool Exists(KickingStat stat)
        {
            var result = base.Query<DefensiveStat>(c => c.PlayerId == stat.PlayerId && c.ScheduleId == stat.ScheduleId);
            return result.Any();
        }

        public bool Exists(PassingStat stat)
        {
            var result = base.Query<DefensiveStat>(c => c.PlayerId == stat.PlayerId && c.ScheduleId == stat.ScheduleId);
            return result.Any();
        }

        public bool Exists(ReceivingStat stat)
        {
            var result = base.Query<DefensiveStat>(c => c.PlayerId == stat.PlayerId && c.ScheduleId == stat.ScheduleId);
            return result.Any();
        }

        public bool Exists(RushingStat stat)
        {
            var result = base.Query<DefensiveStat>(c => c.PlayerId == stat.PlayerId && c.ScheduleId == stat.ScheduleId);
            return result.Any();
        }

        public bool Exists(ScheduleItem item)
        {
            var result = base.Query<ScheduleItem>(c => c.TeamId == item.TeamId && c.OpponentId == item.OpponentId && c.GameId == item.GameId);
            return result.Any();

        }

        public bool Exists(Team team)
        {
            var result = base.Query<Team>(c => c.Code == team.Code);
            return result.Any();
        }

        public bool Exists(TeamStat stat)
        {
            var result = base.Query<TeamStat>(c => c.TeamId == stat.TeamId && c.ScheduleId == stat.ScheduleId);
            return result.Any();
        }

        public bool Exists(DataObjects.TypeCode code)
        {
            var result = base.Query<DataObjects.TypeCode>(c => c.Code == code.Code);
            return result.Any();
        }

        public bool Exists(ReturnStat stat)
        {
            var result = base.Query<ReturnStat>(c => c.PlayerId == stat.PlayerId && c.ScheduleId == stat.ScheduleId);
            return result.Any();
        }

        public DefensiveStat GetDefensiveStat(long id)
        {
            return ctx.DefensiveStats.Where(c => c.Id == id).FirstOrDefault();
        }

        public IQueryable<DefensiveStat> GetDefensiveStats()
        {
            return ctx.DefensiveStats;
        }

        public IQueryable<DefensiveStat> GetDefensiveStats(long playerId)
        {
            return base.Query<DefensiveStat>(c => c.PlayerId == playerId);
        }

        public KickingStat GetKickingStat(long id)
        {
            return ctx.KickingStats.Where(c => c.Id == id).FirstOrDefault();
        }

        public IQueryable<KickingStat> GetKickingStats()
        {
            return ctx.KickingStats;
        }

        public IQueryable<KickingStat> GetKickingStats(long playerId)
        {
            return base.Query<KickingStat>(c => c.PlayerId == playerId);
        }

        public PassingStat GetPassingStat(long id)
        {
            return ctx.PassingStats.Where(c => c.Id == id).FirstOrDefault();
        }

        public IQueryable<PassingStat> GetPassingStats()
        {
            return ctx.PassingStats;
        }

        public IQueryable<PassingStat> GetPassingStats(long playerId)
        {
            return base.Query<PassingStat>(c => c.PlayerId == playerId);
        }

        public ReceivingStat GetReceivingStat(long id)
        {
            return ctx.ReceivingStats.Where(c => c.Id == id).FirstOrDefault();
        }

        public IQueryable<ReceivingStat> GetReceivingStats()
        {
            return ctx.ReceivingStats;
        }

        public IQueryable<ReceivingStat> GetReceivingStats(long playerId)
        {
            return base.Query<ReceivingStat>(c => c.PlayerId == playerId);
        }

        public ReturnStat GetReturnStat(long id)
        {
            return ctx.ReturnStats.Where(c => c.Id == id).FirstOrDefault();
        }

        public IQueryable<ReturnStat> GetReturnStats()
        {
            return ctx.ReturnStats;
        }

        public IQueryable<ReturnStat> GetReturnStats(long playerId)
        {
            return base.Query<ReturnStat>(c => c.PlayerId == playerId);
        }

        public RushingStat GetRushingStat(long id)
        {
            return ctx.RushingStats.Where(c => c.Id == id).FirstOrDefault();
        }

        public IQueryable<RushingStat> GetRushingStats()
        {
            return ctx.RushingStats;
        }

        public IQueryable<RushingStat> GetRushingStats(long playerId)
        {
            return base.Query<RushingStat>(c => c.PlayerId == playerId);
        }

        public ScheduleItem GetScheduleItem(long id)
        {
            return ctx.ScheduleItems.Where(c => c.Id == id).FirstOrDefault();
        }

        public IQueryable<ScheduleItem> GetScheduleItems(int teamId)
        {
            return base.Query<ScheduleItem>(c => c.TeamId == teamId);
        }

        public IQueryable<ScheduleItem> GetScheduleItems(int teamId, int year, int week, int typeId)
        {
            return base.Query<ScheduleItem>(c => c.TeamId == teamId && c.YearValue == year && c.WeekNumber == week && c.TypeId == typeId);
        }

        public IQueryable<ScheduleItem> GetScheduleItems(int teamId, int typeId, int year)
        {
            return base.Query<ScheduleItem>(c => c.TeamId == teamId && c.TypeId == typeId && c.YearValue == year);
        }

        public IQueryable<ScheduleItem> GetScheduleItems(int teamId, int typeId, bool isHome)
        {
            return base.Query<ScheduleItem>(c => c.TeamId == teamId && c.TypeId == typeId && c.IsHome == isHome);
        }

        public Team GetTeam(int id)
        {
            return ctx.Teams.Where(c => c.Id == id).FirstOrDefault();
        }

        public Team GetTeam(string code)
        {
            return ctx.Teams.Where(c => c.Code == code).FirstOrDefault();
        }

        public IQueryable<Team> GetTeams()
        {
            return ctx.Teams;
        }

        public TeamStat GetTeamStat(long id)
        {
            return ctx.TeamStats.Where(c => c.Id == id).FirstOrDefault();
        }

        public TeamStat GetTeamStat(int teamId, long scheduleId)
        {
            return ctx.TeamStats.Where(c => c.TeamId == teamId && c.ScheduleId == scheduleId).FirstOrDefault();
        }

        public IQueryable<TeamStat> GetTeamStats()
        {
            return ctx.TeamStats;
        }

        public IQueryable<TeamStat> GetTeamStats(int teamId)
        {
            return base.Query<TeamStat>(c => c.TeamId == teamId);
        }

        public DataObjects.TypeCode GetTypeCode(int id)
        {
            return ctx.TypeCodes.Where(c => c.Id == id).FirstOrDefault();
        }

        public IQueryable<DataObjects.TypeCode> GetTypeCodes()
        {
            return ctx.TypeCodes;
        }        

        public DefensiveStat Save(DefensiveStat stat)
        {
            if (stat.Id > 0)
            {
                return base.Update(stat);
            }
            else
            {
                return base.Add(stat);
            }
        }

        public KickingStat Save(KickingStat stat)
        {
            if (stat.Id > 0)
            {
                return base.Update(stat);
            }
            else
            {
                return base.Add(stat);
            }
        }

        public PassingStat Save(PassingStat stat)
        {
            if (stat.Id > 0)
            {
                return base.Update(stat);
            }
            else
            {
                return base.Add(stat);
            }
        }

        public ReceivingStat Save(ReceivingStat stat)
        {
            if (stat.Id > 0)
            {
                return base.Update(stat);
            }
            else
            {
                return base.Add(stat);
            }
        }

        public RushingStat Save(RushingStat stat)
        {
            if (stat.Id > 0)
            {
                return base.Update(stat);
            }
            else
            {
                return base.Add(stat);
            }
        }

        public ScheduleItem Save(ScheduleItem item)
        {
            if (item.Id > 0)
            {
                return base.Update(item);
            }
            else
            {
                return base.Add(item);
            }
        }

        public Team Save(Team team)
        {
            if (team.Id > 0)
            {
                return base.Update(team);
            }
            else
            {
                return base.Add(team);
            }
        }

        public TeamStat Save(TeamStat stat)
        {
            if (stat.Id > 0)
            {
                return base.Update(stat);
            }
            else
            {
                return base.Add(stat);
            }
        }

        public DataObjects.TypeCode Save(DataObjects.TypeCode code)
        {
            if (code.Id > 0)
            {
                return base.Update(code);
            }
            else
            {
                return base.Add(code);
            }
        }

        public ReturnStat Save(ReturnStat stat)
        {
            throw new System.NotImplementedException();
        }
    }
}
