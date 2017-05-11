using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service.Models.Player
{
    public class PlayerModelGet
    {
        public int Player_ID { get; set; }
        public string Name { get; set; }
        public int Team_ID { get; set; }
        public string Team_Name { get; set; }
    }
}