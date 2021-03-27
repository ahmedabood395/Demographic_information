using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Demographic_information.Models
{
    public partial class DemographicContext : DbContext
    {
        public DemographicContext()
            : base("name=DemographicContext1")
        {
        }

        public virtual DbSet<DemographicTable> DemographicTables { get; set; }
        public virtual DbSet<TabDemographicDTLTable> TabDemographicDTLTables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DemographicTable>()
                .Property(e => e.TypeDescAR)
                .IsUnicode(false);

            modelBuilder.Entity<DemographicTable>()
                .Property(e => e.TypeDecEN)
                .IsFixedLength();

            modelBuilder.Entity<TabDemographicDTLTable>()
                .Property(e => e.ChoiceAR)
                .IsUnicode(false);

            modelBuilder.Entity<TabDemographicDTLTable>()
                .Property(e => e.ChoiceEN)
                .IsUnicode(false);
        }
    }
}
