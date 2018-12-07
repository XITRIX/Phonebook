using System;
using MvvmCross.ViewModels;
namespace Phonebook.Core.ViewModels.ContactPhoto
{
    public class ContactPhotoViewModel : MvxViewModel<string>
    {
        public string PhotoPath { get; set; }

        public override void Prepare(string parameter)
        {
            PhotoPath = parameter;
        }
    }
}
