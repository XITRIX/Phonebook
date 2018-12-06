using System;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Phonebook.API.Models;
using Phonebook.Core.ViewModels.ContactPhoto;
using Phonebook.Core.ViewModels.Contacts.Items;
namespace Phonebook.Core.ViewModels.ContactDetails
{
    public class ContactDetailsViewModel : MvxViewModel<ContactItemVm>
    {
        private readonly IMvxNavigationService _navigationService;
        private ContactItemVm _contact;

        private IMvxAsyncCommand _navigateToPhotoCommand;
        public IMvxAsyncCommand NavigateToPhotoCommand => _navigateToPhotoCommand ?? (_navigateToPhotoCommand = new MvxAsyncCommand(() => { return _navigationService.Navigate<ContactPhotoViewModel, string>(Photo); }));

        public string Photo => _contact.Model.Picture.Large;
        public string Name => _contact.FullName;
        public string Phone => _contact.Phone;
        public string Mail => _contact.Mail;

        public ContactDetailsViewModel(IMvxNavigationService navigationService) {
            _navigationService = navigationService;
        }

        public override void Prepare(ContactItemVm parameter)
        {
            _contact = parameter;
        }
    }
}
