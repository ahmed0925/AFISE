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
    
    public partial class counterparty_internal_rating
    {
        public counterparty_internal_rating()
        {
            this.counterparty_internal_rating_warning = new HashSet<counterparty_internal_rating_warning>();
            this.counterparty_internal_rating1 = new HashSet<counterparty_internal_rating>();
        }
    
        public int counterparty_internal_rating_id { get; set; }
        public int counterparty_id { get; set; }
        public int rating_id { get; set; }
        public Nullable<int> scoring_session_id { get; set; }
        public Nullable<int> scoring_status_id { get; set; }
        public int status_id { get; set; }
        public Nullable<System.DateTime> rating_date { get; set; }
        public string rating_method { get; set; }
        public string comment { get; set; }
        public Nullable<System.DateTime> status_date { get; set; }
        public Nullable<int> user_id { get; set; }
        public Nullable<decimal> counterparty_pd { get; set; }
        public Nullable<int> iuser { get; set; }
        public Nullable<System.DateTime> idate { get; set; }
        public Nullable<int> uuser { get; set; }
        public Nullable<System.DateTime> udate { get; set; }
        public Nullable<int> duser { get; set; }
        public Nullable<System.DateTime> ddate { get; set; }
        public Nullable<decimal> scoring_value { get; set; }
        public string rating_outlook { get; set; }
        public string ceiling_rating_value { get; set; }
        public string initial_rating_value { get; set; }
        public Nullable<int> initial_internal_rating_id { get; set; }
        public Nullable<decimal> counterparty_lgd { get; set; }
        public Nullable<decimal> counterparty_el { get; set; }
        public Nullable<decimal> counterparty_capital_charge { get; set; }
    
        public virtual counterparty counterparty { get; set; }
        public virtual rating rating { get; set; }
        public virtual scoring_session scoring_session { get; set; }
        public virtual status status { get; set; }
        public virtual software_user software_user { get; set; }
        public virtual status status1 { get; set; }
        public virtual ICollection<counterparty_internal_rating_warning> counterparty_internal_rating_warning { get; set; }
        public virtual ICollection<counterparty_internal_rating> counterparty_internal_rating1 { get; set; }
        public virtual counterparty_internal_rating counterparty_internal_rating2 { get; set; }
    }
}
