using System.Linq;
using Baseball.Lib.Models;
using Baseball.Lib.Repositories;

namespace Baseball.Lib.Managers
{
    public class TeamManager
    {
        public IPlayerYearStatsRepository PlayerYearStatsRepository { get; set; }
        public ITeamRepository TeamRepository { get; set; }

        public TeamManager(ITeamRepository teamRepository, IPlayerYearStatsRepository playerYearStatsRepository)
        {
            TeamRepository = teamRepository;
            PlayerYearStatsRepository = playerYearStatsRepository;
        }

        public virtual TeamStats GetCurrentSeasonStats()
        {
            var teams = TeamRepository.GetAll();

            if (!teams.Any())
                return new TeamStats();

            var currentSeasonTeamRecord = teams.FirstOrDefault(x => x.CurrentSeason) ?? teams.OrderBy(x => x.Year).Last();
            var currentPlayerYearStats = PlayerYearStatsRepository.GetAllForYear(currentSeasonTeamRecord.Year);
            var seasons = teams.OrderBy(x => x.Year).Select(team => team.Year);

            return new TeamStats(currentSeasonTeamRecord, currentPlayerYearStats, seasons);
        }
    }
}