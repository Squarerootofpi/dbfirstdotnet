using dbfirstdotnet.Models;
using dbfirstdotnet.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace dbfirstdotnet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IBowlingLeagueRepository _repository { get; set; }

        private int PageSize = 5;

        public HomeController(ILogger<HomeController> logger, IBowlingLeagueRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index(long teamid, int pageNum = 1)
        {
            //IQueryable<Bowler> theBowlers;
            string teamName;
            if (teamid == 0)
            {
                Console.WriteLine("no teamid");
                teamName = null;
            }
            else
            {
                teamName = _repository.Teams.Where(t => t.TeamId == teamid).FirstOrDefault().TeamName;
            }
            Console.WriteLine("Index Get");
            return View(new IndexViewModel
            {
                Bowlers = _repository.Bowlers //0 is a default asp.net sends to ints if null
                    .Where(b => teamid == 0 || b.TeamId == teamid)
                    .OrderBy(b => b.TeamId)
                    .Skip((pageNum - 1) * PageSize)
                    .Take(PageSize)
                ,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = PageSize,
                    TotalNumItems =
                        _repository.
                            Bowlers.
                            Where(b => teamid == 0 || b.TeamId == teamid).
                            Count()
                },
                CurrentTeamID = teamid,
                CurrentTeamName = teamName,
                Teams = _repository.Teams
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
