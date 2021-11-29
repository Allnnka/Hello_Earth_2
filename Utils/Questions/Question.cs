using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Earth_2.Utils.Questions
{
    public enum QuestionType { Person, Place, Variable, VariableDay, Choice, Multiline, PersonList }
    public class Question
    {
        public string QuestionText;
        public QuestionType QuestionType;

        public string PlaceId;

        public string VariableId;
        public string VariableType;
        public bool IsMultiline;

        public bool IsPersonMentor;
        public bool IsPersonKid;

        public List<string> ChoiceOptions;
        //public Func<Parent_Form, bool> AdditionalValidation;
    }
}
