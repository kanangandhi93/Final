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
    
    public partial class ItemGroup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ItemGroup()
        {
            this.ItemGroup1 = new HashSet<ItemGroup>();
            this.ItemMasters = new HashSet<ItemMaster>();
        }
    
        public long ID { get; set; }
        public long CompanyID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Nullable<long> ParentGroupID { get; set; }
    
        public virtual Company Company { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemGroup> ItemGroup1 { get; set; }
        public virtual ItemGroup ItemGroup2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemMaster> ItemMasters { get; set; }
    }
}