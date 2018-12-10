using System;

namespace Phonebook.Core.Services
{
    public interface IDialogService
    {
        void CreateOneButtonDialog(string title, string message, string button, Action buttonAction);
        void CreateOneButtonCancelingDialog(string title, string message, string cancel, string button, Action buttonAction);
    }
}
