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
    
    public partial class TB_Categories
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_Categories()
        {
            this.TB_Buy = new HashSet<TB_Buy>();
        }
    
        public int ID { get; set; }
        public Nullable<int> IDGroups { get; set; }
        public string CatName { get; set; }
        public string CatGroup { get; set; }
        public string CatDes { get; set; }
        public Nullable<double> CatQuantity { get; set; }
        public Nullable<System.DateTime> CatDate { get; set; }
    
        public virtual TB_Groups TB_Groups { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_Buy> TB_Buy { get; set; }
    }
}