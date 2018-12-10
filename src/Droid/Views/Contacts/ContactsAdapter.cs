using System;
using System.Windows.Input;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using MvvmCross.Binding.Extensions;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;

namespace Phonebook.Droid.Contacts
{
    public class ContactsAdapter : MvxRecyclerAdapter
    {
        protected int FooterViewType { get; } = Resource.Layout.recycler_loading_footer;

        public ICommand PagingCommand { get; set; }

        public bool IsLoading { get; set; }

        public ContactsAdapter()
        {
        }

        public ContactsAdapter(IMvxAndroidBindingContext bindingContext)
            : base(bindingContext)
        {
        }

        public ContactsAdapter(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        private void CheckPositionForPagination(int viewPosition)
        {
            if (viewPosition >= ItemCount - 5 && (PagingCommand?.CanExecute(null) ?? false))
                PagingCommand.Execute(null);
        }

        public override int ItemCount => ItemsSource?.Count() == 0 ? 0 : ItemsSource.Count() + 1;

        public override int GetItemViewType(int position)
        {
            return position == ItemsSource.Count()
                ? FooterViewType
                : base.GetItemViewType(position);
        }

        protected override View InflateViewForHolder(ViewGroup parent, int viewType, IMvxAndroidBindingContext bindingContext)
        {
            var layoutId = viewType == FooterViewType ? FooterViewType : ItemTemplateSelector.GetItemLayoutId(viewType);
            return bindingContext.BindingInflate(layoutId, parent, false);
        }

        public override object GetItem(int viewPosition)
        {
            CheckPositionForPagination(viewPosition);

            return base.GetItem(viewPosition);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (holder.ItemViewType == FooterViewType)
            {
                ((IMvxRecyclerViewHolder)holder).DataContext = BindingContext.DataContext;
            }
            else
            {
                base.OnBindViewHolder(holder, position);
            }
        }
    }
}

