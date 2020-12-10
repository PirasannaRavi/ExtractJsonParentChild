using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace ExtractJsonParentChild
{
    class Program
    {
        static void Main(string[] args)
        {
            var strJson = File.ReadAllText("sample.json");
            var json = JObject.Parse(strJson);
            var arr = json["TestSources"];

            var finalKeyValuePairs = new List<KeyValuePair<string, string>>();

            foreach (var x in arr)
            {
                if (x["Id"] != null)
                {
                    finalKeyValuePairs.Add(new KeyValuePair<string, string>("TestSources", x["Id"].ToString()));
                    GetKey(x, finalKeyValuePairs);
                }
            }
        }

        static void GetKey(JToken x, List<KeyValuePair<string, string>> finalKeyValuePairs)
        {
            if (x["TestGroups"] != null)
            {
                var arr1 = x["TestGroups"];
                foreach (var y in arr1)
                {
                    finalKeyValuePairs.Add(new KeyValuePair<string, string>(x["Id"].ToString(), y["Id"].ToString()));
                    GetKey(y, finalKeyValuePairs);
                }
            }
        }
    }
}
