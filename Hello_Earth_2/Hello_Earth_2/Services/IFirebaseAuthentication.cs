using Hello_Earth_2.Model.UserAuth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Earth_2.Services
{
    public interface IFirebaseAuthentication
    {
        Task<UserAuth> LoginWithEmailPassword(string email, string password);
        Task<UserAuth> RegisterWithEmailPassword(string email, string password);
        UserAuth GetUserAuth();
        Task<bool> SendEmailVerification();
        void SignOut();
    }
}
