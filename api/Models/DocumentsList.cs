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
    
    public partial class DocumentsList
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DocumentsList()
        {
            this.DocumentsDetails = new HashSet<DocumentsDetail>();
            this.ItemStockDetails = new HashSet<ItemStockDetail>();
            this.PaymentReceiptMasters = new HashSet<PaymentReceiptMaster>();
        }
    
        public long ID { get; set; }
        public string DocCode { get; set; }
        public string DocName { get; set; }
        public long TransactionType { get; set; }
        public Nullable<int> EffectPlusMinus { get; set; }
        public string Separator { get; set; }
        public Nullable<bool> ISMonthly { get; set; }
        public string MonthFormat { get; set; }
        public string YearFormat { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocumentsDetail> DocumentsDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemStockDetail> ItemStockDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PaymentReceiptMaster> PaymentReceiptMasters { get; set; }
    }
}
