//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SalesProject_Ec
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public int ID { get; set; }
        public System.DateTime DateInserted { get; set; }
        public int MARKETID { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> ExpirationDate { get; set; }
        public string ImageURL { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> Weight { get; set; }
        public Nullable<decimal> TaxPrice { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<int> ProductCategoryID { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<int> MinimumOrderDty { get; set; }
    }
}
