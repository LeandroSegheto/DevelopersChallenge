using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Match
    {
        public int Match_ID { get; set; } 
        public int Tournament_ID { get; set; }
        public Tournament Tournament { get; set; }
        public string Team1 { get; set; }
        public int Score1 { get; set; }
        public string Team2 { get; set; }
        public int Score2 { get; set; }
        public string TeamVictory { get; set; }
        public Boolean Result { get; set; }
    }
}
