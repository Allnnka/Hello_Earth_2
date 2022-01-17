using FirebaseAdmin.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Hello_Earth_2.Data.User
{
    internal class FirebaseAuthentication
    {
        public static async Task RegisterUser(string email, string password)
        {
            UserRecordArgs args = new UserRecordArgs()
            {
                Email = email,
                Password = password
            };
            UserRecord userRecord = await FirebaseAuth.DefaultInstance.CreateUserAsync(args);
            Console.WriteLine("Działa?");
            Console.WriteLine(userRecord.Email);
        }
    }
}
