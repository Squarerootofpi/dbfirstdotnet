using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace dbfirstdotnet.Models
{
    public class EFBowlingLeagueRepository : IBowlingLeagueRepository
    {

        private BowlingLeagueDbContext _context;

        public EFBowlingLeagueRepository(BowlingLeagueDbContext context)
        {
            _context = context;
        }
        public IQueryable<Bowler> Bowlers => _context.Bowlers;

        public IQueryable<Bowler> SQLRawBowlers => _context.Bowlers.FromSqlRaw("SELECT * FROM Bowlers");

        public IQueryable<Team> Teams => _context.Teams;
        //FromSqlInterpolated()
    }
}
