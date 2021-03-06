﻿using Android.App;
using Android.Content.PM;
using MvvmCross.Platforms.Android.Views;

namespace Phonebook.Droid
{
    [Activity(
        Label = "Phonebook"
        , MainLauncher = true
        , NoHistory = true
        , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity<Setup, Core.App>
    {
        public SplashScreen() : base(Resource.Layout.splash_screen)
        {
        }
    }
}
