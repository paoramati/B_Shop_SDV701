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
                        ("http://localhost:60064/api/bshop/GetBranch=branchCode" + prBranchCode));
        }
    }
}
