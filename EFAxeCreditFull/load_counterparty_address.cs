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
    
    public partial class load_counterparty_address
    {
        public int load_counterparty_address_id { get; set; }
        public string load_counterparty_shortname { get; set; }
        public string load_address_type { get; set; }
        public string load_city { get; set; }
        public string load_default_address { get; set; }
        public string load_country_shortname { get; set; }
        public string load_zip_code { get; set; }
        public string load_gps { get; set; }
        public string load_address { get; set; }
        public string error_msg { get; set; }
        public Nullable<System.DateTime> interface_date { get; set; }
        public Nullable<bool> is_interfaced { get; set; }
    }
}