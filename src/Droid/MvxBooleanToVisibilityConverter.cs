using System;
using System.Globalization;
using MvvmCross.Converters;
using Android.Views;
namespace Phonebook.Droid
{
    public class MvxBooleanToVisibilityConverter : MvxValueConverter<bool, ViewStates>
    {
        protected override ViewStates Convert(bool value, Type targetType, object parameter, CultureInfo culture)
        {
            return value ? ViewStates.Visible : ViewStates.Gone;
        }
    }
}
