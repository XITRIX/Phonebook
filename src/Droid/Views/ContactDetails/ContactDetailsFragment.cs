using Android.OS;
using Android.Views;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views.Fragments;
using Phonebook.Core.ViewModels.ContactDetails;
using Phonebook.Core.ViewModels.Contacts;
using Phonebook.Droid.Contacts;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using Android.Runtime;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace Phonebook.Droid.Views.ContactDetails
{
    [MvxFragmentPresentation(
        ActivityHostViewModelType = typeof(ContactsViewModel), 
        FragmentContentId = Resource.Id.contentFrame, 
        AddToBackStack = true)]
    [Register(nameof(ContactDetailsFragment))]
    public class ContactDetailsFragment : MvxFragment<ContactDetailsViewModel>
    {
        public ContactDetailsFragment()
        {
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            ((MvxAppCompatActivity)Activity).SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            return this.BindingInflate(Resource.Layout.activity_contact_details, null);
        }
    }
}
