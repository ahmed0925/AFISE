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
    
    public partial class bkt_time_to_recovery_history
    {
        public int bkt_time_to_recovery_history_id { get; set; }
        public System.DateTime bkt_date { get; set; }
        public System.DateTime start_date { get; set; }
        public System.DateTime end_date { get; set; }
        public Nullable<decimal> tolerance_rate { get; set; }
        public int transaction_type_id { get; set; }
        public Nullable<decimal> estimated_recovery { get; set; }
        public Nullable<decimal> backtested_recovery { get; set; }
        public string traffic { get; set; }
        public Nullable<int> iuser { get; set; }
        public Nullable<System.DateTime> idate { get; set; }
        public Nullable<int> uuser { get; set; }
        public Nullable<System.DateTime> udate { get; set; }
        public Nullable<int> duser { get; set; }
        public Nullable<System.DateTime> ddate { get; set; }
    
        public virtual transaction_type transaction_type { get; set; }
    }
}