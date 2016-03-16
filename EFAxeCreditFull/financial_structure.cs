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
    
    public partial class financial_structure
    {
        public financial_structure()
        {
            this.counterparty_financial_structure = new HashSet<counterparty_financial_structure>();
            this.covenant = new HashSet<covenant>();
            this.financial_forecasting = new HashSet<financial_forecasting>();
            this.financial_structure_benchmark = new HashSet<financial_structure_benchmark>();
            this.financial_structure_forecast_scenario = new HashSet<financial_structure_forecast_scenario>();
            this.financial_structure_stress_scenario = new HashSet<financial_structure_stress_scenario>();
        }
    
        public int financial_structure_id { get; set; }
        public Nullable<int> financial_template_id { get; set; }
        public Nullable<int> financial_template_version { get; set; }
        public Nullable<int> financial_node_id { get; set; }
        public Nullable<int> financial_element_id { get; set; }
        public Nullable<int> financial_parent_node_id { get; set; }
        public Nullable<decimal> weight { get; set; }
        public string validation_rule_formula { get; set; }
        public string calculation_formula { get; set; }
        public Nullable<int> iuser { get; set; }
        public Nullable<System.DateTime> idate { get; set; }
        public Nullable<int> uuser { get; set; }
        public Nullable<System.DateTime> udate { get; set; }
        public Nullable<int> duser { get; set; }
        public Nullable<System.DateTime> ddate { get; set; }
    
        public virtual ICollection<counterparty_financial_structure> counterparty_financial_structure { get; set; }
        public virtual ICollection<covenant> covenant { get; set; }
        public virtual financial_element financial_element { get; set; }
        public virtual ICollection<financial_forecasting> financial_forecasting { get; set; }
        public virtual financial_node financial_node { get; set; }
        public virtual financial_node financial_node1 { get; set; }
        public virtual ICollection<financial_structure_benchmark> financial_structure_benchmark { get; set; }
        public virtual financial_template financial_template { get; set; }
        public virtual ICollection<financial_structure_forecast_scenario> financial_structure_forecast_scenario { get; set; }
        public virtual ICollection<financial_structure_stress_scenario> financial_structure_stress_scenario { get; set; }
    }
}
