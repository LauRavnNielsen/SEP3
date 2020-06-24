using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiningApp.Data
{
    public interface IEventService{


        // Implemented
        
        Task<string> GetAllEventsAsync();
        
        Task<string> SearchEventsTestAsync(string city);

        // Tested
        Task<string>  CreateNewEvent(Event newEvent);
        Task<string> CancelEvent(Event newEvent);
        Task<string>  UpdateEvent(Event newEvent);



        
        //Rest

        Task<Event[]> GetEventAsync(DateTime startDate);
        void PostNewEvent(Event newEvent);
        
        Task<List<Event>> GetEventListAsync();
        Task<Event> GetEventDetailsByID(int id);
         
        Task<List<Event>> SearchEventsAsync(string city);



       
    }
}