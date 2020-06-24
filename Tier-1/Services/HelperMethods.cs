using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DiningApp.Data
{
    public static class HelperMethods 
    {


        public static async Task<HttpResponseMessage> PostAsJsonAsync<TModel>(this HttpClient client, string requetsUrl, TModel model)
        {

               /*  JsonConvert.SerializeObject(model, 
                            Newtonsoft.Json.Formatting.None, 
                            new JsonSerializerSettings { 
                                NullValueHandling = NullValueHandling.Ignore
                            });
               */             

               
               
               
               var json = System.Text.Json.JsonSerializer.Serialize(model);
               Console.WriteLine("[INFO]*********************************************** JSON");
               Console.WriteLine(json);
               var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
               return await client.PostAsync(requetsUrl, stringContent);
            
            

        }
       public static async Task<string> GetDataAsync(this HttpClient client, string requetsUrl)
       {
           
           Console.WriteLine("Fetching data...");
           string s = await client.GetStringAsync(requetsUrl);
           return s;
       }

    }}