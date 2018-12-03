using System;
using MvvmCross.Commands;
using MvvmCross.ViewModels;

namespace Phonebook.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private int count = 1;

        public IMvxCommand ButtonClickedCommand => new MvxCommand(ButtonClicked);

        private string _text = "Hello World, Click Me!";
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }

        public MainViewModel()
        {

        }

        private void ButtonClicked()
        {
            Text = $"{count++} clicks!";
        }
    }
}
