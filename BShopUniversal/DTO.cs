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
        public decimal pricePerItem { get; set; }
        public DateTime lastModified { get; set; }
        public int quantity { get; set; }
        public string category { get; set; }
        public string branchCode { get; set; }
        public int? clothingSize { get; set; }
        public string clothingGender { get; set; }
        public float? furnitureWeight { get; set; }
        public int? furnitureNumParts { get; set; }
        public DateTime rowVersion { get; set; }

        public static readonly string FACTORY_PROMPT = "Select what type of item to add:";

        private static List<string> itemCategories = new List<string> { "Clothing", "Furniture" };

        public static List<string> ItemCategories
        {
            get { return itemCategories; }
            //set { itemCategories = value; }
        }

        public override string ToString()
        {
            return description + " (" + quantity + " available)";
        }

        public static clsInventory NewInventory(string prItemCategory)
        {
            return new clsInventory() { category = prItemCategory };
        }
    }

    public class clsOrder
    {
        public int orderID { get; set; }
        public int itemID { get; set; }
        public decimal priceAtOrder { get; set; }
        public int orderQuantity { get; set; }
        public DateTime orderDateTime { get; set; }
        public string customerName { get; set; }
        public string customerEmail { get; set; }

        public override string ToString()
        {
            return "Order No# " + orderID + "\t Date Added: " + orderDateTime.ToString("d") + "\t" + customerName;
        }
    }
}
