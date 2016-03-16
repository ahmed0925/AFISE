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
    
    public partial class impact_generation
    {
        public int strategy_id { get; set; }
        public int exposure_id { get; set; }
        public int transaction_id { get; set; }
        public int combinaison_id { get; set; }
        public string impact_criteria_1 { get; set; }
        public string impact_criteria_2 { get; set; }
        public string impact_criteria_3 { get; set; }
        public string impact_criteria_4 { get; set; }
        public Nullable<decimal> transaction_exposure_amount { get; set; }
        public int sequence_id { get; set; }
        public Nullable<int> iuser { get; set; }
        public Nullable<System.DateTime> idate { get; set; }
        public Nullable<int> uuser { get; set; }
        public Nullable<System.DateTime> udate { get; set; }
        public Nullable<int> duser { get; set; }
        public Nullable<System.DateTime> ddate { get; set; }
        public Nullable<System.DateTime> calculation_date { get; set; }
    
        public virtual strategy_exposure strategy_exposure { get; set; }
        public virtual strategy strategy { get; set; }
        public virtual transaction transaction { get; set; }
    }
}
