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
    
    public partial class software_user_mc
    {
        public int sequence_id { get; set; }
        public Nullable<int> user_id { get; set; }
        public string user_shortname { get; set; }
        public string user_name { get; set; }
        public string position { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string mobile { get; set; }
        public string password { get; set; }
        public string home_user_config { get; set; }
        public string culture_language { get; set; }
        public Nullable<int> internal_entity_id { get; set; }
        public Nullable<int> internal_segment_id { get; set; }
        public Nullable<int> iuser { get; set; }
        public Nullable<System.DateTime> idate { get; set; }
        public Nullable<int> uuser { get; set; }
        public Nullable<System.DateTime> udate { get; set; }
        public Nullable<int> duser { get; set; }
        public Nullable<System.DateTime> ddate { get; set; }
        public Nullable<bool> isactive { get; set; }
        public string external_ref1 { get; set; }
        public Nullable<bool> validation_flag { get; set; }
        public Nullable<bool> deletion_flag { get; set; }
        public Nullable<bool> mobile_access { get; set; }
    
        public virtual internal_entity internal_entity { get; set; }
        public virtual internal_segment internal_segment { get; set; }
    }
}