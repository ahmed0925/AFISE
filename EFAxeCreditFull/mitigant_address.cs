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
    
    public partial class mitigant_address
    {
        public int mitigant_address_id { get; set; }
        public int mitigant_id { get; set; }
        public string address { get; set; }
        public string zip_code { get; set; }
        public string city { get; set; }
        public Nullable<int> country_id { get; set; }
        public Nullable<int> country_region_id { get; set; }
        public string address_type { get; set; }
        public Nullable<bool> default_address { get; set; }
        public Nullable<int> iuser { get; set; }
        public Nullable<System.DateTime> idate { get; set; }
        public Nullable<int> uuser { get; set; }
        public Nullable<System.DateTime> udate { get; set; }
        public Nullable<int> duser { get; set; }
        public Nullable<System.DateTime> ddate { get; set; }
    
        public virtual country country { get; set; }
        public virtual country_region country_region { get; set; }
        public virtual mitigant mitigant { get; set; }
    }
}
