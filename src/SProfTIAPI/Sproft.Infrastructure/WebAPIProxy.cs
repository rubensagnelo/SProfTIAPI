using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using idbmongo;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Net;

namespace SProfTIAPI.proxy
{
    public class WebAPIProxy
    {

        public static T Get<T>(string url) {  
            try {  
                using(WebClient webClient = new WebClient()) {  
                    webClient.BaseAddress = url;  
                    var json = webClient.DownloadString("");  
                    var result = JsonConvert.DeserializeObject<T>(json);  
                    return result;  
                }  
            } catch (WebException ex) {  
                throw ex;  
        }  



    }

    }


}





//https://api.github.com/users?since=1000&per_page=5