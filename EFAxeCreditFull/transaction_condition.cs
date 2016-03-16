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
    
    public partial class transaction_condition
    {
        public transaction_condition()
        {
            this.transaction_condition_fees = new HashSet<transaction_condition_fees>();
        }
    
        public int transaction_id { get; set; }
        public int status_id { get; set; }
        public Nullable<int> base_rate_id { get; set; }
        public Nullable<decimal> spread { get; set; }
        public string coupon_frequency { get; set; }
        public string accural_basis { get; set; }
        public Nullable<decimal> commission { get; set; }
        public Nullable<int> commission_ccy_id { get; set; }
        public Nullable<decimal> management_fee { get; set; }
        public Nullable<int> management_fee_ccy_id { get; set; }
        public Nullable<int> grace_period { get; set; }
        public string grace_period_unit { get; set; }
        public Nullable<int> amortization_type_id { get; set; }
        public string amortization_frequency { get; set; }
        public string comment { get; set; }
        public Nullable<System.DateTime> status_date { get; set; }
        public Nullable<int> user_id { get; set; }
        public Nullable<decimal> notional_amount { get; set; }
        public Nullable<int> notional_amount_ccy_id { get; set; }
        public Nullable<decimal> fixe { get; set; }
        public Nullable<int> security_deposit { get; set; }
        public string capitalization_interest_method { get; set; }
        public Nullable<int> days_interest_capitalization { get; set; }
        public Nullable<System.DateTime> start_date { get; set; }
        public Nullable<System.DateTime> first_payment_date { get; set; }
        public Nullable<int> tenor { get; set; }
        public Nullable<System.DateTime> end_date { get; set; }
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
        public int sequence_id { get; set; }
        public Nullable<int> iuser { get; set; }
        public Nullable<System.DateTime> idate { get; set; }
        public Nullable<int> uuser { get; set; }
        public Nullable<System.DateTime> udate { get; set; }
        public Nullable<int> duser { get; set; }
        public Nullable<System.DateTime> ddate { get; set; }
        public string repayment_term { get; set; }
        public Nullable<bool> multi_tier { get; set; }
        public string principal_grace_period_type { get; set; }
        public string interest_grace_period_type { get; set; }
        public Nullable<int> principal_grace_period { get; set; }
        public Nullable<int> interest_grace_period { get; set; }
        public Nullable<bool> consider_holidays { get; set; }
        public Nullable<decimal> advance_payment { get; set; }
        public Nullable<int> advance_payment_ccy { get; set; }
        public string advance_payment_mode { get; set; }
        public Nullable<System.DateTime> manual_maturity_date { get; set; }
        public string tenor_unit { get; set; }
    
        public virtual amortization_type amortization_type { get; set; }
        public virtual base_rate base_rate { get; set; }
        public virtual currency currency { get; set; }
        public virtual currency currency1 { get; set; }
        public virtual currency currency2 { get; set; }
        public virtual currency currency3 { get; set; }
        public virtual currency currency4 { get; set; }
        public virtual software_user software_user { get; set; }
        public virtual status status { get; set; }
        public virtual transaction transaction { get; set; }
        public virtual ICollection<transaction_condition_fees> transaction_condition_fees { get; set; }
    }
}