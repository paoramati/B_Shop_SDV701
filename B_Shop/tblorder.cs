//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace B_Shop
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblorder
    {
        public int orderID { get; set; }
        public int itemID { get; set; }
        public decimal priceAtOrder { get; set; }
        public System.DateTime orderDateTime { get; set; }
        public string customerName { get; set; }
        public string customerEmail { get; set; }
    
        public virtual tblinventory tblinventory { get; set; }
    }
}
