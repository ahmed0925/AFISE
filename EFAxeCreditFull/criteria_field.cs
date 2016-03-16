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
    
    public partial class criteria_field
    {
        public criteria_field()
        {
            this.decision_tree_eligibility = new HashSet<decision_tree_eligibility>();
            this.eligibility_criteria = new HashSet<eligibility_criteria>();
            this.log_deviation = new HashSet<log_deviation>();
        }
    
        public int criteria_field_id { get; set; }
        public string criteria_field_name { get; set; }
        public string criteria_field_type { get; set; }
        public string criteria_field_SQL_value { get; set; }
        public string criteria_field_SQL_value_DBList { get; set; }
        public Nullable<int> internal_entity_id { get; set; }
        public Nullable<int> internal_segment_id { get; set; }
        public Nullable<int> iuser { get; set; }
        public Nullable<System.DateTime> idate { get; set; }
        public Nullable<int> uuser { get; set; }
        public Nullable<System.DateTime> udate { get; set; }
        public Nullable<System.DateTime> ddate { get; set; }
        public Nullable<int> duser { get; set; }
    
        public virtual internal_entity internal_entity { get; set; }
        public virtual internal_segment internal_segment { get; set; }
        public virtual ICollection<decision_tree_eligibility> decision_tree_eligibility { get; set; }
        public virtual ICollection<eligibility_criteria> eligibility_criteria { get; set; }
        public virtual ICollection<log_deviation> log_deviation { get; set; }
    }
}
