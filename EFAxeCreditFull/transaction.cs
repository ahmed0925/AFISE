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
    
    public partial class transaction
    {
        public transaction()
        {
            this.accounting_output = new HashSet<accounting_output>();
            this.bkt_lgd_history = new HashSet<bkt_lgd_history>();
            this.core_banking = new HashSet<core_banking>();
            this.counterparty_credit_state_history = new HashSet<counterparty_credit_state_history>();
            this.credit_file_transaction = new HashSet<credit_file_transaction>();
            this.impact_generation = new HashSet<impact_generation>();
            this.impact_generation_real_time = new HashSet<impact_generation_real_time>();
            this.lgd_result = new HashSet<lgd_result>();
            this.limit_transaction_curve = new HashSet<limit_transaction_curve>();
            this.mitigant_transaction = new HashSet<mitigant_transaction>();
            this.transaction_action = new HashSet<transaction_action>();
            this.transaction_amount = new HashSet<transaction_amount>();
            this.transaction_condition_tier = new HashSet<transaction_condition_tier>();
            this.transaction_condition = new HashSet<transaction_condition>();
            this.transaction_covenant = new HashSet<transaction_covenant>();
            this.transaction_cpty = new HashSet<transaction_cpty>();
            this.transaction_credit_event = new HashSet<transaction_credit_event>();
            this.transaction_excess = new HashSet<transaction_excess>();
            this.transaction_generic = new HashSet<transaction_generic>();
            this.transaction_overtaken = new HashSet<transaction_overtaken>();
            this.transaction_rating = new HashSet<transaction_rating>();
            this.transaction_reallocation = new HashSet<transaction_reallocation>();
            this.transaction_reallocation1 = new HashSet<transaction_reallocation>();
            this.transaction_reallocation2 = new HashSet<transaction_reallocation>();
            this.transaction_related_utilizations = new HashSet<transaction_related_utilizations>();
            this.transaction_user = new HashSet<transaction_user>();
        }
    
        public int transaction_id { get; set; }
        public string transaction_shortname { get; set; }
        public string transaction_name { get; set; }
        public Nullable<int> transaction_type_id { get; set; }
        public Nullable<int> internal_entity_id { get; set; }
        public Nullable<int> internal_segment_id { get; set; }
        public Nullable<int> counterparty_id { get; set; }
        public Nullable<System.DateTime> start_date { get; set; }
        public Nullable<System.DateTime> end_date { get; set; }
        public Nullable<System.DateTime> previous_renew_date { get; set; }
        public Nullable<System.DateTime> next_renew_date { get; set; }
        public string renew_frequency { get; set; }
        public string purpose { get; set; }
        public string comment { get; set; }
        public Nullable<int> user_id { get; set; }
        public Nullable<int> status_id { get; set; }
        public Nullable<bool> committed { get; set; }
        public Nullable<bool> cancellable { get; set; }
        public Nullable<bool> irrevocable { get; set; }
        public Nullable<bool> revolving { get; set; }
        public string seniority { get; set; }
        public Nullable<decimal> origination_lgd { get; set; }
        public Nullable<decimal> recalculated_lgd { get; set; }
        public Nullable<System.DateTime> lgd_recalculation_date { get; set; }
        public string lgd_recalculation_status { get; set; }
        public Nullable<decimal> back_tested_lgd { get; set; }
        public Nullable<System.DateTime> back_testing_date { get; set; }
        public Nullable<decimal> rwa { get; set; }
        public Nullable<int> rwa_ccy_id { get; set; }
        public Nullable<decimal> ead { get; set; }
        public Nullable<int> ead_ccy_id { get; set; }
        public Nullable<bool> past_due { get; set; }
        public Nullable<System.DateTime> past_due_start_date { get; set; }
        public Nullable<bool> non_performing { get; set; }
        public Nullable<System.DateTime> non_performing_start_date { get; set; }
        public Nullable<bool> impaired { get; set; }
        public Nullable<System.DateTime> impaired_start_date { get; set; }
        public Nullable<int> asset_class_id { get; set; }
        public string external_reference { get; set; }
        public Nullable<decimal> provision_amount { get; set; }
        public Nullable<int> provision_ccy_id { get; set; }
        public Nullable<bool> incomplete_documentation { get; set; }
        public Nullable<decimal> outstanding_amount { get; set; }
        public Nullable<int> outstanding_ccy_id { get; set; }
        public string provision_type { get; set; }
        public Nullable<decimal> loan_to_value { get; set; }
        public Nullable<int> tenor { get; set; }
        public Nullable<System.DateTime> first_payment_date { get; set; }
        public string opinion { get; set; }
        public Nullable<decimal> self_financing { get; set; }
        public Nullable<int> self_financing_ccy_id { get; set; }
        public Nullable<int> specific_agreement_id { get; set; }
        public Nullable<decimal> revenue { get; set; }
        public Nullable<int> revenue_ccy_id { get; set; }
        public Nullable<decimal> partner_revenue { get; set; }
        public Nullable<int> partner_revenue_ccy_id { get; set; }
        public Nullable<decimal> credit_installment_amount { get; set; }
        public Nullable<int> credit_installment_amount_ccy_id { get; set; }
        public string credit_installment_frequency { get; set; }
        public Nullable<decimal> other_installment_amount { get; set; }
        public Nullable<int> other_installment_amount_ccy_id { get; set; }
        public string other_installment_frequency { get; set; }
        public Nullable<decimal> client_capacity { get; set; }
        public Nullable<decimal> current_due_amount { get; set; }
        public Nullable<int> current_due_amount_ccy_id { get; set; }
        public string beneficiary { get; set; }
        public string counterparty_account1 { get; set; }
        public Nullable<decimal> counterparty_account_credit1 { get; set; }
        public Nullable<System.DateTime> counterparty_account_date1 { get; set; }
        public Nullable<int> counterparty_account_credit_ccy_id1 { get; set; }
        public string counterparty_account2 { get; set; }
        public Nullable<decimal> counterparty_account_credit2 { get; set; }
        public Nullable<System.DateTime> counterparty_account_date2 { get; set; }
        public Nullable<int> counterparty_account_credit_ccy_id2 { get; set; }
        public Nullable<decimal> net_salary { get; set; }
        public Nullable<int> net_salary_ccy_id { get; set; }
        public Nullable<decimal> spouse_net_salary { get; set; }
        public Nullable<int> spouse_net_salary_ccy_id { get; set; }
        public Nullable<decimal> annual_turnover { get; set; }
        public Nullable<int> annual_turnover_ccy_id { get; set; }
        public Nullable<decimal> profit_margin { get; set; }
        public string emergency { get; set; }
        public string application_type { get; set; }
        public string deviations { get; set; }
        public Nullable<System.DateTime> contract_signature_date { get; set; }
        public string payment_method { get; set; }
        public Nullable<int> sourced_by { get; set; }
        public Nullable<int> classification_id { get; set; }
        public Nullable<int> iuser { get; set; }
        public Nullable<System.DateTime> idate { get; set; }
        public Nullable<int> uuser { get; set; }
        public Nullable<System.DateTime> udate { get; set; }
        public Nullable<int> duser { get; set; }
        public Nullable<System.DateTime> ddate { get; set; }
        public Nullable<int> state_id { get; set; }
        public Nullable<decimal> provision_ifrs_amount { get; set; }
        public Nullable<int> provision_ifrs_ccy { get; set; }
        public string provision_ifrs_type { get; set; }
        public string comment2 { get; set; }
    
        public virtual ICollection<accounting_output> accounting_output { get; set; }
        public virtual asset_class asset_class { get; set; }
        public virtual ICollection<bkt_lgd_history> bkt_lgd_history { get; set; }
        public virtual classification classification { get; set; }
        public virtual ICollection<core_banking> core_banking { get; set; }
        public virtual counterparty counterparty { get; set; }
        public virtual ICollection<counterparty_credit_state_history> counterparty_credit_state_history { get; set; }
        public virtual ICollection<credit_file_transaction> credit_file_transaction { get; set; }
        public virtual currency currency { get; set; }
        public virtual currency currency1 { get; set; }
        public virtual currency currency2 { get; set; }
        public virtual currency currency3 { get; set; }
        public virtual currency currency4 { get; set; }
        public virtual currency currency5 { get; set; }
        public virtual currency currency6 { get; set; }
        public virtual currency currency7 { get; set; }
        public virtual currency currency8 { get; set; }
        public virtual currency currency9 { get; set; }
        public virtual currency currency10 { get; set; }
        public virtual currency currency11 { get; set; }
        public virtual currency currency12 { get; set; }
        public virtual currency currency13 { get; set; }
        public virtual currency currency14 { get; set; }
        public virtual ICollection<impact_generation> impact_generation { get; set; }
        public virtual ICollection<impact_generation_real_time> impact_generation_real_time { get; set; }
        public virtual internal_entity internal_entity { get; set; }
        public virtual internal_segment internal_segment { get; set; }
        public virtual ICollection<lgd_result> lgd_result { get; set; }
        public virtual ICollection<limit_transaction_curve> limit_transaction_curve { get; set; }
        public virtual ICollection<mitigant_transaction> mitigant_transaction { get; set; }
        public virtual software_user software_user { get; set; }
        public virtual software_user software_user1 { get; set; }
        public virtual specific_agreement specific_agreement { get; set; }
        public virtual status status { get; set; }
        public virtual status status1 { get; set; }
        public virtual ICollection<transaction_action> transaction_action { get; set; }
        public virtual ICollection<transaction_amount> transaction_amount { get; set; }
        public virtual transaction_comment transaction_comment { get; set; }
        public virtual ICollection<transaction_condition_tier> transaction_condition_tier { get; set; }
        public virtual ICollection<transaction_condition> transaction_condition { get; set; }
        public virtual ICollection<transaction_covenant> transaction_covenant { get; set; }
        public virtual ICollection<transaction_cpty> transaction_cpty { get; set; }
        public virtual ICollection<transaction_credit_event> transaction_credit_event { get; set; }
        public virtual ICollection<transaction_excess> transaction_excess { get; set; }
        public virtual ICollection<transaction_generic> transaction_generic { get; set; }
        public virtual ICollection<transaction_overtaken> transaction_overtaken { get; set; }
        public virtual ICollection<transaction_rating> transaction_rating { get; set; }
        public virtual ICollection<transaction_reallocation> transaction_reallocation { get; set; }
        public virtual ICollection<transaction_reallocation> transaction_reallocation1 { get; set; }
        public virtual ICollection<transaction_reallocation> transaction_reallocation2 { get; set; }
        public virtual ICollection<transaction_related_utilizations> transaction_related_utilizations { get; set; }
        public virtual transaction_type transaction_type { get; set; }
        public virtual ICollection<transaction_user> transaction_user { get; set; }
    }
}
