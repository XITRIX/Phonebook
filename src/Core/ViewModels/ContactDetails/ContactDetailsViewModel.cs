using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Phonebook.API;
using Phonebook.API.Models;
using Phonebook.Core.ViewModels.ContactPhoto;

namespace Phonebook.Core.ViewModels.ContactDetails
{
    public class ContactDetailsViewModel : MvxViewModel<User>
    {
        private readonly IMvxNavigationService _navigationService;
        private User _contact;

        private IMvxAsyncCommand _navigateToPhotoCommand;
        public IMvxAsyncCommand NavigateToPhotoCommand => _navigateToPhotoCommand ?? (_navigateToPhotoCommand = new MvxAsyncCommand(NavigateToPhoto));

        public string PhotoPath => _contact.Picture.Large;
        public string Name => $"{_contact.Name.Last.FirstCharToUpper()} {_contact.Name.First.FirstCharToUpper()}";
        public string Phone => _contact.Phone;
        public string Mail => _contact.Email;

        public ContactDetailsViewModel(IMvxNavigationService navigationService) {
            _navigationService = navigationService;
        }

        public override void Prepare(User parameter)
        {
            _contact = parameter;
        }

        private Task<bool> NavigateToPhoto() {
            return _navigationService.Navigate<ContactPhotoViewModel, string>(PhotoPath);
        }
    }
}
