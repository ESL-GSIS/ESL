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
    
    public partial class StudentLanguage
    {
        public int ID { get; set; }
        public int StudentID { get; set; }
        public Nullable<int> Language1 { get; set; }
        public Nullable<int> Language2 { get; set; }
        public Nullable<int> Language3 { get; set; }
    
        public virtual Language Language { get; set; }
        public virtual Language Language4 { get; set; }
        public virtual Language Language5 { get; set; }
        public virtual Student Student { get; set; }
    }
}
