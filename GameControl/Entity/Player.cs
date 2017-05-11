using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Player
    {
        public int Player_ID { get; set; }
        public string Name { get; set; }

        public int Team_ID { get; set; }
        public Team Team { get; set; }
    }
}
