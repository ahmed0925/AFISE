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
    
    public partial class limit
    {
        public int limit_id { get; set; }
        public int strategy_id { get; set; }
        public int exposure_id { get; set; }
        public string limit_criteria_1 { get; set; }
        public string limit_criteria_2 { get; set; }
        public string limit_criteria_3 { get; set; }
        public string limit_criteria_4 { get; set; }
        public Nullable<decimal> limit_amount { get; set; }
        public Nullable<int> status_id { get; set; }
        public Nullable<System.DateTime> limit_expiry_date { get; set; }
        public Nullable<int> iuser { get; set; }
        public Nullable<System.DateTime> idate { get; set; }
        public Nullable<int> uuser { get; set; }
        public Nullable<System.DateTime> udate { get; set; }
        public Nullable<int> duser { get; set; }
        public Nullable<System.DateTime> ddate { get; set; }
    
        public virtual strategy_exposure strategy_exposure { get; set; }
        public virtual status status { get; set; }
        public virtual strategy strategy { get; set; }
    }
}