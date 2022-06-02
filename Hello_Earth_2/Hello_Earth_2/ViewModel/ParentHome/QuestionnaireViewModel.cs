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
            Questionnaire  questionnaire = new Questionnaire();
            questionnaire.IsDishwasherProblem = _isDishwasherProblem;
            questionnaire.IsDrinkingMilkProblem = _isDrinkingMilkProblem;
            questionnaire.IsGoOutProblem = _isGoOutProblem;
            questionnaire.IsEatingSesamProblem= _isEatingSesamProblem;
            Family family = await familyService.GetFamilyData(auth.GetUserAuth().Uid);
            family.Child.Questionnaire = questionnaire;
            family.Child.IsQuestionnaireCompleted = true;
            await familyService.CreateFamily(family, auth.GetUserAuth().Uid);
            App.Current.MainPage = new NavigationPage(new ParentHomePage());
        }
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
