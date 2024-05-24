using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject_C_seleniumframework.Utilities
{
    public class Jsonreader
    {
        public Jsonreader() 
        { 
        }

        public string extractData(String tokenName)
        {
            String MyJsonString = File.ReadAllText("C:/Users/lijom/source/repos/TestProject_C_seleniumframework/Utilities/testData.json");
            var JsonObject = JToken.Parse(MyJsonString);
            return JsonObject.SelectToken(tokenName).Value<string>();
        }
        public string[] extractDataarray(String tokenName)
        {
            String MyJsonString = File.ReadAllText("C:/Users/lijom/source/repos/TestProject_C_seleniumframework/Utilities/testData.json");
            var JsonObject = JToken.Parse(MyJsonString);
            List<String> productlist = JsonObject.SelectTokens(tokenName).Values<string>().ToList();
            return productlist.ToArray();

        }
    }


}
