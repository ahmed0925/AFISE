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
    
    public partial class decision_tree_eligibility
    {
        public decision_tree_eligibility()
        {
            this.decision_tree_eligibility1 = new HashSet<decision_tree_eligibility>();
        }
    
        public int criteria_id { get; set; }
        public string criteria_shortname { get; set; }
        public Nullable<int> parent_id { get; set; }
        public string error { get; set; }
        public int criteria_field_id { get; set; }
        public string @operator { get; set; }
        public string value { get; set; }
        public bool deviation { get; set; }
        public Nullable<int> condition_id { get; set; }
        public Nullable<int> template { get; set; }
        public string audit_screen { get; set; }
        public Nullable<int> internal_entity_id { get; set; }
        public Nullable<int> internal_segment_id { get; set; }
        public Nullable<int> iuser { get; set; }
        public Nullable<System.DateTime> idate { get; set; }
        public Nullable<int> uuser { get; set; }
        public Nullable<System.DateTime> udate { get; set; }
        public Nullable<System.DateTime> ddate { get; set; }
        public Nullable<int> duser { get; set; }
    
        public virtual criteria_field criteria_field { get; set; }
        public virtual ICollection<decision_tree_eligibility> decision_tree_eligibility1 { get; set; }
        public virtual decision_tree_eligibility decision_tree_eligibility2 { get; set; }
        public virtual eligibility_condition eligibility_condition { get; set; }
        public virtual internal_entity internal_entity { get; set; }
        public virtual internal_segment internal_segment { get; set; }
    }
}