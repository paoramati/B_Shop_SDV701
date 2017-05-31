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
        //get inventory descriptions
        public List<string> GetInventoryDescriptions()
        {
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT Description FROM tblInventory", null);
            List<string> lcNames = new List<string>();
            foreach (DataRow dr in lcResult.Rows)
                lcNames.Add((string)dr[0]);
            return lcNames;
        }

        public List<string> GetBranchNames()
        { 
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT branchName FROM tblBranch", null);
            List<string> lcBranchNames = new List<string>();
            foreach (DataRow dr in lcResult.Rows)
                lcBranchNames.Add((string)dr[0]);
            return lcBranchNames;
        }
    }
}
