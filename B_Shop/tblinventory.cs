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
    
    public partial class tblinventory
    {
        public tblinventory()
        {
            this.tblorders = new HashSet<tblorder>();
        }
    
        public int itemID { get; set; }
        public string description { get; set; }
        public decimal pricePerItem { get; set; }
        public System.DateTime lastModified { get; set; }
        public int quantity { get; set; }
        public string category { get; set; }
        public int branchID { get; set; }
        public Nullable<int> clothingSize { get; set; }
        public string clothingGender { get; set; }
        public Nullable<decimal> furnitureWeight { get; set; }
        public Nullable<int> furnitureNumParts { get; set; }
        public System.DateTime rowVersion { get; set; }
    
        public virtual tblbranch tblbranch { get; set; }
        public virtual ICollection<tblorder> tblorders { get; set; }
    }
}