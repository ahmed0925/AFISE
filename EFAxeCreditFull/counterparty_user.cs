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
    
    public partial class counterparty_user
    {
        public int counterparty_user_id { get; set; }
        public Nullable<int> counterparty_id { get; set; }
        public Nullable<int> user_id { get; set; }
        public string role { get; set; }
        public string comment { get; set; }
        public Nullable<System.DateTime> start_date { get; set; }
        public Nullable<System.DateTime> end_date { get; set; }
        public Nullable<int> iuser { get; set; }
        public Nullable<System.DateTime> idate { get; set; }
        public Nullable<int> uuser { get; set; }
        public Nullable<System.DateTime> udate { get; set; }
        public Nullable<int> duser { get; set; }
        public Nullable<System.DateTime> ddate { get; set; }
    
        public virtual counterparty counterparty { get; set; }
        public virtual software_user software_user { get; set; }
    }
}
