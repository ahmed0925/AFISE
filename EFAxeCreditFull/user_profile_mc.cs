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
    
    public partial class user_profile_mc
    {
        public int sequence_id { get; set; }
        public Nullable<int> user_id { get; set; }
        public Nullable<int> profile_id { get; set; }
        public Nullable<bool> supervisor { get; set; }
        public Nullable<bool> validation_flag { get; set; }
        public Nullable<int> iuser { get; set; }
        public Nullable<System.DateTime> idate { get; set; }
        public Nullable<int> uuser { get; set; }
        public Nullable<System.DateTime> udate { get; set; }
        public Nullable<int> duser { get; set; }
        public Nullable<System.DateTime> ddate { get; set; }
    
        public virtual profile profile { get; set; }
        public virtual software_user software_user { get; set; }
    }
}
