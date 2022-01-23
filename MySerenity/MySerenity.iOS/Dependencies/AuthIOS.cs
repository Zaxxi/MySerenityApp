﻿using Foundation;
using MySerenity.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UIKit;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(MySerenity.iOS.Dependencies.AuthIOS))]
namespace MySerenity.iOS.Dependencies
{
    public class AuthIOS : IAuth
    {
        public string GetCurrentUserID()
        {
            return Firebase.Auth.Auth.DefaultInstance.CurrentUser.Uid;
        }

        public bool IsUserAuthenticated()
        {
            return Firebase.Auth.Auth.DefaultInstance.CurrentUser != null;
        }

        public async Task<bool> LoginUser(string email, string password)
        {
            try
            {
                await Firebase.Auth.Auth.DefaultInstance.SignInWithPasswordAsync(email, password);
                return true;
            }
            catch (NSErrorException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Unknown error");
            }
        }

        public async Task<bool> RegisterUser(string email, string password)
        {
            try
            {
                await Firebase.Auth.Auth.DefaultInstance.CreateUserAsync(email, password);
                return true;
            }
            catch (NSErrorException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Unknown error");
            }
        }
    }
}