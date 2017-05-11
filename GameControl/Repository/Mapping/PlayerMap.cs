using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data.Entity.ModelConfiguration;

namespace Repository.Mapping
{
    public class PlayerMap : EntityTypeConfiguration<Player>
    {
        public PlayerMap()
        {
            ToTable("Player");
            HasKey(p => p.Player_ID);

            Property(p => p.Player_ID)
                .HasColumnName("Player_ID")
                .IsRequired();

            Property(p => p.Name)
                .HasColumnName("Name")
                .HasMaxLength(50)
                .IsRequired();

            HasRequired(p => p.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(p => p.Team_ID);
        }
    }
}
