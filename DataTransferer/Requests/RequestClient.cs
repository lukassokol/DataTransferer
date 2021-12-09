using System.Net.Http;
using static DataTransferer.Model.NisDBContext;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace DataTransferer.Requests
{
    public static class RequestClient<T> where T : new()
    {
        private static HttpClient client = new HttpClient();

        public static List<T> GetByType(string uri)
        {
            var ret = new List<T>();
            var response = client.GetStringAsync(uri);

            foreach (var item in (JArray)JsonConvert.DeserializeObject(response.Result))
                ret.Add(item.ToObject<T>());

            return ret;
        }
    }

    public static class GetRequests
    {
        private static HttpClient client = new HttpClient();

        public static List<Region> GetRegions()
            => RequestClient<Region>.GetByType("https://data.korona.gov.sk/api/regions");

        public static List<AgTestsByRegion> GetAgTestsByRegions()
        {
            var response =  client.GetStringAsync("https://data.korona.gov.sk/api/ag-tests/by-region");

            return JsonConvert.DeserializeObject<TmpAgTestsByRegionsResponse>(response.Result).Page;
        }

        public static List<HospitalbbedsByRegion> GetHospitalBedsByRegion()
        {
            var response = client.GetStringAsync("https://data.korona.gov.sk/api/hospital-beds/by-region");

            return JsonConvert.DeserializeObject<TmpHospitalBedsByRegion>(response.Result).Page;
        }

        public static List<HospitalPatientsByRegion> GetHospitalPatientsByRegion()
        {
            var response = client.GetStringAsync("https://data.korona.gov.sk/api/hospital-patients/by-region");

            return JsonConvert.DeserializeObject<TmpHospitalPatientsByRegion>(response.Result).Page;
        }
    }

    public class TmpAgTestsByRegionsResponse
    {
        public string Success { get; set; }
        public string NextOffset { get; set; }
        public List<AgTestsByRegion> Page { get; set; }
    }

    public class TmpHospitalBedsByRegion
    {
        public string Success { get; set; }
        public string NextOffset { get; set; }
        public List<HospitalbbedsByRegion> Page { get; set; }
    }

    public class TmpHospitalPatientsByRegion
    {
        public string Success { get; set; }
        public string NextOffset { get; set; }
        public List<HospitalPatientsByRegion> Page { get; set; }
    }
}
