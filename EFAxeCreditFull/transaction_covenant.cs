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
    
    public partial class transaction_covenant
    {
        public transaction_covenant()
        {
            this.transaction_covenant_history = new HashSet<transaction_covenant_history>();
        }
    
        public int transaction_covenant_id { get; set; }
        public string transaction_covenant_shortname { get; set; }
        public int transaction_id { get; set; }
        public int covenant_id { get; set; }
        public Nullable<int> status_id { get; set; }
        public string @operator { get; set; }
        public Nullable<int> currency_id { get; set; }
        public Nullable<decimal> covenant_value { get; set; }
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
        public Nullable<System.DateTime> start_date { get; set; }
        public Nullable<System.DateTime> end_date { get; set; }
        public Nullable<System.DateTime> financial_data_date { get; set; }
    
        public virtual covenant covenant { get; set; }
        public virtual currency currency { get; set; }
        public virtual status status { get; set; }
        public virtual transaction transaction { get; set; }
        public virtual ICollection<transaction_covenant_history> transaction_covenant_history { get; set; }
    }
}
