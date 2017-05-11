using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data.Entity.ModelConfiguration;

namespace Repository.Mapping
{
    public class TeamMap : EntityTypeConfiguration<Team>
    {
        public TeamMap()
        {
            ToTable("Team");
            HasKey(t => t.Team_ID);

            Property(t => t.Team_ID)
                .HasColumnName("Team_ID")
                .IsRequired();

            Property(t => t.Name)
                .HasColumnName("Name")
                .HasMaxLength(50)
                .IsRequired();

            HasRequired(t => t.Tournament)
                .WithMany(t => t.Teams)
                .HasForeignKey(t => t.Tournament_ID);
        }
    }
}
