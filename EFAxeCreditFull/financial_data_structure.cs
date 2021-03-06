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
    
    public partial class financial_data_structure
    {
        public int data_category_id { get; set; }
        public int data_type_id { get; set; }
        public int data_element_id { get; set; }
        public Nullable<decimal> max_score { get; set; }
        public Nullable<decimal> weight { get; set; }
        public string formule { get; set; }
        public Nullable<int> sort { get; set; }
        public int sequence_id { get; set; }
        public Nullable<int> iuser { get; set; }
        public Nullable<System.DateTime> idate { get; set; }
        public Nullable<int> uuser { get; set; }
        public Nullable<System.DateTime> udate { get; set; }
        public Nullable<int> duser { get; set; }
        public Nullable<System.DateTime> ddate { get; set; }
    
        public virtual financial_data_category financial_data_category { get; set; }
        public virtual financial_data_element financial_data_element { get; set; }
        public virtual financial_data_type financial_data_type { get; set; }
    }
}
