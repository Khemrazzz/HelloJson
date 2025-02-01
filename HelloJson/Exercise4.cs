using HelloJson.Model;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Text.Json;
using SystemTextJson = System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;

namespace HelloJson
{

    public class Exercise4
    {

        public bool IsValidJson(string json)
        {
            try
            {
                //Attempt to parse JSON; if successful, it's valid
                JsonConvert.DeserializeObject(json);
                return true;
            }
            catch (JsonReaderException)
            {
                //Json is invalid if parsing fails
                return false;
            }
        }


        string filePath = "C:\\IndianOceanIslands.json";

        public void LaunchExercise4()
        {
            var allCountries = GetReadJsonFileFromFilePath();
            DisplayCountryJson(allCountries);

            string recordToAdd = @"
            {
             ""CountryName"": ""Rodrigues"",
             ""Size_km2"": 108,
             ""Population"": 43650,
             ""MaleResidents"": 21330,
             ""FemaleResidents"": 22320
            }";

            allCountries = AddRecordToJson(recordToAdd, allCountries);
            Console.WriteLine(" ******** Final outcome ********* ");
            DisplayCountryJson(allCountries);

        }

        private CountryData GetReadJsonFileFromFilePath()
        {
            var allCountries = new CountryData();
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found!");
                return allCountries;
            }

            try
            {
                string jsonContent = File.ReadAllText(filePath);

                // Deserialize JSON to C# object using Deserializer from System.Text.JSOn
                allCountries = SystemTextJson.JsonSerializer.Deserialize<CountryData>(jsonContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return allCountries;
        }

        public void DisplayCountryJson(CountryData allCountries)
        {
            // Display the countries' data
            if (allCountries != null)
            {
                foreach (var country in allCountries.Countries)
                {
                    Console.WriteLine($"Country: {country.CountryName}");
                    Console.WriteLine($"Size (km²): {country.Size_km2}");
                    Console.WriteLine($"Population: {country.Population}");
                    Console.WriteLine($"Male Residents: {country.MaleResidents}");
                    Console.WriteLine($"Female Residents: {country.FemaleResidents}");
                }
            }
            else
            {
                Console.WriteLine("No data found in JSON.");
            }
        }

        public CountryData? AddRecordToJson(string recordToAdd, CountryData allCountries)
        {
            Country country = JsonConvert.DeserializeObject<Country>(recordToAdd);
            allCountries.Countries.Add(country); 
            return allCountries;
        }

    }
}
