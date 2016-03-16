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
    
    public partial class mitigant_transaction
    {
        public int mitigant_id { get; set; }
        public int transaction_id { get; set; }
        public Nullable<bool> children_flag { get; set; }
        public Nullable<decimal> mitigation_percentage { get; set; }
        public Nullable<decimal> mitigation_amount { get; set; }
        public Nullable<int> mitigation_currency { get; set; }
        public Nullable<System.DateTime> registration_date { get; set; }
        public Nullable<System.DateTime> release_date { get; set; }
        public Nullable<System.DateTime> rejection_date { get; set; }
        public int sequence_id { get; set; }
        public Nullable<int> iuser { get; set; }
        public Nullable<System.DateTime> idate { get; set; }
        public Nullable<int> uuser { get; set; }
        public Nullable<System.DateTime> udate { get; set; }
        public Nullable<int> duser { get; set; }
        public Nullable<System.DateTime> ddate { get; set; }
        public Nullable<int> status_id { get; set; }
    
        public virtual currency currency { get; set; }
        public virtual mitigant mitigant { get; set; }
        public virtual status status { get; set; }
        public virtual transaction transaction { get; set; }
    }
}
