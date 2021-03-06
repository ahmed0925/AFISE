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
    
    public partial class sms_out
    {
        public int sms_id { get; set; }
        public Nullable<System.DateTime> creation_date { get; set; }
        public Nullable<System.DateTime> sending_date { get; set; }
        public string message_body { get; set; }
        public string destination_number { get; set; }
        public string workflow { get; set; }
        public string workflow_step { get; set; }
        public Nullable<int> item_id { get; set; }
        public Nullable<int> marketing_campaign_id { get; set; }
        public string acknowledgment { get; set; }
        public string status { get; set; }
        public Nullable<bool> source { get; set; }
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
        public virtual marketing_campaign marketing_campaign { get; set; }
    }
}
