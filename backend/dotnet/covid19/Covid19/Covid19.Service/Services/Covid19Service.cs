using Covid19.Services.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Covid19.Services.Services
{
    public class Covid19Service
    {
        private readonly string baseAddress = "https://api.apify.com/v2/";
        private readonly string unitedStatesCovidStatisticPath = "key-value-stores/moxA3Q0aZh5LosewB/records/LATEST?disableRedirect=true";

        static HttpClient client = new HttpClient();

        private async Task<CountryCovidStatisticsModel> GetUnitedStatesCovidStatisticsAsync(string unitedStatesCovidStatisticPath)
        {
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            CountryCovidStatisticsModel countryCovidStatistics = null;
            HttpResponseMessage response = await client.GetAsync(unitedStatesCovidStatisticPath);
            if (response.IsSuccessStatusCode)
            {
                countryCovidStatistics = await response.Content.ReadAsAsync<CountryCovidStatisticsModel>();
            }
            return countryCovidStatistics;
        }

        public static async Task<ICollection<RegionCovidStatisticsModel>> GetUnitedStateRegionsCovidStatisticsAsync()
        {
            var countryCovidStatistics = await GetUnitedStatesCovidStatisticsAsync(unitedStatesCovidStatisticPath);

            ICollection<RegionCovidStatisticsModel> regionCovidStatistics = countryCovidStatistics.CasesByState;

            return regionCovidStatistics;
        }
    }
}