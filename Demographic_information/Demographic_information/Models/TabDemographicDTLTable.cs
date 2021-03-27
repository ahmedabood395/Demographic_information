namespace Demographic_information.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TabDemographicDTLTable")]
    public partial class TabDemographicDTLTable
    {
        [Key]
        public int DemTypeDTL_ID { get; set; }

        public int? DemTypeID { get; set; }

        [StringLength(150)]
        public string ChoiceAR { get; set; }

        [Required]
        [StringLength(150)]
        public string ChoiceEN { get; set; }

        public int? WieghtValue { get; set; }

        public virtual DemographicTable DemographicTable { get; set; }
    }
}
