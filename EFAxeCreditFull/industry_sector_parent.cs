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
    
    public partial class industry_sector_parent
    {
        public int industry_sector_id { get; set; }
        public int parent_id { get; set; }
        public int link_type_id { get; set; }
        public int sequence_id { get; set; }
        public Nullable<int> internal_entity_id { get; set; }
        public Nullable<int> internal_segment_id { get; set; }
        public Nullable<int> iuser { get; set; }
        public Nullable<System.DateTime> idate { get; set; }
        public Nullable<int> uuser { get; set; }
        public Nullable<System.DateTime> udate { get; set; }
        public Nullable<int> duser { get; set; }
        public Nullable<System.DateTime> ddate { get; set; }
    
        public virtual industry_sector industry_sector { get; set; }
        public virtual internal_entity internal_entity { get; set; }
        public virtual internal_segment internal_segment { get; set; }
        public virtual link_type link_type { get; set; }
    }
}
