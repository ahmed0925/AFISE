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
    
    public partial class base_rate
    {
        public base_rate()
        {
            this.base_rate_value = new HashSet<base_rate_value>();
            this.credit_file_condition = new HashSet<credit_file_condition>();
            this.pricing_condition = new HashSet<pricing_condition>();
            this.transaction_condition = new HashSet<transaction_condition>();
            this.transaction_condition_tier = new HashSet<transaction_condition_tier>();
            this.transaction_type = new HashSet<transaction_type>();
        }
    
        public int base_rate_id { get; set; }
        public string base_rate_shortname { get; set; }
        public string base_rate_type { get; set; }
        public Nullable<int> internal_entity_id { get; set; }
        public Nullable<int> internal_segment_id { get; set; }
        public Nullable<int> iuser { get; set; }
        public Nullable<System.DateTime> idate { get; set; }
        public Nullable<int> uuser { get; set; }
        public Nullable<System.DateTime> udate { get; set; }
        public Nullable<int> duser { get; set; }
        public Nullable<System.DateTime> ddate { get; set; }
    
        public virtual internal_entity internal_entity { get; set; }
        public virtual internal_segment internal_segment { get; set; }
        public virtual ICollection<base_rate_value> base_rate_value { get; set; }
        public virtual ICollection<credit_file_condition> credit_file_condition { get; set; }
        public virtual ICollection<pricing_condition> pricing_condition { get; set; }
        public virtual ICollection<transaction_condition> transaction_condition { get; set; }
        public virtual ICollection<transaction_condition_tier> transaction_condition_tier { get; set; }
        public virtual ICollection<transaction_type> transaction_type { get; set; }
    }
}
