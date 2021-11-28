using Firebase.Database.Query;
using System.Threading.Tasks;
namespace Hello_Earth_2.Data.Quest
{
    public class QuestService
    {
        public static async Task AddGameTask(string code, string title)
        {
            await FirebaseClientService.firebaseClient.Child("quests").PostAsync(new QuestModel() {Title=title,Code=code });
        }
    }
}
