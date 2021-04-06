using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dbfirstdotnet.Models.ViewModels
{
    public class NavigationMenuViewModel
    {
        public IEnumerable<Team> Teams { get; set; }
        public string? CurrentTeamName { get; set; }

    }
}
