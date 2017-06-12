using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BShop_Management
{
    public static class clsBShopUtility
    {
        public static bool CheckDecimalValue(string value)
        {
            decimal lcResult;
            if (string.IsNullOrEmpty(value))
                return false;
            if (!decimal.TryParse(value, out lcResult))
            {
                return false;
            }
                
            else
            {
                if (lcResult < 0)
                    return false;
            }
            return true;
        }

        public static bool CheckIntValue(string value)
        {
            int lcResult;
            if (string.IsNullOrEmpty(value))
                return false;
            //bool result = int.TryParse(value, out lcResult);
            if (!int.TryParse(value, out lcResult))
                return false;
            else
            {
                if (lcResult < 0)
                    return false;
            }  
            return true;
        }

        public static bool CheckFloatValue(string value)
        {
            float lcResult;
            if (string.IsNullOrEmpty(value))
                return false;
            if (!float.TryParse(value, out lcResult))
                return false;
            else
            {
                if (lcResult < 0)
                    return false;
            }
            return true;
        }



        public static bool CheckDateTimeValue(string value)
        {
            decimal lcResult;
            if (string.IsNullOrEmpty(value))
                return false;
            if (!decimal.TryParse(value, out lcResult))
                return false;
            else
            {
                if (lcResult < 0)
                    return false;
            }
            return true;
        }

    }
}
