using Hello_Earth_2.Model;
using Hello_Earth_2.Services.ServiceImplementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hello_Earth_2.ViewModel.Child.ChildHome
{
    public class ChildHomeViewModel
    {
        //UserServiceImplementation userService;
        MissionServiceImplementation missionService;
        List<Mission> missionsLevelOne = new List<Mission>();
        public ChildHomeViewModel()
        {
            missionService = new MissionServiceImplementation();
            LoadMissions();
        }

        private async void LoadMissions()
        {
            missionsLevelOne = await missionService.GetAllLevelOneMissions();
        }
    }
}
