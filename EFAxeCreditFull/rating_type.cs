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
    
    public partial class rating_type
    {
        public rating_type()
        {
            this.counterparty = new HashSet<counterparty>();
            this.rating = new HashSet<rating>();
            this.scoring_template = new HashSet<scoring_template>();
        }
    
        public int rating_type_id { get; set; }
        public int rating_agency_id { get; set; }
        public string rating_type_shortname { get; set; }
        public string rating_type_name { get; set; }
        public Nullable<int> iuser { get; set; }
        public Nullable<System.DateTime> idate { get; set; }
        public Nullable<int> uuser { get; set; }
        public Nullable<System.DateTime> udate { get; set; }
        public Nullable<int> duser { get; set; }
        public Nullable<System.DateTime> ddate { get; set; }
    
        public virtual ICollection<counterparty> counterparty { get; set; }
        public virtual ICollection<rating> rating { get; set; }
        public virtual rating_agency rating_agency { get; set; }
        public virtual ICollection<scoring_template> scoring_template { get; set; }
    }
}
