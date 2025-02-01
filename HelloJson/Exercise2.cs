using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HelloJson
{
    public class Exercise2
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
                // parse the Json document
                using (JsonDocument doc = JsonDocument.Parse(jsonContent))
                {
                    // Navigate the JSON structure
                    JsonElement root = doc.RootElement;

                    // Check if root has a property named "countries" which is an array
                    if (root.TryGetProperty("countries", out JsonElement countriesElement) && countriesElement.ValueKind == JsonValueKind.Array)
                    {
                        // Iterate through each country in the array
                        foreach (JsonElement country in countriesElement.EnumerateArray())
                        {
                            // Access properties dynamically
                            string countryName = country.GetProperty("country").GetString();
                            int size = country.GetProperty("size_km2").GetInt32();
                            int population = country.GetProperty("population").GetInt32();
                            int maleResidents = country.GetProperty("male_residents").GetInt32();
                            int femaleResidents = country.GetProperty("female_residents").GetInt32();

                            // Display the data
                            Console.WriteLine($"Country: {countryName}");
                            Console.WriteLine($"Size (km²): {size}");
                            Console.WriteLine($"Population: {population}");
                            Console.WriteLine($"Male Residents: {maleResidents}");
                            Console.WriteLine($"Female Residents: {femaleResidents}");
                        }
                    }

                }
            }
            catch ( Exception ex )
            {
                Console.WriteLine("Not Found");
            }

        }
    }
}