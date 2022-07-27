using System;
using System.Collections.Generic;
using System.Text;

namespace Hello_Earth_2.Model
{
    public class Mission
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string Image { get; set; }
        public List<Steps> Steps { get; set; }
        public List<Ingredients> Ingredients { get; set; }
        public List<Contraindications> Contraindications { get; set; }
        public MissionType TaskType { get; set; }
        public bool IsBlocked { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsStarted { get; set; }
    }
}
