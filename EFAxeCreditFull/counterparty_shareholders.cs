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
    
    public partial class counterparty_shareholders
    {
        public int counterparty_shareholders_id { get; set; }
        public int counterparty_id { get; set; }
        public string shareholder { get; set; }
        public Nullable<int> share { get; set; }
        public Nullable<decimal> share_percentage { get; set; }
        public string address { get; set; }
        public Nullable<decimal> shareholder_amount { get; set; }
        public Nullable<int> shareholder_amount_ccy_id { get; set; }
        public Nullable<int> iuser { get; set; }
        public Nullable<System.DateTime> idate { get; set; }
        public Nullable<int> uuser { get; set; }
        public Nullable<System.DateTime> udate { get; set; }
        public Nullable<int> duser { get; set; }
        public Nullable<System.DateTime> ddate { get; set; }
    
        public virtual counterparty counterparty { get; set; }
        public virtual currency currency { get; set; }
    }
}