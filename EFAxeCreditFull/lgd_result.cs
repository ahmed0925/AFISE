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
    
    public partial class lgd_result
    {
        public int lgd_result_id { get; set; }
        public int transaction_id { get; set; }
        public System.DateTime calculation_date { get; set; }
        public string calculation_status { get; set; }
        public Nullable<decimal> minimum_lgd { get; set; }
        public Nullable<decimal> maximum_lgd { get; set; }
        public Nullable<decimal> collateral_guarantee_operating_cost { get; set; }
        public Nullable<decimal> other_means_operating_cost { get; set; }
        public Nullable<decimal> restructuring_operating_cost { get; set; }
        public Nullable<decimal> recovery_from_collateral { get; set; }
        public Nullable<decimal> recovery_from_guarantee { get; set; }
        public Nullable<decimal> recovery_from_other_means { get; set; }
        public Nullable<decimal> probability_of_non_restructuring { get; set; }
        public Nullable<decimal> average_pon_restructuring_recovery { get; set; }
        public Nullable<decimal> probability_of_Restructuring { get; set; }
        public Nullable<decimal> average_restructuring_recovery { get; set; }
        public Nullable<decimal> one_average_cure_rate { get; set; }
        public Nullable<decimal> total_recovery_rate { get; set; }
        public Nullable<decimal> average_cure_rate { get; set; }
        public Nullable<decimal> adjusted_recovery_rate { get; set; }
        public Nullable<decimal> estimated_lgd { get; set; }
        public string frr { get; set; }
        public Nullable<int> provision_currency { get; set; }
        public Nullable<decimal> provision_amount { get; set; }
        public string provision_type { get; set; }
        public Nullable<int> nb_months_backward { get; set; }
        public Nullable<int> iuser { get; set; }
        public Nullable<System.DateTime> idate { get; set; }
        public Nullable<int> uuser { get; set; }
        public Nullable<System.DateTime> udate { get; set; }
        public Nullable<int> duser { get; set; }
        public Nullable<System.DateTime> ddate { get; set; }
        public Nullable<decimal> provision_ifrs_amount { get; set; }
        public Nullable<int> provision_ifrs_ccy { get; set; }
        public string provision_ifrs_type { get; set; }
        public string comment { get; set; }
    
        public virtual currency currency { get; set; }
        public virtual transaction transaction { get; set; }
    }
}
