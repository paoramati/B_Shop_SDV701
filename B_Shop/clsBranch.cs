using B_Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Shop_Windows
{
    class clsBranch
    {
        private int _BranchID;
        private string _BranchName;
        private string _BranchAddress;
        private string _BranchPhone;

        public int BranchID
        {
            get
            {
                return _BranchID;
            }

            set
            {
                _BranchID = value;
            }
        }

        public string BranchName
        {
            get
            {
                return _BranchName;
            }

            set
            {
                _BranchName = value;
            }
        }

        public string BranchAddress
        {
            get
            {
                return _BranchAddress;
            }

            set
            {
                _BranchAddress = value;
            }
        }

        public string BranchPhone
        {
            get
            {
                return _BranchPhone;
            }

            set
            {
                _BranchPhone = value;
            }
        }

        //constructor
        public clsBranch()
        {
            
        }

    }
}
