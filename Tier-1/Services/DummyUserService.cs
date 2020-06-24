using System.Threading.Tasks;
using System.Collections.Generic;
using DiningApp.Data;
using System;

namespace DiningApp.Data
{
    public class DummyUserService : IUserService
    {
        List<User> dummyUsers ;
        public DummyUserService()
        {
          dummyUsers = new List<User>();
          User other = new User();
          other.FirstName="a";
          other.LastName="a";
          other.EmailAddress = "a@a.dk";
          other.Password = "11111";


          dummyUsers.Add(other);
        }
       

        public string RegisterUser(User user)
        {   
            Console.WriteLine("[INFO]******************** NEW USER REGISTERED");
            int id = dummyUsers.Count + 1;
            user.UserId = id;       
            dummyUsers.Add(user);
            Console.WriteLine(user.ToString());
            return user.ToString();
        }
        public void ValidateLogin(string username,string password)
        {
             Console.WriteLine("[INFO]******************** USER VALIDATION");
             Console.WriteLine(username);
              Console.WriteLine(password);

        }

        public Task<User> GetUserByID(int id)
        {
            foreach (User other in dummyUsers)
            {
                if (other.UserId ==id)
                {
                    return Task.FromResult(other);
                }
            }
          return null;
        }

        public Task<string> PostNewUser(User newUser)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByEmailAsync(string email)
        {
            foreach(var dummy in dummyUsers)
            {
                if(dummy.EmailAddress.Equals(email))
                {
                    return Task.FromResult(dummy);
                }
            }
            return Task.FromResult(dummyUsers[0]);
        }
         public  User GetUserByEmail(string email)
        {
            foreach(var dummy in dummyUsers)
            {
                if(dummy.EmailAddress.Equals(email))
                {
                    return dummy;
                }
            }
            return null;
        }

        public Task<string> UpdateUser(User newUser)
        {
            throw new NotImplementedException();
        }
    }
}
    

    
