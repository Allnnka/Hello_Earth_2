using Hello_Earth_2.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Earth_2.Services.ServiceImplementation
{
    internal class FamilyServiceImplementation : IFamilyServices
    {
        public async Task AddChildToFamily(Child child, string parentId)
        {
            await RealtimeConfig.FirebaseConfig.Child("/families/" + parentId + "/Child/").PatchAsync(JsonConvert.SerializeObject(child));
        }

        public async Task CreateFamily(Family family, string parentId)
        {
            await RealtimeConfig.FirebaseConfig.Child("/families/" + parentId).PatchAsync(JsonConvert.SerializeObject(family));
        }
    }
}
