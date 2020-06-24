using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
//using Newtonsoft.Json;


namespace DiningApp.Data
{
    public class Event
    {
        [JsonPropertyName("EventId")]
        public int EventID { get; set; }






        [JsonPropertyName("UserId")]
        public int UserId { get; set; }


        
        // Location parameters
        [Required]
        [JsonPropertyName("streetName")]
        public string Street { get; set; }
        
        [Required]
        [JsonPropertyName("City")]
        public string City { get; set; }
        
        
        
        
        
        [Required]
        [JsonPropertyName("PostCode")]
        public int PostCode { get; set; }
        

        [JsonPropertyName("BlockNumber")]
        public string BlockNumber { get; set; }
        
        [JsonPropertyName("FloorNumber")]
        public int FloorNumber { get; set; }
        
         
        
        [JsonPropertyName("FlatNumber")]
        public string FlatNumber { get; set; }
        
        
        [Required]
        [JsonPropertyName("buildingNo")]
        public int BuildingNumber { get; set; }
        
        

        //Date information
        [Required]
        [JsonPropertyName("DateOfEvent")]
        public string Date { get; set; }





        [Required]
        [JsonPropertyName("EventStart")]
        public string EventStart { get; set; }





        [Required]
        [JsonPropertyName("EventEnd")]
        public string EventEnd { get; set; }



        

        //Guest information

        [Required]
        [JsonPropertyName("NrOfGuests")]
        public int NrOfGuests { get; set; }






        [JsonPropertyName("AgeLimit")]
        public int AgeLimit { get; set; }




        [Required]
        [JsonPropertyName("Pets")]
        public bool Pets { get; set; }


        // Description
        [Required]
        [JsonPropertyName("Description")]
        public string Description { get; set; }




        [Required]
        [JsonPropertyName("Entertainment")]
        public bool Entertainment { get; set; }





        [Required]
        [JsonPropertyName("EntryFee")]
        public double EntryFee { get; set; }





        //Drinks
        [Required]
        [JsonPropertyName("AlcoholicDrink")]
        public bool Drinks { get; set; }






        //Food
        [JsonPropertyName("Starter")]
        public string Starter { get; set; }




        [Required]
        [JsonPropertyName("MainCourse")]
        public string MainCourse { get; set; }





        [JsonPropertyName("Dessert")]
        public string Dessert { get; set; }



        public override string ToString()
        {
            return "eventID" + EventID +
                     " userId " + UserId +
                     " street " + Street +
                    " city " +City +
                     " postCode " + PostCode +
                     " blockNumber " + BlockNumber + 
                     " floorNumber " + FloorNumber + 
                    " flatNumber " + FlatNumber +
                    " buildingNumber " + BuildingNumber + 
                    " date " + Date + 
                    " eventStart " + EventStart + 
                    " eventEnd " + EventEnd +
                    " nrOfGuests " + NrOfGuests +
                    " ageLimit " + AgeLimit + 
                    " pets " + Pets +
                    " description " + Description +
                    " entertainment " + Entertainment +
                    " entryFee " + EntryFee +
                    " drinks " + Drinks +
                    " starter " + Starter + 
                    " mainCourse " + MainCourse +
                    " dessert " + Dessert;
        }



    }
}