using System;
using MvvmCross.ViewModels;
namespace Phonebook.Core.ViewModels.ContactPhoto
{
    public class ContactPhotoViewModel : MvxViewModel<string>
    {
        public string Photo { get; set; }

        public override void Prepare(string parameter)
        {
            Photo = parameter;
        }
    }
}
