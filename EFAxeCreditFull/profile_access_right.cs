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
    
    public partial class profile_access_right
    {
        public int profile_access_right_id { get; set; }
        public bool read_right { get; set; }
        public bool create_right { get; set; }
        public bool update_right { get; set; }
        public bool run_wf { get; set; }
        public Nullable<int> profile_id { get; set; }
        public Nullable<int> screen_id { get; set; }
        public bool delete_right { get; set; }
        public Nullable<int> iuser { get; set; }
        public Nullable<System.DateTime> idate { get; set; }
        public Nullable<int> uuser { get; set; }
        public Nullable<System.DateTime> udate { get; set; }
        public Nullable<int> duser { get; set; }
        public Nullable<System.DateTime> ddate { get; set; }
    
        public virtual profile profile { get; set; }
        public virtual profile profile1 { get; set; }
        public virtual screen screen { get; set; }
        public virtual screen screen1 { get; set; }
    }
}
