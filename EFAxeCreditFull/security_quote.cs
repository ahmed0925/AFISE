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
    
    public partial class security_quote
    {
        public int security_quote_id { get; set; }
        public Nullable<int> security_id { get; set; }
        public Nullable<System.DateTime> quote_date { get; set; }
        public string quote_source { get; set; }
        public string market { get; set; }
        public Nullable<decimal> quantity { get; set; }
        public Nullable<decimal> quote { get; set; }
        public Nullable<int> quote_ccy_id { get; set; }
        public string external_reference { get; set; }
        public Nullable<int> iuser { get; set; }
        public Nullable<System.DateTime> idate { get; set; }
        public Nullable<int> uuser { get; set; }
        public Nullable<System.DateTime> udate { get; set; }
        public Nullable<int> duser { get; set; }
        public Nullable<System.DateTime> ddate { get; set; }
    
        public virtual currency currency { get; set; }
        public virtual security security { get; set; }
    }
}
