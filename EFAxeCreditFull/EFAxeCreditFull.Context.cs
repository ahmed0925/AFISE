﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AxeCreditConnection : DbContext
    {
        public AxeCreditConnection()
            : base("name=AxeCreditConnection")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<account_type> account_type { get; set; }
        public virtual DbSet<accounting_output> accounting_output { get; set; }
        public virtual DbSet<acp_parameters> acp_parameters { get; set; }
        public virtual DbSet<action_type> action_type { get; set; }
        public virtual DbSet<additional_data> additional_data { get; set; }
        public virtual DbSet<additional_data_domain> additional_data_domain { get; set; }
        public virtual DbSet<additional_data_profiles> additional_data_profiles { get; set; }
        public virtual DbSet<aggregation_criteria> aggregation_criteria { get; set; }
        public virtual DbSet<amortization_type> amortization_type { get; set; }
        public virtual DbSet<arrangement_type> arrangement_type { get; set; }
        public virtual DbSet<asset_class> asset_class { get; set; }
        public virtual DbSet<audit_trail> audit_trail { get; set; }
        public virtual DbSet<base_rate> base_rate { get; set; }
        public virtual DbSet<base_rate_value> base_rate_value { get; set; }
        public virtual DbSet<bkp_constant> bkp_constant { get; set; }
        public virtual DbSet<bkp_estimated_probability> bkp_estimated_probability { get; set; }
        public virtual DbSet<bkp_financial_mitigant_recovery> bkp_financial_mitigant_recovery { get; set; }
        public virtual DbSet<bkp_mitigant_time_to_recovery> bkp_mitigant_time_to_recovery { get; set; }
        public virtual DbSet<bkp_transaction_rating_el> bkp_transaction_rating_el { get; set; }
        public virtual DbSet<bkt_ccf_history> bkt_ccf_history { get; set; }
        public virtual DbSet<bkt_cure_probability_history> bkt_cure_probability_history { get; set; }
        public virtual DbSet<bkt_discriminatory_history> bkt_discriminatory_history { get; set; }
        public virtual DbSet<bkt_discriminatory_history_detail> bkt_discriminatory_history_detail { get; set; }
        public virtual DbSet<bkt_financial_mitigant_history> bkt_financial_mitigant_history { get; set; }
        public virtual DbSet<bkt_lgd_history> bkt_lgd_history { get; set; }
        public virtual DbSet<bkt_pd_history> bkt_pd_history { get; set; }
        public virtual DbSet<bkt_pd_history_detail> bkt_pd_history_detail { get; set; }
        public virtual DbSet<bkt_rest_probability_history> bkt_rest_probability_history { get; set; }
        public virtual DbSet<bkt_time_to_recovery_history> bkt_time_to_recovery_history { get; set; }
        public virtual DbSet<classification> classification { get; set; }
        public virtual DbSet<collateral_type> collateral_type { get; set; }
        public virtual DbSet<collect_question> collect_question { get; set; }
        public virtual DbSet<combinaison_hierarchy_criteria_1> combinaison_hierarchy_criteria_1 { get; set; }
        public virtual DbSet<combinaison_hierarchy_criteria_2> combinaison_hierarchy_criteria_2 { get; set; }
        public virtual DbSet<combinaison_hierarchy_criteria_3> combinaison_hierarchy_criteria_3 { get; set; }
        public virtual DbSet<combinaison_hierarchy_criteria_4> combinaison_hierarchy_criteria_4 { get; set; }
        public virtual DbSet<commodity> commodity { get; set; }
        public virtual DbSet<commodity_quote> commodity_quote { get; set; }
        public virtual DbSet<communication_log> communication_log { get; set; }
        public virtual DbSet<confidence_index> confidence_index { get; set; }
        public virtual DbSet<constant_matrix> constant_matrix { get; set; }
        public virtual DbSet<constants> constants { get; set; }
        public virtual DbSet<core_banking> core_banking { get; set; }
        public virtual DbSet<counterparty> counterparty { get; set; }
        public virtual DbSet<counterparty_account> counterparty_account { get; set; }
        public virtual DbSet<counterparty_action> counterparty_action { get; set; }
        public virtual DbSet<counterparty_add_data> counterparty_add_data { get; set; }
        public virtual DbSet<counterparty_add_data_litigation> counterparty_add_data_litigation { get; set; }
        public virtual DbSet<counterparty_address> counterparty_address { get; set; }
        public virtual DbSet<counterparty_amount> counterparty_amount { get; set; }
        public virtual DbSet<counterparty_category> counterparty_category { get; set; }
        public virtual DbSet<counterparty_classification> counterparty_classification { get; set; }
        public virtual DbSet<counterparty_comment> counterparty_comment { get; set; }
        public virtual DbSet<counterparty_contacts> counterparty_contacts { get; set; }
        public virtual DbSet<counterparty_cpty> counterparty_cpty { get; set; }
        public virtual DbSet<counterparty_credit_state_history> counterparty_credit_state_history { get; set; }
        public virtual DbSet<counterparty_external_rating> counterparty_external_rating { get; set; }
        public virtual DbSet<counterparty_financial_data> counterparty_financial_data { get; set; }
        public virtual DbSet<counterparty_financial_structure> counterparty_financial_structure { get; set; }
        public virtual DbSet<counterparty_generic> counterparty_generic { get; set; }
        public virtual DbSet<counterparty_internal_rating> counterparty_internal_rating { get; set; }
        public virtual DbSet<counterparty_internal_rating_warning> counterparty_internal_rating_warning { get; set; }
        public virtual DbSet<counterparty_parent> counterparty_parent { get; set; }
        public virtual DbSet<counterparty_qualitative_data> counterparty_qualitative_data { get; set; }
        public virtual DbSet<counterparty_qualitative_element> counterparty_qualitative_element { get; set; }
        public virtual DbSet<counterparty_qualitative_node> counterparty_qualitative_node { get; set; }
        public virtual DbSet<counterparty_shareholders> counterparty_shareholders { get; set; }
        public virtual DbSet<counterparty_type> counterparty_type { get; set; }
        public virtual DbSet<counterparty_user> counterparty_user { get; set; }
        public virtual DbSet<country> country { get; set; }
        public virtual DbSet<country_group> country_group { get; set; }
        public virtual DbSet<country_link> country_link { get; set; }
        public virtual DbSet<country_region> country_region { get; set; }
        public virtual DbSet<covenant> covenant { get; set; }
        public virtual DbSet<credit_event_type> credit_event_type { get; set; }
        public virtual DbSet<credit_file> credit_file { get; set; }
        public virtual DbSet<credit_file_add_data> credit_file_add_data { get; set; }
        public virtual DbSet<credit_file_comment> credit_file_comment { get; set; }
        public virtual DbSet<credit_file_condition> credit_file_condition { get; set; }
        public virtual DbSet<credit_file_condition_fees> credit_file_condition_fees { get; set; }
        public virtual DbSet<credit_file_covenant> credit_file_covenant { get; set; }
        public virtual DbSet<credit_file_cpty> credit_file_cpty { get; set; }
        public virtual DbSet<credit_file_generic> credit_file_generic { get; set; }
        public virtual DbSet<credit_file_mitigant> credit_file_mitigant { get; set; }
        public virtual DbSet<credit_file_opinion> credit_file_opinion { get; set; }
        public virtual DbSet<credit_file_rating> credit_file_rating { get; set; }
        public virtual DbSet<credit_file_transaction> credit_file_transaction { get; set; }
        public virtual DbSet<credit_file_user> credit_file_user { get; set; }
        public virtual DbSet<criteria_field> criteria_field { get; set; }
        public virtual DbSet<currency> currency { get; set; }
        public virtual DbSet<currency_exchange_rate> currency_exchange_rate { get; set; }
        public virtual DbSet<decision_tree_eligibility> decision_tree_eligibility { get; set; }
        public virtual DbSet<deviation_log> deviation_log { get; set; }
        public virtual DbSet<document_category> document_category { get; set; }
        public virtual DbSet<document_sub_category> document_sub_category { get; set; }
        public virtual DbSet<economic_sector> economic_sector { get; set; }
        public virtual DbSet<economic_sector_parent> economic_sector_parent { get; set; }
        public virtual DbSet<eligibility_condition> eligibility_condition { get; set; }
        public virtual DbSet<eligibility_criteria> eligibility_criteria { get; set; }
        public virtual DbSet<eligibility_criteria_fields> eligibility_criteria_fields { get; set; }
        public virtual DbSet<email_out> email_out { get; set; }
        public virtual DbSet<enforcing_log> enforcing_log { get; set; }
        public virtual DbSet<estimated_probabilities> estimated_probabilities { get; set; }
        public virtual DbSet<estimated_probabilities_his> estimated_probabilities_his { get; set; }
        public virtual DbSet<estimated_probability> estimated_probability { get; set; }
        public virtual DbSet<exposure> exposure { get; set; }
        public virtual DbSet<exposure_real_time> exposure_real_time { get; set; }
        public virtual DbSet<fields_access_right> fields_access_right { get; set; }
        public virtual DbSet<fields_access_right_mc> fields_access_right_mc { get; set; }
        public virtual DbSet<file_upload> file_upload { get; set; }
        public virtual DbSet<financial_analysis_session> financial_analysis_session { get; set; }
        public virtual DbSet<financial_benchmark> financial_benchmark { get; set; }
        public virtual DbSet<financial_data_category> financial_data_category { get; set; }
        public virtual DbSet<financial_data_element> financial_data_element { get; set; }
        public virtual DbSet<financial_data_forecast_formula> financial_data_forecast_formula { get; set; }
        public virtual DbSet<financial_data_forecast_model> financial_data_forecast_model { get; set; }
        public virtual DbSet<financial_data_formula> financial_data_formula { get; set; }
        public virtual DbSet<financial_data_model> financial_data_model { get; set; }
        public virtual DbSet<financial_data_structure> financial_data_structure { get; set; }
        public virtual DbSet<financial_data_type> financial_data_type { get; set; }
        public virtual DbSet<financial_element> financial_element { get; set; }
        public virtual DbSet<financial_element_scoring_tier> financial_element_scoring_tier { get; set; }
        public virtual DbSet<financial_forecast_scenario> financial_forecast_scenario { get; set; }
        public virtual DbSet<financial_forecasting> financial_forecasting { get; set; }
        public virtual DbSet<financial_mitigant_recovery> financial_mitigant_recovery { get; set; }
        public virtual DbSet<financial_node> financial_node { get; set; }
        public virtual DbSet<financial_stress_scenario> financial_stress_scenario { get; set; }
        public virtual DbSet<financial_structure> financial_structure { get; set; }
        public virtual DbSet<financial_structure_benchmark> financial_structure_benchmark { get; set; }
        public virtual DbSet<financial_structure_forecast_scenario> financial_structure_forecast_scenario { get; set; }
        public virtual DbSet<financial_structure_stress_scenario> financial_structure_stress_scenario { get; set; }
        public virtual DbSet<financial_template> financial_template { get; set; }
        public virtual DbSet<folder_structuring> folder_structuring { get; set; }
        public virtual DbSet<group> group { get; set; }
        public virtual DbSet<group_access_right> group_access_right { get; set; }
        public virtual DbSet<group_access_right_mc> group_access_right_mc { get; set; }
        public virtual DbSet<group_mc> group_mc { get; set; }
        public virtual DbSet<holidays_config> holidays_config { get; set; }
        public virtual DbSet<html_to_image> html_to_image { get; set; }
        public virtual DbSet<impact_generation> impact_generation { get; set; }
        public virtual DbSet<impact_generation_real_time> impact_generation_real_time { get; set; }
        public virtual DbSet<industry_sector> industry_sector { get; set; }
        public virtual DbSet<industry_sector_parent> industry_sector_parent { get; set; }
        public virtual DbSet<internal_entity> internal_entity { get; set; }
        public virtual DbSet<internal_entity_group> internal_entity_group { get; set; }
        public virtual DbSet<internal_entity_parent> internal_entity_parent { get; set; }
        public virtual DbSet<internal_segment> internal_segment { get; set; }
        public virtual DbSet<internal_segment_parent> internal_segment_parent { get; set; }
        public virtual DbSet<item_lock> item_lock { get; set; }
        public virtual DbSet<lgd_result> lgd_result { get; set; }
        public virtual DbSet<limit> limit { get; set; }
        public virtual DbSet<limit_monitoring_mitigant> limit_monitoring_mitigant { get; set; }
        public virtual DbSet<limit_transaction_curve> limit_transaction_curve { get; set; }
        public virtual DbSet<link_type> link_type { get; set; }
        public virtual DbSet<log_deviation> log_deviation { get; set; }
        public virtual DbSet<marketing_action> marketing_action { get; set; }
        public virtual DbSet<marketing_campaign> marketing_campaign { get; set; }
        public virtual DbSet<mitigant> mitigant { get; set; }
        public virtual DbSet<mitigant_action> mitigant_action { get; set; }
        public virtual DbSet<mitigant_add_data> mitigant_add_data { get; set; }
        public virtual DbSet<mitigant_address> mitigant_address { get; set; }
        public virtual DbSet<mitigant_collateral> mitigant_collateral { get; set; }
        public virtual DbSet<mitigant_comment> mitigant_comment { get; set; }
        public virtual DbSet<mitigant_generic> mitigant_generic { get; set; }
        public virtual DbSet<mitigant_participant> mitigant_participant { get; set; }
        public virtual DbSet<mitigant_rating> mitigant_rating { get; set; }
        public virtual DbSet<mitigant_time_to_recovery> mitigant_time_to_recovery { get; set; }
        public virtual DbSet<mitigant_transaction> mitigant_transaction { get; set; }
        public virtual DbSet<mitigant_transaction_type> mitigant_transaction_type { get; set; }
        public virtual DbSet<mitigant_valuation> mitigant_valuation { get; set; }
        public virtual DbSet<new_credit_file_generic> new_credit_file_generic { get; set; }
        public virtual DbSet<outstanding> outstanding { get; set; }
        public virtual DbSet<participant_type> participant_type { get; set; }
        public virtual DbSet<payment> payment { get; set; }
        public virtual DbSet<payment_posting> payment_posting { get; set; }
        public virtual DbSet<pricing_condition> pricing_condition { get; set; }
        public virtual DbSet<pricing_condition_fees> pricing_condition_fees { get; set; }
        public virtual DbSet<profile> profile { get; set; }
        public virtual DbSet<profile_access_right> profile_access_right { get; set; }
        public virtual DbSet<profile_access_right_mc> profile_access_right_mc { get; set; }
        public virtual DbSet<profile_mc> profile_mc { get; set; }
        public virtual DbSet<profile_workflow_right> profile_workflow_right { get; set; }
        public virtual DbSet<qualitative_answer> qualitative_answer { get; set; }
        public virtual DbSet<qualitative_element> qualitative_element { get; set; }
        public virtual DbSet<qualitative_element_answer> qualitative_element_answer { get; set; }
        public virtual DbSet<qualitative_node> qualitative_node { get; set; }
        public virtual DbSet<qualitative_structure> qualitative_structure { get; set; }
        public virtual DbSet<qualitative_template> qualitative_template { get; set; }
        public virtual DbSet<qualitative_template_ceiling_link_type> qualitative_template_ceiling_link_type { get; set; }
        public virtual DbSet<rating> rating { get; set; }
        public virtual DbSet<rating_agency> rating_agency { get; set; }
        public virtual DbSet<rating_qualitative_template> rating_qualitative_template { get; set; }
        public virtual DbSet<rating_type> rating_type { get; set; }
        public virtual DbSet<recovery_action_fate> recovery_action_fate { get; set; }
        public virtual DbSet<recovery_arrangement_action> recovery_arrangement_action { get; set; }
        public virtual DbSet<recovery_credit_event> recovery_credit_event { get; set; }
        public virtual DbSet<recovery_type> recovery_type { get; set; }
        public virtual DbSet<recovery_type_category> recovery_type_category { get; set; }
        public virtual DbSet<recovery_type_fate> recovery_type_fate { get; set; }
        public virtual DbSet<recovery_type_parameter_counterparty> recovery_type_parameter_counterparty { get; set; }
        public virtual DbSet<recovery_type_parameters> recovery_type_parameters { get; set; }
        public virtual DbSet<scoring_session> scoring_session { get; set; }
        public virtual DbSet<scoring_template> scoring_template { get; set; }
        public virtual DbSet<scoring_template_warning> scoring_template_warning { get; set; }
        public virtual DbSet<screen> screen { get; set; }
        public virtual DbSet<screen_mc> screen_mc { get; set; }
        public virtual DbSet<security> security { get; set; }
        public virtual DbSet<security_quote> security_quote { get; set; }
        public virtual DbSet<sms_out> sms_out { get; set; }
        public virtual DbSet<software_user> software_user { get; set; }
        public virtual DbSet<software_user_mc> software_user_mc { get; set; }
        public virtual DbSet<software_user_target> software_user_target { get; set; }
        public virtual DbSet<specific_agreement> specific_agreement { get; set; }
        public virtual DbSet<static_data_table> static_data_table { get; set; }
        public virtual DbSet<status> status { get; set; }
        public virtual DbSet<stopwf_log> stopwf_log { get; set; }
        public virtual DbSet<strategy> strategy { get; set; }
        public virtual DbSet<strategy_criteria> strategy_criteria { get; set; }
        public virtual DbSet<strategy_exposure> strategy_exposure { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<transaction> transaction { get; set; }
        public virtual DbSet<transaction_action> transaction_action { get; set; }
        public virtual DbSet<transaction_add_data> transaction_add_data { get; set; }
        public virtual DbSet<transaction_amount> transaction_amount { get; set; }
        public virtual DbSet<transaction_amount_fees> transaction_amount_fees { get; set; }
        public virtual DbSet<transaction_comment> transaction_comment { get; set; }
        public virtual DbSet<transaction_condition> transaction_condition { get; set; }
        public virtual DbSet<transaction_condition_fees> transaction_condition_fees { get; set; }
        public virtual DbSet<transaction_condition_tier> transaction_condition_tier { get; set; }
        public virtual DbSet<transaction_covenant> transaction_covenant { get; set; }
        public virtual DbSet<transaction_covenant_history> transaction_covenant_history { get; set; }
        public virtual DbSet<transaction_cpty> transaction_cpty { get; set; }
        public virtual DbSet<transaction_credit_event> transaction_credit_event { get; set; }
        public virtual DbSet<transaction_credit_event_detail> transaction_credit_event_detail { get; set; }
        public virtual DbSet<transaction_excess> transaction_excess { get; set; }
        public virtual DbSet<transaction_generic> transaction_generic { get; set; }
        public virtual DbSet<transaction_hierarchy> transaction_hierarchy { get; set; }
        public virtual DbSet<transaction_limit_monitoring> transaction_limit_monitoring { get; set; }
        public virtual DbSet<transaction_overtaken> transaction_overtaken { get; set; }
        public virtual DbSet<transaction_rating> transaction_rating { get; set; }
        public virtual DbSet<transaction_rating_el> transaction_rating_el { get; set; }
        public virtual DbSet<transaction_reallocation> transaction_reallocation { get; set; }
        public virtual DbSet<transaction_recovery> transaction_recovery { get; set; }
        public virtual DbSet<transaction_recovery_mitigant> transaction_recovery_mitigant { get; set; }
        public virtual DbSet<transaction_related_utilizations> transaction_related_utilizations { get; set; }
        public virtual DbSet<transaction_type> transaction_type { get; set; }
        public virtual DbSet<transaction_type_agreement> transaction_type_agreement { get; set; }
        public virtual DbSet<transaction_type_document> transaction_type_document { get; set; }
        public virtual DbSet<transaction_type_eligibility_condition> transaction_type_eligibility_condition { get; set; }
        public virtual DbSet<transaction_type_fees> transaction_type_fees { get; set; }
        public virtual DbSet<transaction_type_hierarchy> transaction_type_hierarchy { get; set; }
        public virtual DbSet<transaction_type_reporting> transaction_type_reporting { get; set; }
        public virtual DbSet<transaction_type_workflow> transaction_type_workflow { get; set; }
        public virtual DbSet<transaction_user> transaction_user { get; set; }
        public virtual DbSet<transition_matrix> transition_matrix { get; set; }
        public virtual DbSet<user_activity> user_activity { get; set; }
        public virtual DbSet<user_group> user_group { get; set; }
        public virtual DbSet<user_group_mc> user_group_mc { get; set; }
        public virtual DbSet<user_profile> user_profile { get; set; }
        public virtual DbSet<user_profile_mc> user_profile_mc { get; set; }
        public virtual DbSet<warning_signal> warning_signal { get; set; }
        public virtual DbSet<wf_sql_log> wf_sql_log { get; set; }
        public virtual DbSet<wf_task_dispatch> wf_task_dispatch { get; set; }
        public virtual DbSet<working_hours_config> working_hours_config { get; set; }
        public virtual DbSet<Doc_Covenant> Doc_Covenant { get; set; }
        public virtual DbSet<@interface> @interface { get; set; }
        public virtual DbSet<interface_WS> interface_WS { get; set; }
        public virtual DbSet<load_account_type> load_account_type { get; set; }
        public virtual DbSet<load_branch_code> load_branch_code { get; set; }
        public virtual DbSet<load_counterparty_account> load_counterparty_account { get; set; }
        public virtual DbSet<load_counterparty_address> load_counterparty_address { get; set; }
        public virtual DbSet<load_currency_exchange_rate> load_currency_exchange_rate { get; set; }
        public virtual DbSet<load_legal_structure> load_legal_structure { get; set; }
        public virtual DbSet<load_product_code> load_product_code { get; set; }
        public virtual DbSet<account_type1> account_type1 { get; set; }
        public virtual DbSet<load_counterparty_contacts> load_counterparty_contacts { get; set; }
    }
}
