using Microsoft.AspNetCore.Mvc;
using Firebase;
using Firebase.Auth;
using System.IO;
using Database_Web_Application.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Firebase.Auth.Providers;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using FirebaseAdmin.Auth;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Http.Metadata;

namespace Database_Web_Application.Controllers
{

    public class DefaultController : Controller
    {



        FirebaseAuthConfig authConfig = new FirebaseAuthConfig()
        {
            ApiKey = "AIzaSyA5u4JqSt0sj6awoYjr2zU9mayuUQc6rZw",
            AuthDomain = "schule2ya.firebaseapp.com",
            Providers = new FirebaseAuthProvider[] {new EmailProvider() }
        };





        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserLogin()
        {
            return View();
        }

        public async Task<IActionResult> VerifyLogin(Users user)
        {
            try
            {
                //Admin Rechte un steuerung
                FirebaseApp.Create(new AppOptions()
                {
                    Credential = GoogleCredential.FromFile("SKD.Json"),
                });

                //Authentifizierung user
                var Auth = new FirebaseAuthClient(authConfig);
                var result = await Auth.SignInWithEmailAndPasswordAsync(user.Username, user.Password);

                UserRecord userRecord = await FirebaseAuth.DefaultInstance.GetUserAsync(result.User.Uid);

               

               

                

                

                return RedirectToAction("Login_Success");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
               return RedirectToAction("Login_Failure");
            }

            
          
            





        }

        public IActionResult Login_Success()
        {
            return View();
        }

        public IActionResult Login_Failure()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }





    }
}
