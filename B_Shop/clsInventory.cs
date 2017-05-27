using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Shop_Windows
{
    class clsInventory
    {
        private clsBranch _Branch = new clsBranch();

        private int _ItemID;
        private string _Description;
        private float _PricePerItem;
        private DateTime _LastModified;
        private int _Quantity;
        private string _Category;
        private int _BranchID;

        internal clsBranch Branch
        {
            get
            {
                return _Branch;
            }

            set
            {
                _Branch = value;
            }
        }

        //constructor
        public clsInventory()
        {


        }


    }
}
