///Title:   BShopController.cs
///Author:  Brandon Paul
///Date:    14.6.17
///Purpose: Controller class that handles server requests to access database
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;

namespace BShop_SelfHost
{
    public class BShopController : ApiController
    {
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
                    Inventory = getInventory(branchCode)
                };
            else
                return null;
        }

        private List<clsInventory> getInventory(string branchCode)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("branchCode", branchCode);
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT * FROM tblInventory WHERE branchCode = @branchCode", par);
            List<clsInventory> lcInventory = new List<clsInventory>();
            foreach (DataRow dr in lcResult.Rows)
                lcInventory.Add(dataRow2Inventory(dr));
            return lcInventory;
        }

        public string GetInventoryDescription(string description)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("description", description);
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT itemID FROM tblInventory WHERE description = @description", par);
            if (lcResult.Rows.Count > 0)
                return "Item exists with that description";
            else
                return null;
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
                furnitureWeight = prDataRow["furnitureWeight"] is DBNull ? (float?)null : Convert.ToSingle(prDataRow["furnitureWeight"]),
                furnitureNumParts = prDataRow["furnitureNumParts"] is DBNull ? (int?)null : Convert.ToInt32(prDataRow["furnitureNumParts"]),
                rowVersion = Convert.ToDateTime(prDataRow["rowVersion"]),
            };
        }

        public string PostInventory(clsInventory prInventory)
        { // insert inventory
            try
            {
                int lcRecCount = clsDbConnection.Execute("INSERT INTO tblInventory " +
                "(description, pricePerItem, quantity, category, branchCode, clothingSize, clothingGender, furnitureWeight, furnitureNumParts) " +
                "VALUES (@description, @pricePerItem, @quantity, @category, @branchCode, @clothingSize, @clothingGender, @furnitureWeight, @furnitureNumParts)",
                prepareInventoryParameters(prInventory));
                if (lcRecCount == 1)
                    return "One inventory item inserted";
                else
                    return "Unexpected inventory insert count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        public string PutInventory(clsInventory prInventory)
        {  // update inventory
            try
            {
                int lcRecCount = clsDbConnection.Execute("UPDATE tblInventory SET " +
                    "description = @description, pricePerItem = @pricePerItem, lastModified = @lastModified, quantity = @quantity, category = @category, branchCode = @branchCode, " +
                    "clothingSize = @clothingSize, clothingGender = @clothingGender, furnitureWeight = @furnitureWeight, furnitureNumParts = @furnitureNumParts " + 
                    "WHERE itemID = @itemID",
                    prepareInventoryParameters(prInventory));
                if (lcRecCount == 1)
                    return "One inventory item updated";
                else
                    return "Unexpected inventory update count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        private Dictionary<string, object> prepareInventoryParameters(clsInventory prInventory)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(11);
            par.Add("itemID", prInventory.itemID);
            par.Add("description", prInventory.description);
            par.Add("pricePerItem", prInventory.pricePerItem);
            par.Add("lastModified", prInventory.lastModified);
            par.Add("quantity", prInventory.quantity);
            par.Add("category", prInventory.category);
            par.Add("branchCode", prInventory.branchCode);
            par.Add("clothingSize", prInventory.clothingSize);
            par.Add("clothingGender", prInventory.clothingGender);
            par.Add("furnitureWeight", prInventory.furnitureWeight);
            par.Add("furnitureNumParts", prInventory.furnitureNumParts);
            return par;
        }

        public string DeleteInventory(int itemID)
        {  // delete inventory
            try
            {
                Dictionary<string, object> par = new Dictionary<string, object>(1);
                par.Add("itemID", itemID);
                int lcRecCount = clsDbConnection.Execute("DELETE FROM tblInventory WHERE itemID = @itemID", par);
                if (lcRecCount == 1)
                    return "One inventory item has been deleted";
                else
                    return "Unexpected inventory delete count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        public List<clsOrder> GetOrderList()
        {
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT tblInventory.description, tblOrder.* FROM tblInventory JOIN tblOrder " +
                "ON tblInventory.itemID = tblOrder.itemID", null);
            List<clsOrder> lcOrder = new List<clsOrder>();
            foreach (DataRow dr in lcResult.Rows)
                lcOrder.Add(dataRow2Order(dr));
            return lcOrder;
        }

        public clsOrder GetOrder(int orderID)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("orderID", orderID);
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT tblInventory.description, tblOrder.* FROM tblInventory JOIN tblOrder " +
                "ON tblInventory.itemID = tblOrder.itemID WHERE tblOrder.orderID = @orderID", par);
            if (lcResult.Rows.Count > 0)
                return dataRow2Order(lcResult.Rows[0]);
            else
                return null;
        }

        private clsOrder dataRow2Order(DataRow prDataRow)
        {
            return new clsOrder()
            {
                orderID = Convert.ToInt32(prDataRow["orderID"]),
                itemID = Convert.ToInt32(prDataRow["itemID"]),
                description = Convert.ToString(prDataRow["description"]),
                priceAtOrder = Convert.ToDecimal(prDataRow["priceAtOrder"]),
                orderQuantity = Convert.ToInt32(prDataRow["orderQuantity"]),
                orderDateTime = Convert.ToDateTime(prDataRow["orderDateTime"]),
                customerName = Convert.ToString(prDataRow["customerName"]),
                customerEmail = Convert.ToString(prDataRow["customerEmail"]),
            };
        }

        public string PostOrder(clsOrder prOrder)
        { // insert inventory
            try
            {
                int lcRecCount = clsDbConnection.Execute("INSERT INTO tblOrder " +
                "(itemID, priceAtOrder, orderQuantity, orderDateTime, customerName, customerEmail) " +
                "VALUES (@itemID, @priceAtOrder, @orderQuantity, @orderDateTime, @customerName, @customerEmail)",
                prepareOrderParameters(prOrder));
                if (lcRecCount == 1)
                    return "Order confirmed";
                else
                    return "Unexpected order insert count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        public string PutOrder(clsOrder prOrder)
        {  // update order - unfinished
            try
            {
                int lcRecCount = clsDbConnection.Execute("UPDATE tblOrder SET " +
                    " " +
                    " " +
                    "WHERE orderID = @orderID",
                    prepareOrderParameters(prOrder));
                if (lcRecCount == 1)
                    return "One order updated";
                else
                    return "Unexpected order update count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        private Dictionary<string, object> prepareOrderParameters(clsOrder prOrder)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(11);
            par.Add("orderID", prOrder.orderID);
            par.Add("itemID", prOrder.itemID);
            par.Add("priceAtOrder", prOrder.priceAtOrder);
            par.Add("orderQuantity", prOrder.orderQuantity);
            par.Add("orderDateTime", prOrder.orderDateTime);
            par.Add("customerName", prOrder.customerName);
            par.Add("customerEmail", prOrder.customerEmail);
            return par;
        }

        public string DeleteOrder(int orderID)
        {  // delete order
            try
            {
                Dictionary<string, object> par = new Dictionary<string, object>(1);
                par.Add("orderID", orderID);
                int lcRecCount = clsDbConnection.Execute("DELETE FROM tblOrder WHERE orderID = @orderID", par);
                if (lcRecCount == 1)
                    return "One order has been deleted";
                else
                    return "Unexpected order delete count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }
    }
}
