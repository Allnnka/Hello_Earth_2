using Hello_Earth_2.Model;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Hello_Earth_2.Services.ServiceImplementation
{
    public class UserServiceImplementation : IUserServives
    {
        public async Task createUser(User user)
        {
            await RealtimeConfig.FirebaseConfig.Child("/users").PostAsync(JsonConvert.SerializeObject(user));
        }
    }
}
