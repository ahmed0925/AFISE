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
    
    public partial class audit_trail
    {
        public int audit_trail_id { get; set; }
        public string screen { get; set; }
        public string action { get; set; }
        public string content { get; set; }
        public Nullable<System.DateTime> timestamp { get; set; }
        public Nullable<int> user_id { get; set; }
        public string workflow { get; set; }
        public string workflow_step { get; set; }
        public Nullable<int> status_id { get; set; }
        public Nullable<int> iuser { get; set; }
        public Nullable<System.DateTime> idate { get; set; }
        public Nullable<int> uuser { get; set; }
        public Nullable<System.DateTime> udate { get; set; }
        public Nullable<int> duser { get; set; }
        public Nullable<System.DateTime> ddate { get; set; }
    }
}
