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
        { }

        public void extractData()
        {
            String MyJsonString = File.ReadAllText("testData.json");
            var JsonObject = JToken.Parse(MyJsonString);
            Console.WriteLine(JsonObject.SelectToken("username").Value<string>());


        }
    }


}
