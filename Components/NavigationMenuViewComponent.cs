using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dbfirstdotnet.Models;
using dbfirstdotnet.Models.ViewModels;

namespace dbfirstdotnet.Components
{
    /// <summary>
    /// This is the program logic for how to return selected data. 
    /// Currently this filters only by category. 
    /// Associated tabhelper is <vc:navigation-menu>
    /// </summary>
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IBowlingLeagueRepository repository;

        public NavigationMenuViewComponent(IBowlingLeagueRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            //this logic is to get the teamid and the teamname from the routedata, which 
            //crucial to render the correct name. . 
            ViewBag.SelectedTeamId = RouteData?.Values["teamid"];
            long selectedteamid;
            long.TryParse((string)RouteData?.Values["teamid"], out selectedteamid);
            Team t = repository.Teams
                .Select(x => x)
                .Where(x => x.TeamId == selectedteamid).FirstOrDefault();
            string? teamname;
            if (t == null)
            {
                teamname = null;
            }
            else { 
                teamname = t.TeamName; 
            }

            return View(
                new NavigationMenuViewModel 
                {
                    Teams = repository.Teams
                    .Select(x => x)
                    .Distinct()
                    .OrderBy(x => x.TeamId), 
                    CurrentTeamName = teamname
                }
                );
        }
    }
}
