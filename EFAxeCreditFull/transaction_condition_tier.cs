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
    
    public partial class transaction_condition_tier
    {
        public int transaction_condition_tier_id { get; set; }
        public int transaction_id { get; set; }
        public int status_id { get; set; }
        public Nullable<int> base_rate_id { get; set; }
        public Nullable<decimal> spread { get; set; }
        public string coupon_frequency { get; set; }
        public string accural_basis { get; set; }
        public Nullable<int> amortization_type_id { get; set; }
        public string amortization_frequency { get; set; }
        public string comment { get; set; }
        public Nullable<decimal> tier_notional_amount { get; set; }
        public Nullable<int> tier_notional_amount_ccy_id { get; set; }
        public Nullable<decimal> tier_outstanding_amount { get; set; }
        public Nullable<int> tier_outstanding_amount_ccy_id { get; set; }
        public Nullable<decimal> notional_amount { get; set; }
        public Nullable<int> notional_amount_ccy_id { get; set; }
        public Nullable<decimal> tier_installment { get; set; }
        public Nullable<int> tier_installment_ccy_id { get; set; }
        public Nullable<int> tenor { get; set; }
        public Nullable<System.DateTime> start_date { get; set; }
        public Nullable<System.DateTime> first_payment_date { get; set; }
        public Nullable<System.DateTime> end_date { get; set; }
        public Nullable<int> tier_rank { get; set; }
        public Nullable<decimal> commission { get; set; }
        public Nullable<int> commission_ccy_id { get; set; }
        public Nullable<decimal> management_fee { get; set; }
        public Nullable<int> management_fee_ccy_id { get; set; }
        public Nullable<int> grace_period { get; set; }
        public string grace_period_unit { get; set; }
        public Nullable<System.DateTime> status_date { get; set; }
        public Nullable<decimal> fixe { get; set; }
        public Nullable<int> security_deposit { get; set; }
        public string capitalization_interest_method { get; set; }
        public Nullable<int> days_interest_capitalization { get; set; }
        public Nullable<decimal> maximum_notional_amount { get; set; }
        public Nullable<int> maximum_notional_amount_ccy_id { get; set; }
        public Nullable<decimal> anticipated_spread { get; set; }
        public Nullable<decimal> anticipated_fixed_rate { get; set; }
        public string fees_effect { get; set; }
        public Nullable<decimal> rv_amount { get; set; }
        public Nullable<decimal> vat_rate { get; set; }
        public Nullable<bool> interim_interest { get; set; }
        public Nullable<decimal> residual_percentage { get; set; }
        public Nullable<decimal> withdrawal_rate { get; set; }
        public string repayment_term { get; set; }
        public Nullable<int> iuser { get; set; }
        public Nullable<System.DateTime> idate { get; set; }
        public Nullable<int> uuser { get; set; }
        public Nullable<System.DateTime> udate { get; set; }
        public Nullable<int> duser { get; set; }
        public Nullable<System.DateTime> ddate { get; set; }
    
        public virtual amortization_type amortization_type { get; set; }
        public virtual base_rate base_rate { get; set; }
        public virtual currency currency { get; set; }
        public virtual currency currency1 { get; set; }
        public virtual currency currency2 { get; set; }
        public virtual currency currency3 { get; set; }
        public virtual currency currency4 { get; set; }
        public virtual currency currency5 { get; set; }
        public virtual currency currency6 { get; set; }
        public virtual status status { get; set; }
        public virtual transaction transaction { get; set; }
    }
}