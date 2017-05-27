using B_Shop_Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Shop
{
    class clsBranchList : List<clsBranch>
    {
        public clsBranchList()
        {

        }

        public List<string> GetBranchNames()
        {
            List<string> lcBranchNames = new List<string>();
            using (bshopdbEntities bshop = new bshopdbEntities())
            {
                foreach(var branch in bshop.tblbranches)
                {
                    lcBranchNames.Add(branch.branchName);
                }
            }
            return lcBranchNames;
        }



    }
}
