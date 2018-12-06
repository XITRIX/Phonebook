using System;
using Android.OS;
using Android.Views;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using Phonebook.Core.ViewModels.ContactPhoto;
using Phonebook.Core.ViewModels.Contacts;

namespace Phonebook.Droid.Views.ContactPhoto
{
    [MvxFragmentPresentation(
           ActivityHostViewModelType = typeof(ContactsViewModel),
           FragmentContentId = Resource.Id.contentFrame,
           AddToBackStack = true)]
    public class ContactPhotoFragment : MvxFragment<ContactPhotoViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            return this.BindingInflate(Resource.Layout.fragment_contact_photo, null);
        }
    }
}
