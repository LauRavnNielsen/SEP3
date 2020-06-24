using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Tier3.Data;
using Tier3.Models;
using Tier3.SocketsPackage;

namespace Tier3.Models
{
    public class DiningEventContext : DbContext
    {
        public DiningEventContext(DbContextOptions<DiningEventContext> options) : base(options)
        {
            SocketLogin();
        }






        public DbSet<DiningEvent> DiningEvents { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<User> User { get; set; }



        private void SocketLogin()
        {
            Console.WriteLine("Starting Server...");
            IPHostEntry host = Dns.GetHostEntry("localhost");
            IPAddress ipAddress = host.AddressList[1];
            IPEndPoint endPoint = new IPEndPoint(ipAddress, 4567);
            try
            { Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                listener.Bind(endPoint);
                //number of clients that can connect.
                listener.Listen(100);
                Console.WriteLine("Server started");
                Socket client = listener.Accept();
                Console.WriteLine("Client accepted");
                byte[] bytes = new byte[1024];
                int bytesRead = client.Receive(bytes);
                String messageFromClient = Encoding.ASCII.GetString(bytes, 4, bytesRead);
                Console.WriteLine(messageFromClient);
                Login login = JsonConvert.DeserializeObject<Login>(messageFromClient);
                Console.WriteLine(login.Email);
                var userFromDb = User.Single(a => a.Email.Equals(login.Email));
                if (userFromDb == null)
                { string msg = "Email not found";
                    byte[] bytemsg = Encoding.ASCII.GetBytes(msg);
                    client.Send(bytemsg); 
                }
                else if (userFromDb.Password.Equals(login.Password))
                {
                    string msg = "Login successful";
                    byte[] bytemsg = Encoding.ASCII.GetBytes(msg);
                    client.Send(bytemsg);
                }
                else
                {
                    string msg = "Password mismatched";
                    byte[] bytemsg = Encoding.ASCII.GetBytes(msg);
                    client.Send(bytemsg);
                }
                client.Close(); 
            }
            catch (Exception e)
            {
                Console.WriteLine("oopsie doopsie we made a whoopsie" + e.ToString());
            }
        }

        private void SendMessage(String message, NetworkStream stream)
        {
            byte[] bytess = Encoding.ASCII.GetBytes(message);
            stream.Write(bytess, 0, bytess.Length);
        }


    }
}


