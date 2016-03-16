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
    
    public partial class strategy
    {
        public strategy()
        {
            this.exposure = new HashSet<exposure>();
            this.exposure_real_time = new HashSet<exposure_real_time>();
            this.impact_generation = new HashSet<impact_generation>();
            this.impact_generation_real_time = new HashSet<impact_generation_real_time>();
            this.limit = new HashSet<limit>();
            this.strategy_criteria = new HashSet<strategy_criteria>();
            this.strategy_exposure = new HashSet<strategy_exposure>();
        }
    
        public int strategy_id { get; set; }
        public string strategy_shortname { get; set; }
        public string strategy_description { get; set; }
        public int strategy_ccy { get; set; }
        public Nullable<int> internal_entity_id { get; set; }
        public Nullable<int> internal_segment_id { get; set; }
        public Nullable<int> iuser { get; set; }
        public Nullable<System.DateTime> idate { get; set; }
        public Nullable<int> uuser { get; set; }
        public Nullable<System.DateTime> udate { get; set; }
        public Nullable<int> duser { get; set; }
        public Nullable<System.DateTime> ddate { get; set; }
    
        public virtual currency currency { get; set; }
        public virtual ICollection<exposure> exposure { get; set; }
        public virtual ICollection<exposure_real_time> exposure_real_time { get; set; }
        public virtual ICollection<impact_generation> impact_generation { get; set; }
        public virtual ICollection<impact_generation_real_time> impact_generation_real_time { get; set; }
        public virtual internal_entity internal_entity { get; set; }
        public virtual internal_segment internal_segment { get; set; }
        public virtual ICollection<limit> limit { get; set; }
        public virtual ICollection<strategy_criteria> strategy_criteria { get; set; }
        public virtual ICollection<strategy_exposure> strategy_exposure { get; set; }
    }
}
