using System;
using System.Collections.Generic;

#nullable disable

namespace dbfirstdotnet.Models
{
    public partial class ZtblBowlerRating
    {
        public string BowlerRating { get; set; }
        public long? BowlerLowAvg { get; set; }
        public long? BowlerHighAvg { get; set; }
    }
}
