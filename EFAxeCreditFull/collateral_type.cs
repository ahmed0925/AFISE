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
    
    public partial class collateral_type
    {
        public collateral_type()
        {
            this.mitigant_collateral = new HashSet<mitigant_collateral>();
            this.mitigant = new HashSet<mitigant>();
        }
    
        public int collateral_type_id { get; set; }
        public string collateral_type_shortname { get; set; }
        public string collateral_type_name { get; set; }
        public string collateral_category { get; set; }
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
        public virtual ICollection<mitigant_collateral> mitigant_collateral { get; set; }
        public virtual ICollection<mitigant> mitigant { get; set; }
    }
}
