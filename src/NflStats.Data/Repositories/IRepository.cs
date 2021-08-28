﻿using NflStats.Data.DataObjects;
using System.Linq;

namespace NflStats.Data.Repositories
{
    public interface IRepository
    {

        #region Save Methods

        DefensiveStat Save(DefensiveStat stat);
        KickingStat Save(KickingStat stat);
        PassingStat Save(PassingStat stat);
        ReceivingStat Save(ReceivingStat stat);
        RushingStat Save(RushingStat stat);
        ScheduleItem Save(ScheduleItem item);
        Team Save(Team team);
        TeamStat Save(TeamStat stat);
        DataObjects.TypeCode Save(DataObjects.TypeCode code);
        ReturnStat Save(ReturnStat stat);
        Player Save(Player player);

        #endregion

        #region Read Methods

        DefensiveStat GetDefensiveStat(long id);
        IQueryable<DefensiveStat> GetDefensiveStats();
        IQueryable<DefensiveStat> GetDefensiveStats(long playerId);

        KickingStat GetKickingStat(long id);
        IQueryable<KickingStat> GetKickingStats();
        IQueryable<KickingStat> GetKickingStats(long playerId);

        PassingStat GetPassingStat(long id);
        IQueryable<PassingStat> GetPassingStats();
        IQueryable<PassingStat> GetPassingStats(long playerId);

        ReceivingStat GetReceivingStat(long id);
        IQueryable<ReceivingStat> GetReceivingStats();
        IQueryable<ReceivingStat> GetReceivingStats(long playerId);

        RushingStat GetRushingStat(long id);
        IQueryable<RushingStat> GetRushingStats();
        IQueryable<RushingStat> GetRushingStats(long playerId);

        ScheduleItem GetScheduleItem(long id);
        IQueryable<ScheduleItem> GetScheduleItems(int teamId);
        IQueryable<ScheduleItem> GetScheduleItems(int teamId, int year, int week, int typeId);
        IQueryable<ScheduleItem> GetScheduleItems(int teamId, int typeId, int year);
        IQueryable<ScheduleItem> GetScheduleItems(int teamId, int typeId, bool isHome);

        Team GetTeam(int id);
        Team GetTeam(string code);
        IQueryable<Team> GetTeams();

        TeamStat GetTeamStat(long id);
        TeamStat GetTeamStat(int teamId, long scheduleId);
        IQueryable<TeamStat> GetTeamStats();
        IQueryable<TeamStat> GetTeamStats(int teamId);

        DataObjects.TypeCode GetTypeCode(int id);
        IQueryable<DataObjects.TypeCode> GetTypeCodes();

        ReturnStat GetReturnStat(long id);
        IQueryable<ReturnStat> GetReturnStats();
        IQueryable<ReturnStat> GetReturnStats(long playerId);

        Player GetPlayer(long id);
        Player GetPlayer(string url);
        IQueryable<Player> GetPlayers();

        #endregion

        #region Exists Methods

        bool Exists(DefensiveStat stat);
        bool Exists(KickingStat stat);
        bool Exists(PassingStat stat);
        bool Exists(ReceivingStat stat);
        bool Exists(RushingStat stat);
        bool Exists(ScheduleItem item);
        bool Exists(Team team);
        bool Exists(TeamStat stat);
        bool Exists(DataObjects.TypeCode code);
        bool Exists(ReturnStat stat);
        bool Exists(Player player);
        #endregion

    }
}