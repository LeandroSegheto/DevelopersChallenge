using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Tournament
    {
        public int Tournament_ID { get; set; }
        public string Name { get; set; }
        public int NumberOfTeams { get; set; }
        public Boolean Start { get; set; }

        public List<Team> Teams { get; set; }
        public List<Match> Matchs { get; set; }
    }
}
