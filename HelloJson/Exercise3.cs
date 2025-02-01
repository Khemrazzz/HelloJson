using HelloJson.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HelloJson
{
    public class Exercise3
    {

        string filepath = "C:\\IndianOceanIslands.json";
        public void ReadJsonFile()
        {
            if (!File.Exists(filepath))
            {
                Console.WriteLine("File not found!");
                return;
            }
            try
            {
                string jsonContent = File.ReadAllText(filepath);

                // Deserialize JSON to C# object
                var allCountries = JsonSerializer.Deserialize<CountryData>(jsonContent);

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
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

        }
    }
}