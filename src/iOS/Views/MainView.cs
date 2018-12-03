using System;

using UIKit;
using MvvmCross.Platforms.Ios.Views;
using Phonebook.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;

namespace Phonebook.iOS.Views
{
    [MvxRootPresentation(WrapInNavigationController = true)]
    public partial class MainView : MvxViewController<MainViewModel>
    {
        public MainView() : base("MainView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            var set = this.CreateBindingSet<MainView, MainViewModel>();
            set.Bind(Button).To(vm => vm.ButtonClickedCommand);
            set.Bind(Button).For("Title").To(vm => vm.Text);
            set.Apply();
        }
    }
}

