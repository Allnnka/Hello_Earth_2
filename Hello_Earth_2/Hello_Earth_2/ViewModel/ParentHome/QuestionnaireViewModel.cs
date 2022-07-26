using Hello_Earth_2.Model;
using Hello_Earth_2.Services;
using Hello_Earth_2.Services.ServiceImplementation;
using Hello_Earth_2.View.ParentHome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Hello_Earth_2.ViewModel.ParentHome
{
    public class QuestionnaireViewModel : INotifyPropertyChanged
    {
        FamilyServiceImplementation familyService;
        IFirebaseAuthentication auth = DependencyService.Get<IFirebaseAuthentication>();
        public event PropertyChangedEventHandler PropertyChanged;
        private bool _isGoOutProblem = false;
        private bool _isDishwasherProblem = false;
        private bool _isDrinkingMilkProblem = false;
        private bool _isEatingSesamProblem = false;

        public ICommand SaveQuestionnaireCommand { get; set; }

        public bool IsGoOutProblem 
        {
            get 
            { 
                return _isGoOutProblem; 
            }
            set
            {
                _isGoOutProblem = value;
                OnPropertyChanged(nameof(IsGoOutProblem));
            } 
        }
        public bool IsDishwasherProblem
        {
            get
            {
                return _isDishwasherProblem;
            }
            set
            {
                _isDishwasherProblem = value;
                OnPropertyChanged(nameof(IsDishwasherProblem));
            }
        }
        public bool IsDrinkingMilkProblem
        {
            get
            {
                return _isDrinkingMilkProblem;
            }
            set
            {
                _isDrinkingMilkProblem = value;
                OnPropertyChanged(nameof(IsDrinkingMilkProblem));
            }
        }
        public bool IsEatingSesamProblem
        {
            get
            {
                return _isEatingSesamProblem;
            }
            set
            {
                _isEatingSesamProblem = value;
                OnPropertyChanged(nameof(IsEatingSesamProblem));
            }
        }

        public QuestionnaireViewModel()
        {
            familyService = new FamilyServiceImplementation();
            SaveQuestionnaireCommand = new Command(() => SaveQuestionnaireHandler());
        }


        private async void SaveQuestionnaireHandler()
        {
            Family family = await familyService.GetFamilyData(auth.GetUserAuth().Uid);
            family.Child.Questionnaire = getQuestionnaire();
            family.Child.IsQuestionnaireCompleted = true;
            await familyService.CreateFamily(family, auth.GetUserAuth().Uid);
            App.Current.MainPage = new NavigationPage(new ParentHomePage());
        }
        private Questionnaire getQuestionnaire()
        {
            Questionnaire questionnaire = new Questionnaire
            {
                Contraindications = new List<Contraindications>()
            };
            if (_isDishwasherProblem)
            {
                questionnaire.Contraindications.Add(Contraindications.Dishwasher);
            }
            if (_isDrinkingMilkProblem){
                questionnaire.Contraindications.Add(Contraindications.Milk);
            }
            if (_isEatingSesamProblem)
            {
                questionnaire.Contraindications.Add(Contraindications.Sesame);
            }
            if (_isGoOutProblem)
            {
                questionnaire.Contraindications.Add(Contraindications.Outside);
            }
            return questionnaire; 
        }
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
