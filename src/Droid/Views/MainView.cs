using Android.App;
using Android.OS;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using Phonebook.Core.ViewModels;

namespace Phonebook.Droid
{
    [MvxActivityPresentation]
    [Activity(Label = "Phonebook", MainLauncher = true, Icon = "@mipmap/icon", Theme = "@style/MainTheme")]
    public class MainView : MvxAppCompatActivity<MainViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.MainView);
        }
    }
}

