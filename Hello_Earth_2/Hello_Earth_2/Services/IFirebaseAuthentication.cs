using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Earth_2.Services
{
    public interface IFirebaseAuthentication
    {
        Task<string> LoginWithEmailPassword(string email, string password);
        Task<string> RegisterWithEmailPassword(string email, string password);
    }
}
