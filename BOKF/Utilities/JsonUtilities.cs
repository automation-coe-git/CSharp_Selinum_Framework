using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenQA.Selenium;

namespace BOKF.Utilities
{
    class JsonUtilities
    {
            public List<T> getJsonDataWithListObject<T>(string jsonRootPath, string jsonString)
            {
                Newtonsoft.Json.Linq.JObject jsonParseObject = Newtonsoft.Json.Linq.JObject.Parse(jsonString);
                var jsonFiledata = jsonParseObject.SelectToken(jsonRootPath).ToString();
                return JsonConvert.DeserializeObject<List<T>>(jsonFiledata);

            }
            public T getJsonDataWithOutListObject<T>(string jsonRootPath, string jsonString)
            {
                Newtonsoft.Json.Linq.JObject jsonParseObject = Newtonsoft.Json.Linq.JObject.Parse(jsonString);
                var jsonFiledata = jsonParseObject.SelectToken(jsonRootPath).ToString();
                return JsonConvert.DeserializeObject<T>(jsonFiledata);

            }
            public void SerializeJasonData(string jsonString, string jsonFilePath, int LoanNumber)
            {
                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString);
                jsonObj.loanNumber = LoanNumber;
                string updatedJsonString = jsonObj.ToString();
                File.WriteAllText(jsonFilePath, updatedJsonString);
            }
        public class Result
        {
            public string GsearchResultClass { get; set; }
            public string unescapedUrl { get; set; }
            public string url { get; set; }
            public string visibleUrl { get; set; }
            public string cacheUrl { get; set; }
            public string title { get; set; }
            public string titleNoFormatting { get; set; }
            public string content { get; set; }
        }

        public class Page
        {
            public string start { get; set; }
            public int label { get; set; }
        }

        public class Cursor
        {
            public List<Page> pages { get; set; }
            public string estimatedResultCount { get; set; }
            public int currentPageIndex { get; set; }
            public string moreResultsUrl { get; set; }
        }

        public class ResponseData
        {
            public List<Result> results { get; set; }
            public Cursor cursor { get; set; }
        }

        public class Root
        {
            public ResponseData responseData { get; set; }
            public object responseDetails { get; set; }
            public int responseStatus { get; set; }
            public string loanNumber { get; set; }
        }
    }
        
 
}
