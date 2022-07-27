using System;
using System.Collections.Generic;
using System.Text;

namespace Hello_Earth_2.Model
{
    public interface ILevel
    {
        List<Mission> missions { get; set; }
    }

    public class LevelOne : ILevel
    {
        public List<Mission> missions { get; set; } = new List<Mission>();
    }

    public class LevelTwo : ILevel
    {
        public List<Mission> missions { get; set; } = new List<Mission>();
    }

    public class LevelThree : ILevel
    {
        public List<Mission> missions { get; set; } = new List<Mission>();
    }
}
