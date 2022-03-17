using System;
using System.Collections.Generic;
using System.Text;

namespace Hello_Earth_2.Model
{
    public abstract class User
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public Roles Role { get; set; }

    }
}
