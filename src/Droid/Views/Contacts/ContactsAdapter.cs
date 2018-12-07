using System;
using System.Windows.Input;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using MvvmCross.Binding.Extensions;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Binding.BindingContext;

namespace Phonebook.Droid.Contacts
{
    public class ContactsAdapter : MvxRecyclerAdapter
    {
        private const int FOOTER_VIEW = -999;

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

        //public override int ItemCount => ItemsSource == null ? 0 : ItemsSource.Count() + 1;

        //public override int GetItemViewType(int position)
        //{
        //    return position == ItemsSource.Count()
        //        ? FOOTER_VIEW 
        //        : base.GetItemViewType(position);
        //}

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            if (viewType == FOOTER_VIEW)
            {
                var itemBindingContext = new MvxAndroidBindingContext(parent.Context, BindingContext.LayoutInflaterHolder);

                var vh = new MvxRecyclerViewHolder(itemBindingContext.BindingInflate(Resource.Layout.recycler_loading_footer, parent, false), itemBindingContext)
                {
                    Click = ItemClick,
                    LongClick = ItemLongClick,
                    Id = Resource.Layout.recycler_loading_footer
                };

                return vh;
            }
            return base.OnCreateViewHolder(parent, viewType);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (holder.ItemViewType == FOOTER_VIEW)
            {
                ((IMvxRecyclerViewHolder)holder).DataContext = BindingContext.DataContext;
            }
            else
            {
                base.OnBindViewHolder(holder, position);
            }

            CheckPositionForPagination(position);
        }
    }
}

