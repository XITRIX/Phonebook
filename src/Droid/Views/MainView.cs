using Android.App;
using Android.OS;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using Phonebook.Core.ViewModels;
using MvvmCross.Droid.Support.V7.RecyclerView;
using Android.Support.V7.Widget;
using Java.Security;
using System.Windows.Input;
using MvvmCross.Binding.BindingContext;

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
            SetContentView(Resource.Layout.activity_contacts_list);
            var scrollListener = new BottomReachedScrollListener();

            var set = this.CreateBindingSet<MainView, MainViewModel>();
            set.Bind(scrollListener).For(s => s.PagingCommand).To(vm => vm.LoadContactsCommand);
            set.Apply();

            FindViewById<MvxRecyclerView>(Resource.Id.recyclerView).AddOnScrollListener(scrollListener);
        }
    }

    class BottomReachedScrollListener : MvxRecyclerView.OnScrollListener
    {
        public ICommand PagingCommand { get; set; }
        public override void OnScrollStateChanged(RecyclerView recyclerView, int newState)
        {
            base.OnScrollStateChanged(recyclerView, newState);

            if (!recyclerView.CanScrollVertically(1) &&
            (PagingCommand?.CanExecute(null) ?? false))
            {
                PagingCommand.Execute(null);
            }
        }
    }
}

