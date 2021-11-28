using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Earth_2.Data.Quest
{
    public class QuestModel
    {
        public string Id { get; set; }
        public string Code{ get; set; }
        public string Title { get; set; }
        public QuestModel(string Code, string Title)
        {
            this.Code = Code;
            this.Title = Title;
        }
        public QuestModel() { }
        /*public int RepetitionsNumber { get; set; }
        public string PresentationFormat{ get; set; }
        public string CompletionCondition { get; set; }
        public ICollection<Step> Steps{ get; set; }*/
    }
}
