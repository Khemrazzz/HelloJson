using Newtonsoft.Json.Linq;
using HelloJson.Model;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloJson
{
    public class Exercise5
    {
        string jsonWithWrongType = @"{
            ""countries"": [
                {
                    ""country"": ""Seychelles"",
                    ""size_km2"": 459,
                    ""population"": ""Ninety Thousand"",
                    ""male_residents"": 50400,
                    ""female_residents"": 48600
                }
            ]
        }";

        public void ReadStringToJson()
        {
            try
            {
                JObject parsedJson = JObject.Parse(jsonWithWrongType);

                foreach (var country in parsedJson["countries"])
                {
                    // Check if "population" is an integer
                    if (country["population"] != null && country["population"].Type != JTokenType.Integer)
                    {
                        Console.WriteLine($"Critical Error: 'Population' should be an integer, but found {country["population"].Type}");
                        throw new InvalidCastException($"Critical Error: 'Population' should be an integer, but found {country["population"].Type}");
                    }

                    // You can now safely deserialize the JSON into strongly typed objects
                    var countryData = country.ToObject<Country>();
                    Console.WriteLine($"Country: {countryData.CountryName}, Population: {countryData.Population}");
                }
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error parsing JSON: {ex.Message}");
            }
        }
    }
}

