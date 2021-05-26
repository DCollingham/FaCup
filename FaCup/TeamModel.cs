using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaCup
{
    public class TeamModel
    {
        //Properties for the teams
        public string TeamName { get; set; }
        public string LeaugeName { get; set; }
        public double LeaugeId { get; set; }
        //Whether a team is in the FA Cup 2021
        public bool InCup { get; set; }
        //Whether a Team is still in the cup of has been knocked out
        public bool KnockedOut { get; set; }
        public int DrawId { get; set; }

    }

    }


