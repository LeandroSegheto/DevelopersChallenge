using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service.Models.Tournament
{
    public class TournamentModelGet
    {        
        public int Tournament_ID { get; set; }
        public string Name { get; set; }        
        public int NumberOfTeams { get; set; }        
        public Boolean Start { get; set; }
    }
}