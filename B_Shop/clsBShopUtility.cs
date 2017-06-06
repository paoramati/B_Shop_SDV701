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
            if (string.IsNullOrEmpty(value))
                return false;
            decimal lcResult;
            if (!decimal.TryParse(value, out lcResult))
                return false;
            else
                if (lcResult < 0)
                return false;
            return true;
        }

        public static bool CheckIntValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;
            int lcResult;
            if (!int.TryParse(value, out lcResult))
                return false;
            else
                if (lcResult < 0)
                return false;
            return true;
        }

        public static bool CheckFloatValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;
            float lcResult;
            if (!float.TryParse(value, out lcResult))
                return false;
            else
                if (lcResult < 0)
                return false;
            return true;
        }

        

        public static bool CheckDateTimeValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;
            decimal lcResult;
            if (!decimal.TryParse(value, out lcResult))
                return false;
            else
                if (lcResult < 0)
                return false;
            return true;
        }

    }
}
