using Hello_Earth_2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Earth_2.Services.ServiceImplementation
{
    public class MissionServiceImplementation : IMissionService
    {
        public async Task<List<Mission>> GetAllLevelOneMissions()
        {
            List<Mission> missions = new List<Mission>();
            return (await RealtimeConfig.FirebaseConfig.Child("/missions/levelOne").OnceAsync<Mission>()).Select(x =>
            new Mission
            {
                Contraindications = x.Object.Contraindications,
                Image = x.Object.Image,
                Ingredients = x.Object.Ingredients,
                IsBlocked = x.Object.IsBlocked,
                IsCompleted = x.Object.IsCompleted,
                IsStarted = x.Object.IsStarted,
                LongDescription = x.Object.LongDescription,
                ShortDescription = x.Object.ShortDescription,
                Steps = x.Object.Steps,
                TaskType = x.Object.TaskType,
                Title = x.Object.Title,
            }).ToList();
        }
    }
}
