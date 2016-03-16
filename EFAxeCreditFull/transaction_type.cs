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
    
    public partial class transaction_type
    {
        public transaction_type()
        {
            this.bkp_financial_mitigant_recovery = new HashSet<bkp_financial_mitigant_recovery>();
            this.bkp_mitigant_time_to_recovery = new HashSet<bkp_mitigant_time_to_recovery>();
            this.bkt_ccf_history = new HashSet<bkt_ccf_history>();
            this.bkt_financial_mitigant_history = new HashSet<bkt_financial_mitigant_history>();
            this.bkt_time_to_recovery_history = new HashSet<bkt_time_to_recovery_history>();
            this.core_banking = new HashSet<core_banking>();
            this.credit_file = new HashSet<credit_file>();
            this.eligibility_condition = new HashSet<eligibility_condition>();
            this.financial_mitigant_recovery = new HashSet<financial_mitigant_recovery>();
            this.limit_monitoring_mitigant = new HashSet<limit_monitoring_mitigant>();
            this.mitigant = new HashSet<mitigant>();
            this.mitigant_time_to_recovery = new HashSet<mitigant_time_to_recovery>();
            this.mitigant_transaction_type = new HashSet<mitigant_transaction_type>();
            this.outstanding = new HashSet<outstanding>();
            this.participant_type = new HashSet<participant_type>();
            this.transaction = new HashSet<transaction>();
            this.transaction_excess = new HashSet<transaction_excess>();
            this.transaction_limit_monitoring = new HashSet<transaction_limit_monitoring>();
            this.transaction_overtaken = new HashSet<transaction_overtaken>();
            this.transaction_reallocation = new HashSet<transaction_reallocation>();
            this.transaction_related_utilizations = new HashSet<transaction_related_utilizations>();
            this.transaction_type_fees = new HashSet<transaction_type_fees>();
            this.transaction_type_agreement = new HashSet<transaction_type_agreement>();
            this.transaction_type_eligibility_condition = new HashSet<transaction_type_eligibility_condition>();
            this.transaction_type_hierarchy = new HashSet<transaction_type_hierarchy>();
            this.transaction_type_reporting = new HashSet<transaction_type_reporting>();
            this.transaction_type_document = new HashSet<transaction_type_document>();
            this.transaction_type_workflow = new HashSet<transaction_type_workflow>();
        }
    
        public int transaction_type_id { get; set; }
        public string transaction_type_shortname { get; set; }
        public string transaction_type_name { get; set; }
        public string transaction_category { get; set; }
        public string transaction_sub_category { get; set; }
        public Nullable<decimal> recovery_rate { get; set; }
        public Nullable<decimal> ccf { get; set; }
        public string transaction_type_formula { get; set; }
        public string formula { get; set; }
        public Nullable<int> base_rate_id { get; set; }
        public Nullable<decimal> spread { get; set; }
        public string coupon_frequency { get; set; }
        public string accural_basis { get; set; }
        public Nullable<int> amortization_type_id { get; set; }
        public string amortization_frequency { get; set; }
        public Nullable<decimal> fixe { get; set; }
        public string capitalization_interest_method { get; set; }
        public Nullable<decimal> amount_min { get; set; }
        public Nullable<decimal> amount_max { get; set; }
        public Nullable<decimal> duration_min { get; set; }
        public Nullable<decimal> duration_max { get; set; }
        public Nullable<decimal> rate_min { get; set; }
        public Nullable<decimal> rate_max { get; set; }
        public Nullable<bool> blocking { get; set; }
        public string classification { get; set; }
        public Nullable<int> grace_period { get; set; }
        public string account_type { get; set; }
        public Nullable<int> min_required_period_saving_account { get; set; }
        public Nullable<decimal> min_balance_savings { get; set; }
        public Nullable<int> relative_savings_credit_balance_credit_amount { get; set; }
        public Nullable<decimal> rate_amount_max { get; set; }
        public Nullable<decimal> anticipated_spread { get; set; }
        public Nullable<decimal> anticipated_fixed_rate { get; set; }
        public Nullable<int> int1 { get; set; }
        public Nullable<bool> anticipated_rate_is_final { get; set; }
        public Nullable<System.DateTime> start_date { get; set; }
        public Nullable<System.DateTime> end_date { get; set; }
        public string agreement_type { get; set; }
        public Nullable<decimal> rv_amount { get; set; }
        public Nullable<decimal> vat_rate { get; set; }
        public Nullable<bool> activated { get; set; }
        public Nullable<decimal> dbr { get; set; }
        public Nullable<int> classification_id { get; set; }
        public Nullable<int> internal_entity_id { get; set; }
        public Nullable<int> internal_segment_id { get; set; }
        public Nullable<int> iuser { get; set; }
        public Nullable<System.DateTime> idate { get; set; }
        public Nullable<int> uuser { get; set; }
        public Nullable<System.DateTime> udate { get; set; }
        public Nullable<int> duser { get; set; }
        public Nullable<System.DateTime> ddate { get; set; }
        public string currency_group { get; set; }
        public Nullable<int> disbursement_period_max { get; set; }
        public Nullable<decimal> penality_rate { get; set; }
        public Nullable<bool> early_redemption { get; set; }
        public Nullable<decimal> early_redemption_rate { get; set; }
        public Nullable<bool> islamic { get; set; }
        public string comment { get; set; }
        public string external_reference { get; set; }
        public Nullable<int> specific_agreement_id { get; set; }
        public string external_ref1 { get; set; }
        public Nullable<int> min_month_saving_account { get; set; }
        public string external_ref2 { get; set; }
        public string external_ref3 { get; set; }
        public Nullable<int> tenor { get; set; }
        public Nullable<decimal> commission { get; set; }
        public Nullable<int> commission_ccy_id { get; set; }
    
        public virtual amortization_type amortization_type { get; set; }
        public virtual base_rate base_rate { get; set; }
        public virtual ICollection<bkp_financial_mitigant_recovery> bkp_financial_mitigant_recovery { get; set; }
        public virtual ICollection<bkp_mitigant_time_to_recovery> bkp_mitigant_time_to_recovery { get; set; }
        public virtual ICollection<bkt_ccf_history> bkt_ccf_history { get; set; }
        public virtual ICollection<bkt_financial_mitigant_history> bkt_financial_mitigant_history { get; set; }
        public virtual ICollection<bkt_time_to_recovery_history> bkt_time_to_recovery_history { get; set; }
        public virtual classification classification1 { get; set; }
        public virtual ICollection<core_banking> core_banking { get; set; }
        public virtual ICollection<credit_file> credit_file { get; set; }
        public virtual currency currency { get; set; }
        public virtual ICollection<eligibility_condition> eligibility_condition { get; set; }
        public virtual ICollection<financial_mitigant_recovery> financial_mitigant_recovery { get; set; }
        public virtual internal_entity internal_entity { get; set; }
        public virtual internal_segment internal_segment { get; set; }
        public virtual ICollection<limit_monitoring_mitigant> limit_monitoring_mitigant { get; set; }
        public virtual ICollection<mitigant> mitigant { get; set; }
        public virtual ICollection<mitigant_time_to_recovery> mitigant_time_to_recovery { get; set; }
        public virtual ICollection<mitigant_transaction_type> mitigant_transaction_type { get; set; }
        public virtual ICollection<outstanding> outstanding { get; set; }
        public virtual ICollection<participant_type> participant_type { get; set; }
        public virtual specific_agreement specific_agreement { get; set; }
        public virtual ICollection<transaction> transaction { get; set; }
        public virtual ICollection<transaction_excess> transaction_excess { get; set; }
        public virtual ICollection<transaction_limit_monitoring> transaction_limit_monitoring { get; set; }
        public virtual ICollection<transaction_overtaken> transaction_overtaken { get; set; }
        public virtual ICollection<transaction_reallocation> transaction_reallocation { get; set; }
        public virtual ICollection<transaction_related_utilizations> transaction_related_utilizations { get; set; }
        public virtual ICollection<transaction_type_fees> transaction_type_fees { get; set; }
        public virtual ICollection<transaction_type_agreement> transaction_type_agreement { get; set; }
        public virtual ICollection<transaction_type_eligibility_condition> transaction_type_eligibility_condition { get; set; }
        public virtual ICollection<transaction_type_hierarchy> transaction_type_hierarchy { get; set; }
        public virtual ICollection<transaction_type_reporting> transaction_type_reporting { get; set; }
        public virtual ICollection<transaction_type_document> transaction_type_document { get; set; }
        public virtual ICollection<transaction_type_workflow> transaction_type_workflow { get; set; }
    }
}