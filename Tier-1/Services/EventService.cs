using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DiningApp.Data;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace DiningApp.Data
{
    public class EventService : IEventService
    {
        List<Event> allEvents = new List<Event>();
        
        private string IP = "10.152.202.119";

        private static readonly string[] City = new[]
        {
            "Aarhus", "Horsens"
        };

        private static readonly string[] Description = new[]
        {
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Laoreet id donec ultrices tincidunt arcu non sodales. Lorem donec massa sapien faucibus et molestie.",
            "Tristique senectus et netus et malesuada fames ac turpis. ",
            "Et malesuada fames ac turpis egestas sed tempus urna. ",
            "Id neque aliquam vestibulum morbi blandit. Dignissim suspendisse in est ante in nibh. Urna cursus eget nunc scelerisque viverra mauris.",
            " Nunc eget lorem dolor sed viverra ipsum nunc. Mauris in aliquam sem fringilla ut morbi tincidunt. Vitae suscipit tellus mauris a diam maecenas. ",
            "Non curabitur gravida arcu ac. Interdum velit euismod in pellentesque massa placerat duis ultricies lacus. Pharetra et ultrices neque ornare aenean euismod elementum nisi quis. ",
            "Sed faucibus turpis in eu mi bibendum neque egestas congue. Et netus et malesuada fames ac turpis egestas integer. Tellus rutrum tellus pellentesque eu tincidunt tortor aliquam.",
            "Diam donec adipiscing tristique risus nec. Ullamcorper sit amet risus nullam. Congue eu consequat ac felis. Vel risus commodo viverra maecenas accumsan lacus vel. "
        };

        //Tested
        public async Task<string> CancelEvent(Event newEvent)
        {
            Console.WriteLine("HTTP REQUEST: CANCEL EVENT");
            Console.WriteLine(newEvent.ToString());
            
            HttpClient client = new HttpClient();
            string requestUrl = $"http://{IP}:8080/startApplication/api/cancelEvent";
            HttpResponseMessage response =
                await HelperMethods.PostAsJsonAsync(client, requestUrl, newEvent);
            return response.ToString();
        }


        public async  Task<string> SearchEventsTestAsync(string city)
        {
            Console.WriteLine("HTTP REQUEST: SEARCH EVENT");
            
            HttpClient client = new HttpClient();
            string requestUrl = $"http://{IP}:8080/startApplication/api/search?city={city}";
            
            string s = await client.GetStringAsync(requestUrl);
           
            return s;
        }

        public async Task<string> CreateNewEvent(Event newEvent)
        {
            Console.WriteLine("HTTP REQUEST: CREATE EVENT");
            Console.WriteLine(newEvent.ToString());
            
            HttpClient client = new HttpClient();
            string requestUrl = $"http://{IP}:8080/startApplication/api/newEvent";
            HttpResponseMessage response =
                await HelperMethods.PostAsJsonAsync(client, requestUrl, newEvent);
            return response.ToString();
        }


        public async Task<string> UpdateEvent(Event newEvent)
        {
            Console.WriteLine("HTTP REQUEST: UPDATE EVENT");
            Console.WriteLine(newEvent.ToString());
            
            HttpClient client = new HttpClient();
            string requestUrl = $"http://{IP}:8080/startApplication/api/updateEvent";
            HttpResponseMessage response =
                await HelperMethods.PostAsJsonAsync(client, requestUrl, newEvent);
            return response.ToString();
        }


        public async Task<string> GetAllEventsAsync()
        {
            HttpClient client = new HttpClient();
            string requestUrl = $"http://{IP}:8080/startApplication/api/events";


            Console.WriteLine("Fetching data...");
            string json = await client.GetStringAsync(requestUrl);
            Event result = JsonConvert.DeserializeObject<Event>(json);
            Console.WriteLine(result.ToString());
            Console.WriteLine(json);
            return json;
        }


        public async Task<List<Event>> SearchEventsAsync(string city)
        {
            Console.WriteLine("HTTP REQUEST: SEARCH EVENT");
            
            HttpClient client = new HttpClient();
            string requestUrl = $"http://{IP}:8080/startApplication/api/search?city={city}";
            
            string json = await client.GetStringAsync(requestUrl);
            Console.WriteLine(json);
            var result = JsonConvert.DeserializeObject <List<Event>>(json);
            Console.WriteLine(result.ToString());
            Console.WriteLine(requestUrl);
            return result;
          
        }


        
        
        public Task<Event[]> GetEventAsync(DateTime startDate)
        {
            throw new NotImplementedException();
        }


        public async Task<Event> GetEventDetailsByID(int id)
        {
            
            Console.WriteLine("HTTP REQUEST: EVENT DETAILS");
            
            HttpClient client = new HttpClient();
            string requestUrl = $"http://{IP}:8080/startApplication/api/eventsId?eventId={id}";
            
            string json = await client.GetStringAsync(requestUrl);
            Console.WriteLine("HTTP REQUEST: EVENT DETAILS--------> JSON");
            Console.WriteLine(json);
            
            
            Event result = JsonSerializer.Deserialize<Event>(json);
            Console.WriteLine("HTTP REQUEST: EVENT DETAILS-----------> EVENT");
            Console.WriteLine(result.ToString());
            Console.WriteLine(requestUrl);
            return result;
        }


        public async Task<List<Event>> GetEventListAsync()
        {
            Console.WriteLine("HTTP REQUEST: SEARCH EVENT LIST");
            
            HttpClient client = new HttpClient();
            string requestUrl = $"http://{IP}:8080/startApplication/api/events";
            
            string json = await client.GetStringAsync(requestUrl);
            Console.WriteLine(json);
            List<Event> result = JsonConvert.DeserializeObject <List<Event>>(json);
            Console.WriteLine(result.ToString());
            Console.WriteLine(requestUrl);
            return result;
        }

        public async Task<Event[]> GetEventsAsync()
        {
            Event[] events = null;
            return events;
        }


        public async Task<string> PostNewEvent(Event newEvent)
        {
            HttpClient client = new HttpClient();
            string requestUrl = "";
            HttpResponseMessage response =
                await HelperMethods.PostAsJsonAsync(client, requestUrl, newEvent);
            return response.ToString();
        }


        void IEventService.PostNewEvent(Event newEvent)
        {
            throw new NotImplementedException();
        }
    }
}