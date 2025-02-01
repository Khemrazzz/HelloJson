using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HelloJson.Model
{
    public class Country
    {
        [JsonPropertyName("country")]
        public string CountryName { get; set; }

        [JsonPropertyName("size_km2")]
        public int Size_km2 { get; set; }

        [JsonPropertyName("population")]
        public int Population { get; set; }

        [JsonPropertyName("male_residents")]
        public int MaleResidents { get; set; }

        [JsonPropertyName("female_residents")]
        public int FemaleResidents { get; set; }
    }

    // Wrapper class for the countries list
    public class CountryData
    {
        [JsonPropertyName("countries")]
        public List<Country> Countries { get; set; }
    }
}