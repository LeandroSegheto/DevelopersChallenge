using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Service.Models.Player
{
    public class PlayerModelEdit
    {        
        public int Player_ID { get; set; }

        [Required(ErrorMessage = "Please, insert player name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please, select team")]
        public int Team_ID { get; set; }
    }
}