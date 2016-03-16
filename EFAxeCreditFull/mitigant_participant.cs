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
    
    public partial class mitigant_participant
    {
        public int mitigant_id { get; set; }
        public int participant_id { get; set; }
        public int participant_type_id { get; set; }
        public string participant_role { get; set; }
        public Nullable<decimal> amount { get; set; }
        public Nullable<int> amount_ccy_id { get; set; }
        public Nullable<decimal> percentage { get; set; }
        public Nullable<bool> children_flag { get; set; }
        public int sequence_id { get; set; }
        public Nullable<int> iuser { get; set; }
        public Nullable<System.DateTime> idate { get; set; }
        public Nullable<int> uuser { get; set; }
        public Nullable<System.DateTime> udate { get; set; }
        public Nullable<int> duser { get; set; }
        public Nullable<System.DateTime> ddate { get; set; }
    
        public virtual counterparty counterparty { get; set; }
        public virtual currency currency { get; set; }
        public virtual mitigant mitigant { get; set; }
        public virtual participant_type participant_type { get; set; }
    }
}
