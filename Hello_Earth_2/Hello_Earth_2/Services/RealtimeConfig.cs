using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;

namespace Hello_Earth_2.Services
{
    public static class RealtimeConfig
    {
        public static FirebaseClient FirebaseConfig = new FirebaseClient("https://helloearth2-5887b-default-rtdb.europe-west1.firebasedatabase.app/");
    }
}
