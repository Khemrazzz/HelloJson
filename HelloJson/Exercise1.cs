using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloJson
{
    public class Exercise1
    {
        string userProfileJson = @"
        {
             ""Name"": ""Alice"",
             ""Age"": 25,
             ""Email"": ""alice@example.com"",
                 ""Address"": {
                   ""Street"": ""123 Main St"",
                   ""City"": ""Port Louis"",
                   ""ZipCode"": ""742CU1""
               }
  }";
        public void DisplayJson()
        {
            //Reading JSON as a string
            Console.WriteLine(userProfileJson);
        }
    }
}
