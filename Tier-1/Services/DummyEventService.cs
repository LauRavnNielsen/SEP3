using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace DiningApp.Data
{
    public class DummyEventService : IEventService
    {
        List<Event> allEvents = new List<Event>();

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

        public Task<Event[]> GetEventAsync(DateTime startDate)
        {
            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, 20).Select(index => new Event
            {
                UserId = 0,
                Date = "1/11/1111",
                NrOfGuests = rng.Next(1, 10),
                City = City[rng.Next(City.Length)],
                Description = Description[rng.Next(Description.Length)]
            }).ToArray());
        }

        public void PostNewEvent(Event newEvent)
        {
            Console.WriteLine("[INFO]***********************EVENT POSTED");
            newEvent.ToString();
            allEvents.Add(newEvent);
        }

        public void CancelEvent(string eventId)
        {
             Console.WriteLine("[INFO]***********************EVENT CANCELED");
        }


        public async Task<string> GetAllEventsAsync(){
            throw new NotImplementedException();

        }

        public Task<string> SearchEventsTestAsync(string city)
        {
            throw new NotImplementedException();
        }

        public Task<List<Event>> GetEventListAsync()
        {
            bool random = false;


            for (int i = 0; i < 20; i++)
            { 
               
              random = !random;
               
                var rng = new Random();
                Event other = new Event
                {
                    EventID = i,
                    UserId = i,
                    Date = "1/11/1111",
                    NrOfGuests = rng.Next(1, 10),
                    City = City[rng.Next(City.Length)],
                    Description = Description[rng.Next(Description.Length)],
                    Pets = random,
                    Drinks = random,
                    Entertainment = random
                };
                allEvents.Add(other);
            }
             Console.WriteLine("[PETS]*************************");
            Console.WriteLine(random);
            return Task.FromResult(allEvents);
        }
        public Task<Event> GetEventDetailsByID(int id)
        {
            foreach (Event other in allEvents)
            {
                if (other.EventID == id)
                {
                    return Task.FromResult(other);
                }
            }
          return null;
        }

        public Task<string> CreateNewEvent(Event newEvent)
        {
            throw new NotImplementedException();
        }

        public Task<string> CancelEvent(Event newEvent)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateEvent(Event newEvent)
        {
            throw new NotImplementedException();
        }

        public Task<List<Event>> SearchEventsAsync(string city)
        {
            throw new NotImplementedException();
        }
    }
}
