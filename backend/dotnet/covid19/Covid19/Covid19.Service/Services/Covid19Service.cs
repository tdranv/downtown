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
        private static readonly string baseAddress = "https://api.apify.com/v2/";
        private static readonly string unitedStatesCovidStatisticPath = "key-value-stores/moxA3Q0aZh5LosewB/records/LATEST?disableRedirect=true";


        private static async Task<CountryCovidStatisticsModel> GetUnitedStatesCovidStatisticsAsync(string unitedStatesCovidStatisticPath)
        {
            using HttpClient client = new HttpClient();
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
        }

        public static async Task<ICollection<RegionCovidStatisticsModel>> GetUnitedStateRegionsCovidStatisticsAsync()
        {
            var countryCovidStatistics = await GetUnitedStatesCovidStatisticsAsync(unitedStatesCovidStatisticPath);

            ICollection<RegionCovidStatisticsModel> regionCovidStatistics = countryCovidStatistics.CasesByState;

            return regionCovidStatistics;
        }
    }
}