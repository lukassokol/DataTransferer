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
            var response = client.GetStringAsync("https://data.korona.gov.sk/api/ag-tests/by-region");

            return JsonConvert.DeserializeObject<TMPAgTestsByRegionsResponse>(response.Result).page;
        }

        public static List<HospitalbbedsByRegion> GetHospitalBedsByRegion()
        {
            var response = client.GetStringAsync("https://data.korona.gov.sk/api/hospital-beds/by-region");

            return JsonConvert.DeserializeObject<TMPHospitalBedsByRegion>(response.Result).page;
        }

        public static List<HospitalPatientsByRegion> GetHospitalPatientsByRegion()
        {
            var response = client.GetStringAsync("https://data.korona.gov.sk/api/hospital-patients/by-region");

            return JsonConvert.DeserializeObject<TMPHospitalPatientsByRegion>(response.Result).page;
        }
    }

    public class TMPAgTestsByRegionsResponse
    {
        public string success { get; set; }
        public string next_offset { get; set; }
        public List<AgTestsByRegion> page { get; set; }
    }

    public class TMPHospitalBedsByRegion
    {
        public string success { get; set; }
        public string next_offset { get; set; }
        public List<HospitalbbedsByRegion> page { get; set; }
    }

    public class TMPHospitalPatientsByRegion
    {
        public string success { get; set; }
        public string next_offset { get; set; }
        public List<HospitalPatientsByRegion> page { get; set; }
    }
}
