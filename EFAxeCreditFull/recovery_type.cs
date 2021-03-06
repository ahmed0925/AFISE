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
    
    public partial class recovery_type
    {
        public recovery_type()
        {
            this.counterparty_add_data_litigation = new HashSet<counterparty_add_data_litigation>();
            this.recovery_type_fate = new HashSet<recovery_type_fate>();
            this.recovery_type_parameter_counterparty = new HashSet<recovery_type_parameter_counterparty>();
            this.transaction_recovery = new HashSet<transaction_recovery>();
        }
    
        public int recovery_type_id { get; set; }
        public string recovery_type_shortname { get; set; }
        public string recovery_type_description { get; set; }
        public Nullable<decimal> recovery_type_fees { get; set; }
        public Nullable<int> recovery_type_category_id { get; set; }
        public Nullable<int> internal_entity_id { get; set; }
        public Nullable<int> internal_segment_id { get; set; }
        public Nullable<int> iuser { get; set; }
        public Nullable<System.DateTime> idate { get; set; }
        public Nullable<int> uuser { get; set; }
        public Nullable<System.DateTime> udate { get; set; }
        public Nullable<int> duser { get; set; }
        public Nullable<System.DateTime> ddate { get; set; }
    
        public virtual ICollection<counterparty_add_data_litigation> counterparty_add_data_litigation { get; set; }
        public virtual internal_entity internal_entity { get; set; }
        public virtual internal_segment internal_segment { get; set; }
        public virtual ICollection<recovery_type_fate> recovery_type_fate { get; set; }
        public virtual ICollection<recovery_type_parameter_counterparty> recovery_type_parameter_counterparty { get; set; }
        public virtual recovery_type_category recovery_type_category { get; set; }
        public virtual ICollection<transaction_recovery> transaction_recovery { get; set; }
    }
}
