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
    
    public partial class warning_signal
    {
        public warning_signal()
        {
            this.counterparty_internal_rating_warning = new HashSet<counterparty_internal_rating_warning>();
            this.scoring_template_warning = new HashSet<scoring_template_warning>();
        }
    
        public int warning_signal_id { get; set; }
        public string warning_signal_shortname { get; set; }
        public string warning_signal_name { get; set; }
        public string warning_signal_description { get; set; }
        public Nullable<int> internal_entity_id { get; set; }
        public Nullable<int> internal_segment_id { get; set; }
        public Nullable<int> iuser { get; set; }
        public Nullable<System.DateTime> idate { get; set; }
        public Nullable<int> uuser { get; set; }
        public Nullable<System.DateTime> udate { get; set; }
        public Nullable<int> duser { get; set; }
        public Nullable<System.DateTime> ddate { get; set; }
    
        public virtual ICollection<counterparty_internal_rating_warning> counterparty_internal_rating_warning { get; set; }
        public virtual internal_entity internal_entity { get; set; }
        public virtual internal_segment internal_segment { get; set; }
        public virtual ICollection<scoring_template_warning> scoring_template_warning { get; set; }
    }
}
