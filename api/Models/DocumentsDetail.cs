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
    
    public partial class DocumentsDetail
    {
        public long ID { get; set; }
        public Nullable<long> DocumentID { get; set; }
        public Nullable<long> FinancialYearID { get; set; }
        public string MonthNo { get; set; }
        public Nullable<int> StartNo { get; set; }
        public Nullable<int> CurrentNo { get; set; }
    
        public virtual DocumentsList DocumentsList { get; set; }
        public virtual FinancialYear FinancialYear { get; set; }
    }
}
