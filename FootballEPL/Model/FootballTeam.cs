﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballEPL.Model
{
    public class FootballTeam
    {
        public string Team { get; set; }
        public string P { get; set; }
        public string W { get; set; }
        public string L { get; set; }
        public string D { get; set; }
        public string F { get; set; }
        public string A { get; set; }
        public string Pts { get; set; }
        public int? ScoreDiff { get; set; }
    }
}
