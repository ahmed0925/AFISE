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
    
    public partial class account_type
    {
        public account_type()
        {
            this.counterparty_account = new HashSet<counterparty_account>();
            this.counterparty = new HashSet<counterparty>();
        }
    
        public int account_type_id { get; set; }
        public string account_type_shortname { get; set; }
        public string account_type_description { get; set; }
        public string account_type_searchcounterparty { get; set; }
        public Nullable<int> internal_entity_id { get; set; }
        public Nullable<int> internal_segment_id { get; set; }
        public Nullable<int> iuser { get; set; }
        public Nullable<System.DateTime> idate { get; set; }
        public Nullable<int> uuser { get; set; }
        public Nullable<System.DateTime> udate { get; set; }
        public Nullable<int> duser { get; set; }
        public Nullable<System.DateTime> ddate { get; set; }
    
        public virtual internal_entity internal_entity { get; set; }
        public virtual internal_segment internal_segment { get; set; }
        public virtual ICollection<counterparty_account> counterparty_account { get; set; }
        public virtual ICollection<counterparty> counterparty { get; set; }
    }
}
