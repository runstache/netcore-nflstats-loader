using NflStats.Data.Contexts;
using NflStats.Data.DataObjects;
using System.Linq;

namespace NflStats.Data.Repositories
{
    public class SqlRespository : BaseRepository, IRepository
    {
        private readonly SqlContext ctx;
        public SqlRespository(SqlContext ctx) : base(ctx)
        {
            this.ctx = ctx;
        }

        public bool Exists(DefensiveStat stat)
        {
            return base.Query<DefensiveStat>(c => c.PlayerId == stat.PlayerId && c.ScheduleId == stat.ScheduleId).Any();
        }

        public bool Exists(KickingStat stat)
        {
            return base.Query<KickingStat>(c => c.PlayerId == stat.PlayerId && c.ScheduleId == stat.ScheduleId).Any();
        }

        public bool Exists(PassingStat stat)
        {
            return base.Query<PassingStat>(c => c.PlayerId == stat.PlayerId && c.ScheduleId == stat.ScheduleId).Any();
        }

        public bool Exists(ReceivingStat stat)
        {
            return base.Query<ReceivingStat>(c => c.PlayerId == stat.PlayerId && c.ScheduleId == stat.ScheduleId).Any(); 
        }

        public bool Exists(RushingStat stat)
        {
            return base.Query<RushingStat>(c => c.PlayerId == stat.PlayerId && c.ScheduleId == stat.ScheduleId).Any();
        }

        public bool Exists(ScheduleItem item)
        {
            return base.Query<ScheduleItem>(c => c.TeamId == item.TeamId && c.OpponentId == item.OpponentId && c.GameId == item.GameId).Any();
        }

        public bool Exists(Team team)
        {
            return base.Query<Team>(c => c.Code == team.Code).Any();
        }

        public bool Exists(TeamStat stat)
        {
            return base.Query<TeamStat>(c => c.TeamId == stat.TeamId && c.ScheduleId == stat.ScheduleId).Any();
        }

        public bool Exists(TypeCode code)
        {
            return base.Query<TypeCode>(c => c.Code == code.Code).Any();
        }

        public bool Exists(ReturnStat stat)
        {
            return base.Query<ReturnStat>(c => c.PlayerId == stat.PlayerId && c.ScheduleId == stat.ScheduleId).Any();
        }

        public bool Exists(Player player)
        {
            return base.Query<Player>(c => c.Url == player.Url).Any();
        }

        public bool Exists(FumbleStat stat)
        {
            return base.Query<FumbleStat>(c => c.PlayerId == stat.PlayerId && c.ScheduleId == stat.ScheduleId).Any();
        }

        public bool Exists(InterceptionStat stat)
        {
            return base.Query<InterceptionStat>(c => c.PlayerId == stat.PlayerId && c.ScheduleId == stat.ScheduleId).Any();
        }

        public DefensiveStat GetDefensiveStat(long id)
        {
            return base.Query<DefensiveStat>(c => c.Id == id).FirstOrDefault();
        }

        public IQueryable<DefensiveStat> GetDefensiveStats()
        {
            return ctx.DefensiveStats;
        }

        public IQueryable<DefensiveStat> GetDefensiveStats(long playerId)
        {
            return base.Query<DefensiveStat>(c => c.PlayerId == playerId);
        }

        public FumbleStat GetFumbleStat(long id)
        {
            return base.Query<FumbleStat>(c => c.Id == id).FirstOrDefault();
        }

        public IQueryable<FumbleStat> GetFumbleStats()
        {
            return ctx.Fumbles;
        }

        public IQueryable<FumbleStat> GetFumbleStats(long playerId)
        {
            return base.Query<FumbleStat>(c => c.PlayerId == playerId);
        }

        public InterceptionStat GetInterceptionStat(long id)
        {
            return base.Query<InterceptionStat>(c => c.Id == id).FirstOrDefault();
        }

        public IQueryable<InterceptionStat> GetInterceptionStats()
        {
            return ctx.Interceptions;
        }

        public IQueryable<InterceptionStat> GetInterceptionStats(long playerId)
        {
            return base.Query<InterceptionStat>(c => c.PlayerId == playerId);
        }

        public KickingStat GetKickingStat(long id)
        {
            return base.Query<KickingStat>(c => c.Id == id).FirstOrDefault();
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
            return base.Query<PassingStat>(c => c.Id == id).FirstOrDefault();
        }

        public IQueryable<PassingStat> GetPassingStats()
        {
            return ctx.PassingStats;
        }

        public IQueryable<PassingStat> GetPassingStats(long playerId)
        {
            return base.Query<PassingStat>(c => c.PlayerId == playerId);
        }

        public Player GetPlayer(long id)
        {
            return base.Query<Player>(c => c.Id == id).FirstOrDefault();
        }

        public Player GetPlayer(string url)
        {
            return base.Query<Player>(c => c.Url == url).FirstOrDefault();
        }

        public IQueryable<Player> GetPlayers()
        {
            return ctx.Players;
        }

        public ReceivingStat GetReceivingStat(long id)
        {
            return base.Query<ReceivingStat>(c => c.Id == id).FirstOrDefault();
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
            return base.Query<ReturnStat>(c => c.Id == id).FirstOrDefault();
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
            return base.Query<RushingStat>(c => c.Id == id).FirstOrDefault();
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
            return base.Query<ScheduleItem>(c => c.Id == id).FirstOrDefault();
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
            return base.Query<Team>(c => c.Id == id).FirstOrDefault();
        }

        public Team GetTeam(string code)
        {
            return base.Query<Team>(c => c.Code == code).FirstOrDefault();
        }

        public IQueryable<Team> GetTeams()
        {
            return ctx.Teams;
        }

        public TeamStat GetTeamStat(long id)
        {
            return base.Query<TeamStat>(c => c.Id == id).FirstOrDefault();
        }

        public TeamStat GetTeamStat(int teamId, long scheduleId)
        {
            return base.Query<TeamStat>(c => c.TeamId == teamId && c.ScheduleId == scheduleId).FirstOrDefault();
        }

        public IQueryable<TeamStat> GetTeamStats()
        {
            return ctx.TeamStats;
        }

        public IQueryable<TeamStat> GetTeamStats(int teamId)
        {
            return base.Query<TeamStat>(c => c.TeamId == teamId);
        }

        public TypeCode GetTypeCode(int id)
        {
            return base.Query<TypeCode>(c => c.Id == id).FirstOrDefault();
        }

        public IQueryable<TypeCode> GetTypeCodes()
        {
            return ctx.TypeCodes;
        }        

        public DefensiveStat Save(DefensiveStat stat)
        {
            if (stat.Id > 0 && Exists(stat))
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
            if (stat.Id > 0 && Exists(stat))
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
            if (stat.Id > 0 && Exists(stat))
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
            if (stat.Id > 0 && Exists(stat))
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
            if (stat.Id > 0 && Exists(stat))
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
            if (item.Id > 0 && Exists(item))
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
            if (team.Id > 0 && Exists(team))
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
            if (stat.Id > 0 && Exists(stat))
            {
                return base.Update(stat);
            }
            else
            {
                return base.Add(stat);
            }
        }

        public TypeCode Save(DataObjects.TypeCode code)
        {
            if (code.Id > 0 && Exists(code))
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
            if (stat.Id > 0 && Exists(stat))
            {
                return base.Update(stat);
            }
            else
            {
                return base.Add(stat);
            }
        }

        public Player Save(Player player)
        {
            if (player.Id > 0 && Exists(player))
            {
                return base.Update(player);
            }
            else
            {
                return base.Add(player);
            }
        }

        public FumbleStat Save(FumbleStat stat)
        {
            if (stat.Id > 0 && Exists(stat))
            {
                return base.Update(stat);
            }
            else
            {
                return base.Add(stat);
            }
        }

        public InterceptionStat Save(InterceptionStat stat)
        {
            if(stat.Id > 0 && Exists(stat))
            {
                return base.Update(stat);
            }
            else
            {
                return base.Add(stat);
            }
        }
    }
}
