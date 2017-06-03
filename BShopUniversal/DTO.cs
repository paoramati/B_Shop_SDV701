using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BShopUniversal
{
    public class clsBranch
    {
        public string branchCode { get; set; }
        public string branchAddress { get; set; }
        public string branchPhone { get; set; }
        public List<clsInventory> Inventory { get; set; }
    }

    public class clsInventory
    {
        public int itemID { get; set; }
        public string description { get; set; }
        public float pricePerItem { get; set; }
        public DateTime lastModified { get; set; }
        public int quantity { get; set; }
        public string category { get; set; }
        public string branchCode { get; set; }
        public int? clothingSize { get; set; }
        public char? clothingGender { get; set; }
        public float? furnitureWeight { get; set; }
        public int? furnitureNumParts { get; set; }
        public DateTime rowVersion { get; set; }
    }

    public class clsOrder
    {
        public int orderID { get; set; }
        public int itemID { get; set; }
        public float priceAtOrder { get; set; }
        public DateTime orderDateTime { get; set; }
        public string customerName { get; set; }
        public string customerEmail { get; set; }
    }
}
