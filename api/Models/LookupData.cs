//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace api.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class LookupData
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LookupData()
        {
            this.LookupData1 = new HashSet<LookupData>();
        }
    
        public long ID { get; set; }
        public Nullable<long> CompanyID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Nullable<long> ParentID { get; set; }
    
        public virtual Company Company { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LookupData> LookupData1 { get; set; }
        public virtual LookupData LookupData2 { get; set; }
    }
}