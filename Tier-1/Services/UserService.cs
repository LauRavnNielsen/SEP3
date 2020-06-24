using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.Json;
using DiningApp.Data;
using System;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace DiningApp.Data
{
    public class UserService : IUserService
    {
        private string IP = "10.152.202.119";
        
         List<User> dummyUsers ;
        public UserService()
        {
          dummyUsers = new List<User>();
          User other = new User();
          other.FirstName="a";
          other.LastName="a";
          other.EmailAddress = "a@a.dk";
          other.Password = "11111";


          dummyUsers.Add(other);
        }
        
        public User GetUserByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
       
            Console.WriteLine("HTTP REQUEST: ACCOUNT DETAILS");
            
            HttpClient client = new HttpClient();
            string requestUrl = $"http://{IP}:8080/startApplication/api/userEmail?email={email}";
            
            string json = await client.GetStringAsync(requestUrl);
            Console.WriteLine("HTTP REQUEST: ACCOUNT DETAILS--------> JSON");
            Console.WriteLine(json);
            
           var result  = JsonSerializer.Deserialize<User>(json);
            //var result = JsonConvert.DeserializeObject<User>(json);
            Console.WriteLine("HTTP REQUEST: USER DETAILS-----------> USER");
            Console.WriteLine(result.ToString());
            Console.WriteLine(requestUrl);
            return result;
            
            
        }

        
        public Task<User> GetUserByID(int id)
        {
            throw new System.NotImplementedException();
        }


      
        public async Task<string> PostNewUser(User newUser){

             Console.WriteLine("HTTP REQUEST: REGISTER USER");
             Console.WriteLine(newUser.ToString());
             
              HttpClient client = new HttpClient();
              string requestUrl = $"http://{IP}:8080/startApplication/api/newUser";
               HttpResponseMessage response =
                 await  HelperMethods.PostAsJsonAsync(client, requestUrl, newUser);
                   return response.ToString();

         }
        public async Task<string> UpdateUser(User newUser)
        {
            Console.WriteLine("HTTP REQUEST: UPDATE USER");
             Console.WriteLine(newUser.ToString());

          

              HttpClient client = new HttpClient();
              string requestUrl = $"http://{IP}:8080/startApplication/api/updateUser";
               HttpResponseMessage response =
                 await  HelperMethods.PostAsJsonAsync(client, requestUrl, newUser);
                   return response.ToString();
        }

        public string RegisterUser(User user)
        {
            throw new System.NotImplementedException();
        }

        

        public void ValidateLogin(string username, string password)
        {
            throw new System.NotImplementedException();
        }


        /*

         public async Task<string> PostUser(string fName, string lName, string email, int age) {

             HttpClient client = new HttpClient();

             StringContent httpContent = new StringContent(
                 "{\"title\":\"delectus aut autem\"," +
                 "\"body\":\"my body\"," +
                 "\"userId\":\"1\"}",
                 Encoding.UTF8,
                 "application/json"
             );

             HttpResponseMessage response = 
                 await client.PostAsync("https://jsonplaceholder.typicode.com/posts", httpContent);
             return response.ToString();
         }

         public async Task<string> PostDataV2() {
             HttpClient client = new HttpClient();
             client.DefaultRequestHeaders.Accept.Clear();
             client.DefaultRequestHeaders.Accept.Add(
                 new MediaTypeWithQualityHeaderValue("application/json"));
             HttpResponseMessage response =
                 await client.PostAsJsonAsync("https://jsonplaceholder.typicode.com/posts", new Todo() {
                     title = "hej",
                     body = "my body",
                     userId = 1
                 });

             return response.ToString();
             return "hi";
         }
         
        */
    }
        }
    
