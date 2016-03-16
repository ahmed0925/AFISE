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
    
    public partial class counterparty_category
    {
        public counterparty_category()
        {
            this.counterparty = new HashSet<counterparty>();
            this.financial_data_model = new HashSet<financial_data_model>();
            this.transaction_cpty = new HashSet<transaction_cpty>();
        }
    
        public int counterparty_category_id { get; set; }
        public string counterparty_category_shortname { get; set; }
        public string counterparty_category_name { get; set; }
        public Nullable<int> iuser { get; set; }
        public Nullable<System.DateTime> idate { get; set; }
        public Nullable<int> uuser { get; set; }
        public Nullable<System.DateTime> udate { get; set; }
        public Nullable<int> duser { get; set; }
        public Nullable<System.DateTime> ddate { get; set; }
    
        public virtual ICollection<counterparty> counterparty { get; set; }
        public virtual ICollection<financial_data_model> financial_data_model { get; set; }
        public virtual ICollection<transaction_cpty> transaction_cpty { get; set; }
    }
}