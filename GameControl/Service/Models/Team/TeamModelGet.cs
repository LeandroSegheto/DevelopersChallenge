using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service.Models.Team
{
    public class TeamModelGet
    {
        public int Team_ID { get; set; }
        public string Name { get; set; }
        public int Tournament_ID { get; set; }
        public string Tournament_Name { get; set; }
    }
}