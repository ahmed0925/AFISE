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
    
    public partial class qualitative_node
    {
        public qualitative_node()
        {
            this.qualitative_structure = new HashSet<qualitative_structure>();
            this.qualitative_structure1 = new HashSet<qualitative_structure>();
        }
    
        public int qualitative_node_id { get; set; }
        public string qualitative_node_shortname { get; set; }
        public string qualitative_node_name { get; set; }
        public string qualitative_node_description { get; set; }
        public Nullable<decimal> weight { get; set; }
        public Nullable<int> iuser { get; set; }
        public Nullable<System.DateTime> idate { get; set; }
        public Nullable<int> uuser { get; set; }
        public Nullable<System.DateTime> udate { get; set; }
        public Nullable<int> duser { get; set; }
        public Nullable<System.DateTime> ddate { get; set; }
    
        public virtual ICollection<qualitative_structure> qualitative_structure { get; set; }
        public virtual ICollection<qualitative_structure> qualitative_structure1 { get; set; }
    }
}