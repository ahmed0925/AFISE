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
    
    public partial class bkp_financial_mitigant_recovery
    {
        public int bkp_financial_mitigant_recovery_id { get; set; }
        public System.DateTime bkp_financial_mitigant_recovery_date { get; set; }
        public int transaction_type_id { get; set; }
        public Nullable<decimal> less_one_year { get; set; }
        public Nullable<decimal> one_tofive_year { get; set; }
        public Nullable<decimal> more_five_year { get; set; }
    
        public virtual transaction_type transaction_type { get; set; }
    }
}
