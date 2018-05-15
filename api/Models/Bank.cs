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
    
    public partial class Bank
    {
        public long ID { get; set; }
        public string BankName { get; set; }
        public string IFSCCode { get; set; }
        public string MICRCode { get; set; }
        public string BranchAddress { get; set; }
        public string ContactNo { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public Nullable<long> StateID { get; set; }
        public Nullable<long> CountryID { get; set; }
    
        public virtual Bank Bank1 { get; set; }
        public virtual Bank Bank2 { get; set; }
        public virtual State State { get; set; }
    }
}
