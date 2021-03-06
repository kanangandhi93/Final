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
    
    public partial class Company
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Company()
        {
            this.CompanyTerms = new HashSet<CompanyTerm>();
            this.FinancialYears = new HashSet<FinancialYear>();
            this.ItemGroups = new HashSet<ItemGroup>();
            this.ItemMasters = new HashSet<ItemMaster>();
            this.LookupDatas = new HashSet<LookupData>();
            this.Parties = new HashSet<Party>();
            this.PaymentReceiptDetails = new HashSet<PaymentReceiptDetail>();
            this.PaymentReceiptDetails1 = new HashSet<PaymentReceiptDetail>();
            this.PaymentReceiptMasters = new HashSet<PaymentReceiptMaster>();
            this.Units = new HashSet<Unit>();
            this.UnitConversions = new HashSet<UnitConversion>();
        }
    
        public long ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Nullable<long> OrganizationTypeID { get; set; }
        public string BranchName { get; set; }
        public Nullable<long> IndustryType { get; set; }
        public Nullable<long> BusinessType { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public Nullable<long> StateID { get; set; }
        public Nullable<long> CountryID { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string ContactPerson { get; set; }
        public string MfgLicenceNo { get; set; }
        public Nullable<System.DateTime> MfgLicenceExpDate { get; set; }
        public string DrugLicenceNo { get; set; }
        public Nullable<System.DateTime> DrugLicenceExpDate { get; set; }
        public string FoodLicenceNo { get; set; }
        public Nullable<System.DateTime> FoodLicenceExpDate { get; set; }
        public string GSTIN { get; set; }
        public Nullable<System.DateTime> GSTINExpDate { get; set; }
        public string TAN { get; set; }
        public Nullable<System.DateTime> TANExpDate { get; set; }
        public string PAN { get; set; }
        public Nullable<int> RegistrationType { get; set; }
        public string RegistrationNo { get; set; }
        public Nullable<int> TaxStructureID { get; set; }
        public Nullable<int> FinancialYearID { get; set; }
        public Nullable<int> StockValuationTypeID { get; set; }
        public string Jurisdiction { get; set; }
        public Nullable<long> BaseCurrencyID { get; set; }
        public Nullable<long> ParentID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompanyTerm> CompanyTerms { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FinancialYear> FinancialYears { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemGroup> ItemGroups { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemMaster> ItemMasters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LookupData> LookupDatas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Party> Parties { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PaymentReceiptDetail> PaymentReceiptDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PaymentReceiptDetail> PaymentReceiptDetails1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PaymentReceiptMaster> PaymentReceiptMasters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Unit> Units { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UnitConversion> UnitConversions { get; set; }
    }
}
