using System;
using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
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

            var toolBar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolBar);

            var recyclerView = FindViewById<MvxRecyclerView>(Resource.Id.recyclerView);
            var recyclerAdapter = new ContactsAdapter((IMvxAndroidBindingContext)BindingContext);

            recyclerView.Adapter = recyclerAdapter;

            var set = this.CreateBindingSet<ContactsActivity, ContactsViewModel>();
            set.Bind(recyclerAdapter).For(s => s.ItemsSource).To(vm => vm.Items);
            set.Bind(recyclerAdapter).For(s => s.ItemClick).To(vm => vm.NavigateToDetailsCommand);
            set.Bind(recyclerAdapter).For(s => s.PagingCommand).To(vm => vm.LoadContactsCommand);
            set.Bind(recyclerAdapter).For(s => s.IsLoading).To(vm => vm.IsLoading);
            set.Apply();
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    if (FragmentManager.BackStackEntryCount >= 1)
                    {
                        if (FragmentManager.BackStackEntryCount == 1)
                        {
                            SupportActionBar.SetDisplayHomeAsUpEnabled(false);
                        }
                        FragmentManager.PopBackStack();
                    }
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}

