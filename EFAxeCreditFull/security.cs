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
    
    public partial class security
    {
        public security()
        {
            this.mitigant = new HashSet<mitigant>();
            this.mitigant_collateral = new HashSet<mitigant_collateral>();
            this.security_quote = new HashSet<security_quote>();
        }
    
        public int security_id { get; set; }
        public string security_shortname { get; set; }
        public string security_name { get; set; }
        public string security_description { get; set; }
        public Nullable<int> issuer_id { get; set; }
        public Nullable<bool> listed { get; set; }
        public string external_reference { get; set; }
        public Nullable<int> internal_entity_id { get; set; }
        public Nullable<int> internal_segment_id { get; set; }
        public Nullable<int> iuser { get; set; }
        public Nullable<System.DateTime> idate { get; set; }
        public Nullable<int> uuser { get; set; }
        public Nullable<System.DateTime> udate { get; set; }
        public Nullable<int> duser { get; set; }
        public Nullable<System.DateTime> ddate { get; set; }
        public string default_source { get; set; }
        public string default_unit { get; set; }
        public Nullable<decimal> default_quantity { get; set; }
        public Nullable<decimal> default_quote { get; set; }
        public Nullable<int> default_quote_ccy { get; set; }
        public string default_market { get; set; }
    
        public virtual counterparty counterparty { get; set; }
        public virtual currency currency { get; set; }
        public virtual internal_entity internal_entity { get; set; }
        public virtual internal_segment internal_segment { get; set; }
        public virtual ICollection<mitigant> mitigant { get; set; }
        public virtual ICollection<mitigant_collateral> mitigant_collateral { get; set; }
        public virtual ICollection<security_quote> security_quote { get; set; }
    }
}
