using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Hello_Earth_2.Model
{
    [DataContract]
    public class User
    {
        
        public string Uid { get; set; }
        [JsonProperty("UserName")]
        public string UserName { get; set; }
        [JsonProperty("Email")]
        public string Email { get; set; }
        [JsonProperty("Role")]
        public Roles Role { get; set; }

    }
}
