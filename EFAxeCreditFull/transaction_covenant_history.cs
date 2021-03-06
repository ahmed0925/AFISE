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
    
    public partial class transaction_covenant_history
    {
        public int transaction_covenant_history_id { get; set; }
        public string transaction_covenant_history_shortname { get; set; }
        public Nullable<int> transaction_covenant_id { get; set; }
        public Nullable<int> status_id { get; set; }
        public string @operator { get; set; }
        public Nullable<int> currency_id { get; set; }
        public Nullable<decimal> covenant_value { get; set; }
        public Nullable<decimal> checked_value { get; set; }
        public Nullable<decimal> margin { get; set; }
        public string review_frequency { get; set; }
        public Nullable<System.DateTime> next_review_date { get; set; }
        public string comment { get; set; }
        public Nullable<int> iuser { get; set; }
        public Nullable<System.DateTime> idate { get; set; }
        public Nullable<int> uuser { get; set; }
        public Nullable<System.DateTime> udate { get; set; }
        public Nullable<int> duser { get; set; }
        public Nullable<System.DateTime> ddate { get; set; }
    
        public virtual currency currency { get; set; }
        public virtual status status { get; set; }
        public virtual transaction_covenant transaction_covenant { get; set; }
    }
}
