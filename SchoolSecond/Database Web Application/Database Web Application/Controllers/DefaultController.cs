using Microsoft.AspNetCore.Mvc;
using Firebase;
using Firebase.Auth;
using FireSharp;
using System.IO;
using Database_Web_Application.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Firebase.Auth.Providers;

namespace Database_Web_Application.Controllers
{

    public class DefaultController : Controller
    {



        FirebaseAuthConfig authConfig = new FirebaseAuthConfig()
        {
            ApiKey = "AIzaSyA5u4JqSt0sj6awoYjr2zU9mayuUQc6rZw",
            AuthDomain = "schule2ya.firebaseapp.com"
            
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
            FirebaseAuthClient client = new FirebaseAuthClient(authConfig);
            var result = await client.CreateUserWithEmailAndPasswordAsync("test@123.at","123");
            return View();
            
        }





    }
}
