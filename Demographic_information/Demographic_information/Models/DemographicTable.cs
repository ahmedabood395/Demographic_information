namespace Demographic_information.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DemographicTable")]
    public partial class DemographicTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DemographicTable()
        {
            TabDemographicDTLTables = new HashSet<TabDemographicDTLTable>();
        }

        [Key]
        public int DEmTypeID { get; set; }

        [StringLength(50)]
        public string TypeDescAR { get; set; }

        [StringLength(10)]
        public string TypeDecEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TabDemographicDTLTable> TabDemographicDTLTables { get; set; }
    }
}
