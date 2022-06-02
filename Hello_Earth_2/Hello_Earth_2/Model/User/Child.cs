using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hello_Earth_2.Model
{
    public class Child : User
    {
        [JsonProperty("FamilyId")]
        public string FamilyId { get; set; }
        [JsonProperty("Questionnaire")]
        public Questionnaire Questionnaire { get; set; }
        [JsonProperty("IsQuestionnaireCompleted")]
        public bool IsQuestionnaireCompleted { get; set; }
    }
}
