//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFAxeCreditFull
{
    using System;
    using System.Collections.Generic;
    
    public partial class limit_monitoring_mitigant
    {
        public int limit_monitoring_mitigant1 { get; set; }
        public int transaction_type_id { get; set; }
        public int status_id { get; set; }
        public string valuation_method { get; set; }
        public Nullable<decimal> mitigant_variation_percent { get; set; }
        public Nullable<decimal> facility_upgrade_percent { get; set; }
        public Nullable<int> iuser { get; set; }
        public Nullable<System.DateTime> idate { get; set; }
        public Nullable<int> uuser { get; set; }
        public Nullable<System.DateTime> udate { get; set; }
        public Nullable<int> duser { get; set; }
        public Nullable<System.DateTime> ddate { get; set; }
    
        public virtual status status { get; set; }
        public virtual transaction_type transaction_type { get; set; }
    }
}