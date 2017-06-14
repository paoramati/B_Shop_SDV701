///Title:   clsBShopUtility.cs
///Author:  Brandon Paul
///Date:    14.6.17
///Purpose: Utility class for validating data inputs
namespace BShop_Management
{
    public static class clsBShopUtility
    {
        public static bool CheckDecimalValue(string prValue)
        {
            decimal lcResult;
            if (string.IsNullOrEmpty(prValue))
                return false;
            if (!decimal.TryParse(prValue, out lcResult))
                return false;
            else
            {
                if (lcResult <= 0)
                    return false;
            }
            return true;
        }

        public static bool CheckIntValue(string prValue)
        {
            int lcResult;
            if (string.IsNullOrEmpty(prValue))
                return false;
            if (!int.TryParse(prValue, out lcResult))
                return false;
            else
            {
                if (lcResult < 0)
                    return false;
            }  
            return true;
        }

        public static bool CheckIntValue(string prValue, int prMinValue)
        {
            int lcResult;
            if (string.IsNullOrEmpty(prValue))
                return false;
            if (!int.TryParse(prValue, out lcResult))
                return false;
            else
            {
                if (lcResult <= prMinValue)
                    return false;
            }
            return true;
        }

        public static bool CheckFloatValue(string prValue)
        {
            float lcResult;
            if (string.IsNullOrEmpty(prValue))
                return false;
            if (!float.TryParse(prValue, out lcResult))
                return false;
            else
            {
                if (lcResult <= 0)
                    return false;
            }
            return true;
        }

        public static bool CheckDateTimeValue(string prValue)
        {
            decimal lcResult;
            if (string.IsNullOrEmpty(prValue))
                return false;
            if (!decimal.TryParse(prValue, out lcResult))
                return false;
            else
            {
                if (lcResult <= 0)
                    return false;
            }
            return true;
        }

    }
}
