using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Service.Models.Team
{
    public class TeamModelEdit
    {        
        public int Team_ID { get; set; }

        [Required(ErrorMessage = "Please, insert team name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please, select tournament")]
        public int Tournament_ID { get; set; }
    }
}