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
    
    public partial class transaction_recovery_mitigant
    {
        public int transaction_recovery_id { get; set; }
        public int mitigant_id { get; set; }
        public int sequence_id { get; set; }
        public Nullable<decimal> mitigation_amount { get; set; }
        public Nullable<int> mitigation_amount_ccy { get; set; }
        public Nullable<int> iuser { get; set; }
        public Nullable<System.DateTime> idate { get; set; }
        public Nullable<int> uuser { get; set; }
        public Nullable<System.DateTime> udate { get; set; }
        public Nullable<int> duser { get; set; }
        public Nullable<System.DateTime> ddate { get; set; }
    
        public virtual currency currency { get; set; }
        public virtual mitigant mitigant { get; set; }
        public virtual transaction_recovery transaction_recovery { get; set; }
    }
}
