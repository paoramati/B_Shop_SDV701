using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace BShopUniversal
{
    class ServiceClient
    {
        internal async static Task<List<string>> GetBranchCodesAsync()
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<string>>
                (await lcHttpClient.GetStringAsync("http://localhost:60064/api/bshop/GetBranchCodes/"));
        }

        internal async static Task<clsBranch> GetBranchAsync(string prBranchCode)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<clsBranch>
                    (await lcHttpClient.GetStringAsync
                        ("http://localhost:60064/api/bshop/GetBranch?branchCode=" + prBranchCode));
        }

        internal async static Task<List<clsOrder>> GetOrderListAsync()
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<clsOrder>>
                    (await lcHttpClient.GetStringAsync
                        ("http://localhost:60064/api/bshop/GetOrderList/"));
        }

        internal async static Task<clsOrder> GetOrderAsync(int prOrderID)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<clsOrder>
                    (await lcHttpClient.GetStringAsync
                        ("http://localhost:60064/api/bshop/GetOrder?orderID=" + prOrderID));
        }

        internal static async Task<string> InsertInventoryAsync(clsInventory prInventory)
        {
            return await InsertOrUpdateAsync(prInventory, "http://localhost:60064/api/bshop/PostInventory", "POST");
        }

        internal static async Task<string> UpdateInventoryAsync(clsInventory prInventory)
        {
            return await InsertOrUpdateAsync(prInventory, "http://localhost:60064/api/bshop/PutInventory", "PUT");
        }

        internal static async Task<string> InsertOrderAsync(clsOrder prOrder)
        {
            return await InsertOrUpdateAsync(prOrder, "http://localhost:60064/api/bshop/PostInventory", "POST");
        }

        internal static async Task<string> UpdateOrderAsync(clsOrder prOrder)
        {
            return await InsertOrUpdateAsync(prOrder, "http://localhost:60064/api/bshop/PutInventory", "PUT");
        }

        private async static Task<string> InsertOrUpdateAsync<TItem>(TItem prItem, string prUrl, string prRequest)
        {
            using (HttpRequestMessage lcReqMessage = new HttpRequestMessage(new HttpMethod(prRequest), prUrl))
            using (lcReqMessage.Content =
            new StringContent(JsonConvert.SerializeObject(prItem), Encoding.UTF8, "application/json"))
            using (HttpClient lcHttpClient = new HttpClient())
            {
                HttpResponseMessage lcRespMessage = await lcHttpClient.SendAsync(lcReqMessage);
                return await lcRespMessage.Content.ReadAsStringAsync();
            }
        }

        internal static async Task<string> DeleteInventoryAsync(int prItemID)
        {
            using (HttpClient lcHttpClient = new HttpClient())
            {
                HttpResponseMessage lcRespMessage = await lcHttpClient.DeleteAsync
                ($"http://localhost:60064/api/bshop/DeleteInventory?itemID=" + prItemID);    
                return await lcRespMessage.Content.ReadAsStringAsync();
            }
        }

        internal static async Task<string> DeleteOrderAsync(int prOrderID)
        {
            using (HttpClient lcHttpClient = new HttpClient())
            {
                HttpResponseMessage lcRespMessage = await lcHttpClient.DeleteAsync
                ($"http://localhost:60064/api/bshop/DeleteOrder?orderID=" + prOrderID);
                return await lcRespMessage.Content.ReadAsStringAsync();
            }
        }

    }
}
