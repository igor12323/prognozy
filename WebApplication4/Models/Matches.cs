using System;
using System.Collections.Generic;

namespace WebApplication4.Models
{
    public class Matches
    {
        public DateTime utcDate { get; set; }
        public int? matchday { get; set; }
        public Score score { get; set; }
        public Team homeTeam { get; set; }
        public Team awayTeam { get; set; }

    }
}