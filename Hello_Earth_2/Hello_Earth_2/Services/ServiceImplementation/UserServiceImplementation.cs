using Hello_Earth_2.Model;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace Hello_Earth_2.Services.ServiceImplementation
{
    public class UserServiceImplementation : IUserServives
    {

        public async Task CreateUser(User user, string userUid)
        {
            await RealtimeConfig.FirebaseConfig.Child("/users/"+ userUid).PatchAsync(JsonConvert.SerializeObject(user));
        }

        public async Task<User> GetUser(string userUid)
        {
            return (await RealtimeConfig.FirebaseConfig.Child("users/" + userUid).OnceSingleAsync<User>());
        }
    }
}
