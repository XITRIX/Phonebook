using System;
namespace Phonebook.Core
{
    public interface IDialogService
    {
        void CreateOneButtonDialog(string title, string message, string button, Action buttonAction);
    }
}
