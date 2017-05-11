using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data.Entity.ModelConfiguration;

namespace Repository.Mapping
{
    public class MatchMap : EntityTypeConfiguration<Match>
    {
        public MatchMap()
        {
            ToTable("Match");
            HasKey(m => m.Match_ID);

            Property(m => m.Match_ID)
                .HasColumnName("Match_ID")
                .IsRequired();

            Property(m => m.Team1)
                .HasColumnName("Team1");                

            Property(m => m.Team2)
                .HasColumnName("Team2");                

            Property(m => m.Score1)
                .HasColumnName("Score1");

            Property(m => m.Score2)
                .HasColumnName("Score2");

            Property(m => m.TeamVictory)
                .HasColumnName("TeamVictory");

            Property(m => m.Result)
                .HasColumnName("Result");

            HasRequired(m => m.Tournament)
                .WithMany(t => t.Matchs)
                .HasForeignKey(m => m.Tournament_ID);
        }
    }    
}
