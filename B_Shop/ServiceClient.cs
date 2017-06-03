using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace BShop_Management
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

        internal async static Task<clsBranch> GetBranchDetailsAsync(string prBranchCode)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<clsBranch>
                    (await lcHttpClient.GetStringAsync
                        ("http://localhost:60064/api/bshop/GetBranchDetails?branchCode=" + prBranchCode));
        }

        //internal async static Task<clsArtist> GetArtistsAsync(string prArtistName)
        //{
        //    using (HttpClient lcHttpClient = new HttpClient())
        //        return JsonConvert.DeserializeObject<clsArtist>
        //            (await lcHttpClient.GetStringAsync
        //                ("http://localhost:60064/api/gallery/GetArtist?Name=" + prArtistName));
        //}
    }
}
