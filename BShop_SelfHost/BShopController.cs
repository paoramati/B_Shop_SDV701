using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace BShop_SelfHost
{
    public class BShopController : ApiController
    {
        ////get inventory descriptions
        //public List<string> GetInventoryDescriptions()
        //{
        //    DataTable lcResult = clsDbConnection.GetDataTable("SELECT description FROM tblInventory", null);
        //    List<string> lcNames = new List<string>();
        //    foreach (DataRow dr in lcResult.Rows)
        //        lcNames.Add((string)dr[0]);
        //    return lcNames;
        //}

        public List<string> GetBranchCodes()
        { 
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT branchCode FROM tblBranch", null);
            List<string> lcBranchCodes = new List<string>();
            foreach (DataRow dr in lcResult.Rows)
                lcBranchCodes.Add((string)dr[0]);
            return lcBranchCodes;
        }

        

        public clsBranch GetBranch(string branchCode)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("branchCode", branchCode);
            DataTable lcResult =
            clsDbConnection.GetDataTable("SELECT * FROM tblBranch WHERE branchCode = @branchCode", par);
            if (lcResult.Rows.Count > 0)
                return new clsBranch()
                {
                    branchCode = (string)lcResult.Rows[0]["branchCode"],
                    branchAddress = (string)lcResult.Rows[0]["branchAddress"],
                    branchPhone = (string)lcResult.Rows[0]["branchPhone"],
                    //Inventory = getInventory(prBranchCode)
                };
            else
                return null;
        }

        public clsBranch GetBranchDetails(string branchCode)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            //branchCode.ToUpper();
            par.Add("branchCode", branchCode.ToUpper());
            DataTable lcResult =
            clsDbConnection.GetDataTable("SELECT * FROM tblBranch WHERE branchCode = @branchCode", par);
            if (lcResult.Rows.Count > 0)
                return new clsBranch()
                {
                    branchCode = (string)lcResult.Rows[0]["branchCode"],
                    branchAddress = (string)lcResult.Rows[0]["branchAddress"],
                    branchPhone = (string)lcResult.Rows[0]["branchPhone"],
                    //Inventory = getInventory(lcBranchCode)
                };
            else
                return null;
        }



        private List<clsInventory> getInventory(string prBranchCode)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("branchCode", prBranchCode);
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT * FROM tblInventory WHERE branchCode = @branchCode", par);
            List<clsInventory> lcInventory = new List<clsInventory>();
            foreach (DataRow dr in lcResult.Rows)
                lcInventory.Add(dataRow2Inventory(dr));
            return lcInventory;
        }

        private clsInventory dataRow2Inventory(DataRow prDataRow)
        {
            return new clsInventory()
            {
                itemID = Convert.ToInt32(prDataRow["itemID"]),
                description = Convert.ToString(prDataRow["description"]),
                pricePerItem = Convert.ToDecimal(prDataRow["pricePerItem"]),
                lastModified = Convert.ToDateTime(prDataRow["lastModified"]),
                quantity = Convert.ToInt32(prDataRow["quantity"]),
                category = Convert.ToString(prDataRow["category"]),
                branchCode = Convert.ToString(prDataRow["branchCode"]),
                clothingSize = prDataRow["clothingSize"] is DBNull ? (int?)null : Convert.ToInt32(prDataRow["clothingSize"]),
                clothingGender = Convert.ToString(prDataRow["clothingGender"]),
                furnitureWeight = prDataRow["Weight"] is DBNull ? (float?)null : Convert.ToSingle(prDataRow["furnitureWeight"]),
                furnitureNumParts = prDataRow["furnitureNumParts"] is DBNull ? (int?)null : Convert.ToInt32(prDataRow["furnitureNumParts"]),
            };
        }
    }
}
