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
    
    public partial class PaymentReceiptMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PaymentReceiptMaster()
        {
            this.PaymentReceiptDetails = new HashSet<PaymentReceiptDetail>();
        }
    
        public long ID { get; set; }
        public long CompanyID { get; set; }
        public long DocumentID { get; set; }
        public Nullable<long> TransactionMasterID { get; set; }
        public string TransactionNo { get; set; }
        public Nullable<System.DateTime> TransactionDate { get; set; }
        public Nullable<long> PartyID { get; set; }
        public Nullable<decimal> BillAmount { get; set; }
        public Nullable<decimal> PayAmount { get; set; }
        public Nullable<decimal> DueAmount { get; set; }
        public string Remarks { get; set; }
    
        public virtual Company Company { get; set; }
        public virtual DocumentsList DocumentsList { get; set; }
        public virtual Party Party { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PaymentReceiptDetail> PaymentReceiptDetails { get; set; }
    }
}