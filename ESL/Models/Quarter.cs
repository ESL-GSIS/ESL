//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ESL.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Quarter
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Quarter()
        {
            this.Summaries = new HashSet<Summary>();
        }
    
        public int ID { get; set; }
        public int Quarter1 { get; set; }
        public int SchoolYearID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Summary> Summaries { get; set; }
        public virtual SchoolYear SchoolYear { get; set; }
    }
}
