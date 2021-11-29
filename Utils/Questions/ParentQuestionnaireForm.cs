using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Earth_2.Utils.Questions
{
    public class ParentQuestionnaireForm
    {
        public static List<Question> GetQuestions()
        {
            List<Question> formQuestions = new List<Question>();
            formQuestions.Add(new Question()
            {
                QuestionText = "Czy znasz treść tego zadania?",
                QuestionType = QuestionType.Choice,
                ChoiceOptions = new List<string>() { "Nie", "Raczej nie", "Raczej tak", "Tak" },
            });

            formQuestions.Add(new Question()
            {
                QuestionText = "Czy zadanie było zrozumiałe dla gracza?",
                QuestionType = QuestionType.Choice,
                ChoiceOptions = new List<string>() { "Nie", "Raczej nie", "Raczej tak", "Tak" },
            });

            formQuestions.Add(new Question()
            {
                QuestionText = "Czy wymagało dodatkowych wyjaśnień?",
                QuestionType = QuestionType.Choice,
                ChoiceOptions = new List<string>() { "Nie", "Raczej nie", "Raczej tak", "Tak" },
            });

            formQuestions.Add(new Question()
            {
                QuestionText = "Czy zadanie było trudne do realizacji dla gracza?",
                QuestionType = QuestionType.Choice,
                ChoiceOptions = new List<string>() { "Nie", "Raczej nie", "Raczej tak", "Tak" },
            });

            formQuestions.Add(new Question()
            {
                QuestionText = "Czy gracza narzekał na zadanie?",
                QuestionType = QuestionType.Choice,
                ChoiceOptions = new List<string>() { "Nie", "Raczej nie", "Raczej tak", "Tak" },
            });

            formQuestions.Add(new Question()
            {
                QuestionText = "Czy gracz wymagał pomocy w realizacji zadania (innej niż ew. dojazd)?",
                QuestionType = QuestionType.Choice,
                ChoiceOptions = new List<string>() { "Nie", "Raczej nie", "Raczej tak", "Tak" },
            });

            formQuestions.Add(new Question()
            {
                QuestionText = "Czy zdobyta przez gracza nagroda była dla niego satysfakcjonująca?",
                QuestionType = QuestionType.Choice,
                ChoiceOptions = new List<string>() { "Nie", "Raczej nie", "Raczej tak", "Tak" },
            });

            formQuestions.Add(new Question()
            {
                QuestionText = "Czy gracz odczuwa satysfakcję/dumę/zadowolenie z realizacji zadania?",
                QuestionType = QuestionType.Choice,
                ChoiceOptions = new List<string>() { "Nie", "Raczej nie", "Raczej tak", "Tak" },
            });

            formQuestions.Add(new Question()
            {
                QuestionText = "Czy Tobie podobało się to zadanie?",
                QuestionType = QuestionType.Choice,
                ChoiceOptions = new List<string>() { "Nie", "Raczej nie", "Raczej tak", "Tak" },
            });

            formQuestions.Add(new Question()
            {
                QuestionText = "Czy gracz spontanicznie mówił Tobie lub innym osobom o tym zadaniu?",
                QuestionType = QuestionType.Choice,
                ChoiceOptions = new List<string>() { "Nie", "Raczej nie", "Raczej tak", "Tak" },
            });

            formQuestions.Add(new Question()
            {
                QuestionText = "Czy gracz spontanicznie mówił Tobie lub innym osobom o tym zadaniu?",
                QuestionType = QuestionType.Choice,
                ChoiceOptions = new List<string>() { "Nie", "Raczej nie", "Raczej tak", "Tak" },
            });

            formQuestions.Add(new Question()
            {
                QuestionText = "W jakiej formie było dziecko w trakcie wykonywania zadań?",
                QuestionType = QuestionType.Multiline,
                VariableType = "String",
                IsMultiline = true
            });

            formQuestions.Add(new Question()
            {
                QuestionText = "Jaka była motywacja dziecka?",
                QuestionType = QuestionType.Multiline,
                VariableType = "String",
                IsMultiline = true
            });

            formQuestions.Add(new Question()
            {
                QuestionText = "Co stanowiło trudność w wykonywaniu zadań",
                QuestionType = QuestionType.Multiline,
                VariableType = "String",
                IsMultiline = true
            });
            return formQuestions;
        }
    }
}
