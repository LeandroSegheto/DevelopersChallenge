using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Entity;

namespace Service.Models.Tournament
{
    public class TournamentModelEdit
    {        
        public int Tournament_ID { get; set; }

        [Required(ErrorMessage = "Please, insert tournament name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please, insert number of teams")]
        public int NumberOfTeams { get; set; }
                
        public Boolean Start { get; set; }
    }
}