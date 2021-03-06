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
    
    public partial class payment_posting
    {
        public int payment_posting_id { get; set; }
        public string payment_posting_shortname { get; set; }
        public Nullable<int> payment_id { get; set; }
        public Nullable<int> credit_event_id { get; set; }
        public Nullable<decimal> payment_posting_amount { get; set; }
        public Nullable<int> payment_posting_amount_ccy_id { get; set; }
        public Nullable<System.DateTime> payment_posting_date { get; set; }
        public Nullable<int> iuser { get; set; }
        public Nullable<System.DateTime> idate { get; set; }
        public Nullable<int> uuser { get; set; }
        public Nullable<System.DateTime> udate { get; set; }
        public Nullable<int> duser { get; set; }
        public Nullable<System.DateTime> ddate { get; set; }
    
        public virtual currency currency { get; set; }
        public virtual payment payment { get; set; }
        public virtual transaction_credit_event transaction_credit_event { get; set; }
    }
}
