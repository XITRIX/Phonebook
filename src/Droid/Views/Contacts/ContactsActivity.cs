using Android.App;
using Android.OS;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using Phonebook.Core.ViewModels.Contacts;

namespace Phonebook.Droid.Contacts
{
    [MvxActivityPresentation]
    [Activity(Theme = "@style/MainTheme")]
    public class ContactsActivity : MvxAppCompatActivity<ContactsViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.activity_contacts_list);

            var recyclerView = FindViewById<MvxRecyclerView>(Resource.Id.recyclerView);
            var recyclerAdapter = new ContactsAdapter((IMvxAndroidBindingContext)BindingContext);

            var set = this.CreateBindingSet<ContactsActivity, ContactsViewModel>();
            set.Bind(recyclerAdapter).For(s => s.PagingCommand).To(vm => vm.LoadContactsCommand);
            set.Bind(recyclerAdapter).For(s => s.IsLoading).To(vm => vm.IsLoading);
            set.Apply();

            recyclerView.Adapter = recyclerAdapter;
        }
    }
}

