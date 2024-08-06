//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EPS
{
    using System;
    using System.Collections.Generic;
    
    public partial class TB_Buy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_Buy()
        {
            this.TB_Paymentsbuy = new HashSet<TB_Paymentsbuy>();
        }
    
        public int ID { get; set; }
        public Nullable<int> ID_Catgeory { get; set; }
        public Nullable<int> ID_Supplier { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Supplier { get; set; }
        public Nullable<double> Quantity { get; set; }
        public string BarcodeValue { get; set; }
        public byte[] BarcodeImage { get; set; }
        public Nullable<double> CashSellPrimary { get; set; }
        public Nullable<double> CashSellSecondry { get; set; }
        public Nullable<double> BuyPrimary { get; set; }
        public Nullable<double> BuySecondry { get; set; }
        public Nullable<double> SupplierPyment { get; set; }
        public Nullable<double> BuyAllValue { get; set; }
        public Nullable<double> SellAllValue { get; set; }
        public Nullable<double> Benfit { get; set; }
        public byte[] Cover { get; set; }
        public Nullable<System.DateTime> DateAdd { get; set; }
        public Nullable<double> CreditSellPrimary { get; set; }
        public Nullable<double> CreditSellSecondry { get; set; }
        public string Description { get; set; }
        public Nullable<double> SupplierPyment1 { get; set; }
    
        public virtual TB_Categories TB_Categories { get; set; }
        public virtual TB_Suppliers TB_Suppliers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_Paymentsbuy> TB_Paymentsbuy { get; set; }
    }
}