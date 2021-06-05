using System;
using System.Collections.Generic;

namespace Covid19.Services.Models
{
    public class CountryCovidStatisticsModel
    {
        public int TotalCases { get; set; }

        public int TotalDeaths { get; set; }

        public string SourceUrl { get; set; }

        public ICollection<RegionCovidStatisticsModel> CasesByState { get; set; }

        public DateTime LastUpdatedAtSource { get; set; }

        public DateTime LastUpdatedAtApify { get; set; }

        public string ReadMe { get; set; }

    }
}
