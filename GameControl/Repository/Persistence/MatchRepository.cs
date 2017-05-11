using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Repository.Configuration;
using System.Data.Entity;

namespace Repository.Persistence
{
    public class MatchRepository : GenericRepository<Match>
    {
        public List<Match> GetByTournamentID(int id)
        {
            using (Connection con = new Connection())
            {
                return con.Match.Where(m => m.Tournament_ID == id).ToList();
            }
        }
    }
}
