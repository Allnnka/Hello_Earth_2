﻿using Hello_Earth_2.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Earth_2.Services
{
    public interface IFamilyServices
    {
        Task CreateFamily(Family family, string parentId);
        Task AddChildToFamily(ChildModel child, string parentId);
        Task<Family> GetFamilyData(string id);
        Task UpdateChild(ChildModel child, string parentId);
    }
}
