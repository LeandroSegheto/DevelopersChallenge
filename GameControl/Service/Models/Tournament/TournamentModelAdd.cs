using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Service.Models.Tournament
{
    public class TournamentModelAdd
    {
        [Required(ErrorMessage = "Please, insert tournament name")]        
        public string Name { get; set; }

        [Required(ErrorMessage = "Please, insert number of teams")]
        public int NumberOfTeams { get; set; }
                
        public Boolean Start { get; set; }
    }
}