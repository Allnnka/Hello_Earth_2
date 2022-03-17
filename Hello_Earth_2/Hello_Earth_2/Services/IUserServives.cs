using Hello_Earth_2.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Earth_2.Services
{
    public interface IUserServives
    {
        Task createUser(User user);
    }
}
