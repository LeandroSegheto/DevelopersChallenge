using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Team
    {
        public int Team_ID { get; set; }
        public string Name { get; set; }

        public List<Player> Players { get; set; }        

        public int Tournament_ID { get; set; }
        public Tournament Tournament { get; set; }        
    }
}
