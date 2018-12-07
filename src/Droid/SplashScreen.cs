﻿using Android.App;
using Android.Content.PM;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace Phonebook.Droid
{
    [Activity(
        Label = "Phonebook"
        , MainLauncher = true
        , NoHistory = true
        , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenAppCompatActivity<Setup, Core.App>
    {
        public SplashScreen() : base(Resource.Layout.splash_screen)
        {
        }
    }
}
