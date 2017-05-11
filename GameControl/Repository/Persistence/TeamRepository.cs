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
    public class TeamRepository : GenericRepository<Team>
    {
        public override List<Team> ListAll()        
        {
            using (Connection con = new Connection())
            {
                return con.Team.Include(t => t.Tournament).ToList();
            }
        }

        public override Team GetByID(int id)
        {
            using (Connection con = new Connection())
            {
                return con.Team.Include(t => t.Tournament).SingleOrDefault(t => t.Team_ID == id);
            }
        }

        public List<Team> GetByTournamentID(int id)
        {
            using (Connection con = new Connection())
            {
                return con.Team.Include(t => t.Tournament).Where(t => t.Tournament_ID == id).ToList();
            }
        }
    }
}
