using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dbfirstdotnet.Models
{
    public interface IBowlingLeagueRepository
    {
        IQueryable<Bowler> Bowlers { get; }

        IQueryable<Bowler> SQLRawBowlers { get; }

        IQueryable<Team> Teams { get; }

    }
}
