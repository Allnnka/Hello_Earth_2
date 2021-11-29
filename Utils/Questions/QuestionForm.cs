using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Earth_2.Utils.Questions
{
    public class QuestionForm
    {
        //public static List<Question> FormQuestions { get; private set; }

        public static List<Question> GetQuestions()
        {
            List<Question>  FormQuestions = new List<Question>();

            FormQuestions.Add(new Question()
            {
                QuestionText = "Podaj swoje dane",
                QuestionType = QuestionType.Person,
                IsPersonMentor = true,
            });

            FormQuestions.Add(new Question()
            {
                QuestionText = "Podaj dane gracza",
                QuestionType = QuestionType.Person,
                IsPersonKid = true,
            });

            FormQuestions.Add(new Question()
            {
                QuestionText = "Dodaj innych członków rodziny",
                QuestionType = QuestionType.PersonList
            });

            FormQuestions.Add(new Question()
            {
                QuestionText = "Wpisz jak gracz zwraca się do opiekuna w różnych przypadkach.\n\n" +
               "<size=30>Mianownik</size> (kto? co?):",
                QuestionType = QuestionType.Variable,
                VariableId = "opiekun",
                VariableType = "String"
            });

            FormQuestions.Add(new Question()
            {
                QuestionText = "Wpisz jak gracz zwraca się do opiekuna w różnych przypadkach.\n\n" +
                "<size=30>Dopełniacz</size> (kogo? czego?):",
                QuestionType = QuestionType.Variable,
                VariableId = "opiekuna",
                VariableType = "String"
            });

            FormQuestions.Add(new Question()
            {
                QuestionText = "Wpisz jak gracz zwraca się do opiekuna w różnych przypadkach.\n\n" +
                "<size=30>Celownik</size> (komu? czemu?):",
                QuestionType = QuestionType.Variable,
                VariableId = "opiekunowi",
                VariableType = "String"
            });

            FormQuestions.Add(new Question()
            {
                QuestionText = "Wpisz jak gracz zwraca się do opiekuna w różnych przypadkach.\n\n" +
                "<size=30>Biernik</size> (kogo? co?):",
                QuestionType = QuestionType.Variable,
                VariableId = "opiekuna_B",
                VariableType = "String"
            });

            FormQuestions.Add(new Question()
            {
                QuestionText = "Wpisz jak gracz zwraca się do opiekuna w różnych przypadkach.\n\n" +
                "<size=30>Narzędnik</size> (z kim? z czym?):",
                QuestionType = QuestionType.Variable,
                VariableId = "opiekunem",
                VariableType = "String"
            });

            FormQuestions.Add(new Question()
            {
                QuestionText = "Wpisz jak gracz zwraca się do opiekuna w różnych przypadkach.\n\n" +
                "<size=30>Miejscownik</size> (o kim? o czym?):",
                QuestionType = QuestionType.Variable,
                VariableId = "opiekunie",
                VariableType = "String"
            });

            FormQuestions.Add(new Question()
            {
                QuestionText = "Wpisz po przecinku kobiety, którym gracz kupuje kwiaty na Dzień Kobiet",
                QuestionType = QuestionType.Variable,
                VariableId = "dla_kogo_kwiaty",
                VariableType = "String"
            });

            FormQuestions.Add(new Question()
            {
                QuestionText = "Podaj dane szkoły dziecka",
                QuestionType = QuestionType.Place,
                PlaceId = "szkola"
            });

            FormQuestions.Add(new Question()
            {
                QuestionText = "Podaj dane pobliskiego sklepu",
                QuestionType = QuestionType.Place,
                PlaceId = "sklep"
            });

            FormQuestions.Add(new Question()
            {
                QuestionText = "Podaj dane pobliskiego kina",
                QuestionType = QuestionType.Place,
                PlaceId = "kino"
            });

            FormQuestions.Add(new Question()
            {
                QuestionText = "Podaj dane fryzjera gracza",
                QuestionType = QuestionType.Place,
                PlaceId = "fryzjer"
            });

            FormQuestions.Add(new Question()
            {
                QuestionText = "Podaj dane pizzerii",
                QuestionType = QuestionType.Place,
                PlaceId = "pizzeria"
            });

            FormQuestions.Add(new Question()
            {
                QuestionText = "Podaj miejsce do spaceru",
                QuestionType = QuestionType.Place,
                PlaceId = "miejsce_spaceru"
            });

            FormQuestions.Add(new Question()
            {
                QuestionText = "Podaj ulubione miejsce gracza",
                QuestionType = QuestionType.Place,
                PlaceId = "ulubione_miejsce"
            });

            FormQuestions.Add(new Question()
            {
                QuestionText = "Czy dziecko posiada bilet miesięczny?",
                QuestionType = QuestionType.Variable,
                VariableId = "ma_miesieczny",
                VariableType = "Bool"
            });

            FormQuestions.Add(new Question()
            {
                QuestionText = "Czy dziecko jest podwożone? (W razie zaznaczania tej opcji w grze nie będą pojawiać się zadania wymagające samodzielnego poruszania się po mieście komunikacją miejską. Zalecamy jej nie zaznaczać. Pozycja dziecka będzie w każdej chwili widoczna na Państwa telefonie)",
                QuestionType = QuestionType.Variable,
                VariableId = "czy_dojazd_autem",
                VariableType = "Bool"
            });

            FormQuestions.Add(new Question()
            {
                QuestionText = "Jaki dzień tygodnia jest dniem sprzątania?",
                QuestionType = QuestionType.VariableDay,
                VariableId = "dzien_sprzatania",
                VariableType = "Int"
            });

            FormQuestions.Add(new Question()
            {
                QuestionText = "Podaj nazwę pokoju, w którym dziecko będzie zmywać podłogę (np. kuchnia lub przedpokój)",
                QuestionType = QuestionType.Variable,
                VariableId = "pokoj_do_mycia_podlogi",
                VariableType = "String"
            });

            FormQuestions.Add(new Question()
            {
                QuestionText = "Czy gracz będzie odpowiedzialny tylko za pranie swoich rzeczy?",
                QuestionType = QuestionType.Variable,
                VariableId = "czy_pomaga_w_praniu_ogolnodomowym",
                VariableType = "Bool"
            });

            FormQuestions.Add(new Question()
            {
                QuestionText = "Czy pralka jest cały czas podłączona do prądu?",
                QuestionType = QuestionType.Variable,
                VariableId = "pralka_zawsze_podlaczona",
                VariableType = "Bool"
            });

            FormQuestions.Add(new Question()
            {
                QuestionText = "W którym dniu tygodnia jest robione pranie?",
                QuestionType = QuestionType.VariableDay,
                VariableId = "dzien_prania",
                VariableType = "Int"
            });

            FormQuestions.Add(new Question()
            {
                QuestionText = "Czy do suszenia prania wykorzystywana jest rozkładana suszarka??",
                QuestionType = QuestionType.Variable,
                VariableId = "czy_uzywana_suszarka_rozkladana",
                VariableType = "Bool"
            });

            FormQuestions.Add(new Question()
            {
                QuestionText = "Czy w domu gracza prasuje się rzeczy?",
                QuestionType = QuestionType.Variable,
                VariableId = "czy_prasuje_sie_rzeczy",
                VariableType = "Bool"
            });

            FormQuestions.Add(new Question()
            {
                QuestionText = "Czy dziecko może spożywać mleko?",
                QuestionType = QuestionType.Variable,
                VariableId = "czy_moze_mleko",
                VariableType = "Bool"
            });

            FormQuestions.Add(new Question()
            {
                QuestionText = "Czy w domu jest zmywarka?",
                QuestionType = QuestionType.Variable,
                VariableId = "czy_jest_zmywarka",
                VariableType = "Bool"
            });

            FormQuestions.Add(new Question()
            {
                QuestionText = "Jaki ciepły napój lubi gracz? (np. herbata lub kawa inka)",
                QuestionType = QuestionType.Variable,
                VariableId = "jaki_cieply_napoj",
                VariableType = "String"
            });

            FormQuestions.Add(new Question()
            {
                QuestionText = "Czy w domu kupowany jest chleb krojony?",
                QuestionType = QuestionType.Variable,
                VariableId = "czy_chleb_krojony",
                VariableType = "Bool"
            });


            FormQuestions.Add(new Question()
            {
                QuestionText = "Czy gracz smaruje chleb masłem?",
                QuestionType = QuestionType.Variable,
                VariableId = "czy_smaruje_chleb_maslem",
                VariableType = "Bool"
            });
            return FormQuestions;

        }
    }
}
