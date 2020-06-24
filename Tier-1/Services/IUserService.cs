using System.Threading.Tasks;

namespace DiningApp.Data{
    public interface IUserService{

        // Implemented
        Task<string> PostNewUser(User newUser);
         Task<string> UpdateUser(User newUser);

        // Rest

        string RegisterUser(User user);
        void ValidateLogin(string username,string password); 
        Task<User> GetUserByID(int id);
        Task<User> GetUserByEmailAsync(string email);
        User GetUserByEmail(string email);

        
       


    }
}