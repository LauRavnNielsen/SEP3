using System;
using System.ComponentModel.DataAnnotations;
//using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DiningApp.Data
{
    public class User
    {
     
   
        [Required(ErrorMessage = "Required")]
        [JsonPropertyName("userId")]
        [Display(Name = "User Id")]
        public int UserId { get; set; }






        [Required(ErrorMessage = "Required")]
        [JsonPropertyName("fName")]
        [Display(Name = "First name")]
        [StringLength(15, ErrorMessage = "Name is too long.")]
        public string FirstName { get; set; }




  
        [Required(ErrorMessage = "Required")]
        [JsonPropertyName("lName")]
        [Display(Name = "Last name")]
        [StringLength(15, ErrorMessage = "Last name is too long.")]
        public string LastName { get; set; }





       
        [Required(ErrorMessage = "Required")]
        [EmailAddress]
        [JsonPropertyName("email")]
        [Display(Name = "Email address")]

        public string EmailAddress { get; set; }




       

        [Required(ErrorMessage = "Required")]
        [JsonPropertyName("dob")]
        [Display(Name = "Date of birth")]
        public string DOB  { get; set; }







  
        [RegularExpression(@"^.{5,}$", ErrorMessage = "Minimum 3 characters required")]
        [Required(ErrorMessage = "Required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Invalid")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [JsonPropertyName("password")]
        public string Password{get;set;}




        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
       
        [JsonPropertyName("password2")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword {get;set;}

   
        


        public override string ToString(){
            return "USer Id: " + UserId + 
            " First Name: " + FirstName + 
            " Last Name: " + LastName + 
            " Email  Address: " + EmailAddress +
            "DOB" + DOB;
        }
    }

}