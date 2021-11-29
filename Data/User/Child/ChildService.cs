using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Earth_2.Data.User.Child
{
    public class ChildService
    {

        public static async Task AddChild(string firstName, string lastName, string gender, long birthday, string phoneNumber)
        {   
            await FirebaseClientService.firebaseClient.Child("users").PostAsync(new Child() { FirstName = firstName, LastName = lastName, Role = Role.CHILD, Gender=gender,PhoneNumber=phoneNumber});
        }
    }
}
