using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data.Entity.ModelConfiguration;

namespace Repository.Mapping
{
    class TournamentMap : EntityTypeConfiguration<Tournament>
    {
        public TournamentMap()
        {
            ToTable("Tournament");
            HasKey(t => t.Tournament_ID);

            Property(t => t.Tournament_ID)
                .HasColumnName("Tournament_ID")
                .IsRequired();

            Property(t => t.Name)
                .HasColumnName("Name")
                .HasMaxLength(50)
                .IsRequired();

            Property(t => t.NumberOfTeams)
                .HasColumnName("NumberOfTeams")                
                .IsRequired();

            Property(t => t.Start)
                .HasColumnName("Start")
                .IsRequired();
        }
    }
}
