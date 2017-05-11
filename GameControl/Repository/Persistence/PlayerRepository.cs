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
    public class PlayerRepository : GenericRepository<Player>
    {
        public override List<Player> ListAll()
        {
            using (Connection con = new Connection())
            {
                return con.Player.Include(p => p.Team).ToList();
            }
        }

        public override Player GetByID(int id)
        {
            using (Connection con = new Connection())
            {
                return con.Player.Include(p => p.Team).SingleOrDefault(p => p.Player_ID == id);
            }
        }
    }
}
