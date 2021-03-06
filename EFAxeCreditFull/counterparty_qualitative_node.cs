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
    
    public partial class counterparty_qualitative_node
    {
        public int counterparty_qualitative_node_id { get; set; }
        public int counterparty_id { get; set; }
        public int qualitative_structure_id { get; set; }
        public Nullable<int> scoring_session_id { get; set; }
        public Nullable<int> status_id { get; set; }
        public Nullable<decimal> node_score { get; set; }
        public Nullable<decimal> adjusted_node_score { get; set; }
        public Nullable<int> iuser { get; set; }
        public Nullable<System.DateTime> idate { get; set; }
        public Nullable<int> uuser { get; set; }
        public Nullable<System.DateTime> udate { get; set; }
        public Nullable<int> duser { get; set; }
        public Nullable<System.DateTime> ddate { get; set; }
        public string adjustment_comment { get; set; }
    
        public virtual counterparty counterparty { get; set; }
        public virtual qualitative_structure qualitative_structure { get; set; }
        public virtual scoring_session scoring_session { get; set; }
    }
}
