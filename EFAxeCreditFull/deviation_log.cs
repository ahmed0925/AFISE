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
    
    public partial class deviation_log
    {
        public int deviation_log_id { get; set; }
        public string item { get; set; }
        public int item_id { get; set; }
        public int task_id { get; set; }
        public string wf_name { get; set; }
        public string step_name { get; set; }
        public string deviated_msg { get; set; }
        public string deviation_comment { get; set; }
        public string required_documents { get; set; }
        public Nullable<int> iuser { get; set; }
        public Nullable<System.DateTime> idate { get; set; }
        public Nullable<int> uuser { get; set; }
        public Nullable<System.DateTime> udate { get; set; }
        public Nullable<int> duser { get; set; }
        public Nullable<System.DateTime> ddate { get; set; }
    }
}
