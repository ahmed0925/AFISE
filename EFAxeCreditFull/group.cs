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
    
    public partial class group
    {
        public group()
        {
            this.group_access_right = new HashSet<group_access_right>();
            this.group_access_right_mc = new HashSet<group_access_right_mc>();
            this.user_group = new HashSet<user_group>();
            this.user_group_mc = new HashSet<user_group_mc>();
            this.wf_task_dispatch = new HashSet<wf_task_dispatch>();
        }
    
        public int group_id { get; set; }
        public string group_shortname { get; set; }
        public string group_name { get; set; }
        public Nullable<int> internal_entity_id { get; set; }
        public Nullable<int> internal_segment_id { get; set; }
        public Nullable<int> iuser { get; set; }
        public Nullable<System.DateTime> idate { get; set; }
        public Nullable<int> uuser { get; set; }
        public Nullable<System.DateTime> udate { get; set; }
        public Nullable<int> duser { get; set; }
        public Nullable<System.DateTime> ddate { get; set; }
    
        public virtual ICollection<group_access_right> group_access_right { get; set; }
        public virtual ICollection<group_access_right_mc> group_access_right_mc { get; set; }
        public virtual internal_entity internal_entity { get; set; }
        public virtual internal_segment internal_segment { get; set; }
        public virtual ICollection<user_group> user_group { get; set; }
        public virtual ICollection<user_group_mc> user_group_mc { get; set; }
        public virtual ICollection<wf_task_dispatch> wf_task_dispatch { get; set; }
    }
}
