using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dbfirstdotnet.Models;

namespace dbfirstdotnet.Models.ViewModels
{
    /// <summary>
    /// ViewModel that stores all the data for the Index.cshtml
    /// </summary>
    public class IndexViewModel
    {
        public IEnumerable<Bowler> Bowlers { get; set; }
        public IEnumerable<Team> Teams { get; set; }
        public PagingInfo PagingInfo { get; set; }
        /// <summary>
        /// This variable stores the currently selected category for the view to use.
        /// </summary>
        public long CurrentTeamID { get; set; }
        public string CurrentTeamName { get; set; }

    }
}
