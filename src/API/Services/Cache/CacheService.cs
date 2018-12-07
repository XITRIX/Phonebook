using System;
using System.Collections.Generic;
using System.Threading;
using Realms;
using System.Linq;
namespace Phonebook.API.Services.Cache
{
    public class CacheService
    {
        private Realm _realm;

        private void CacheItems<T>(T data) where T : RealmObject
        {
            _realm = Realm.GetInstance();
            _realm.Write(() =>
            {
                _realm.Add(data);
            });
        }

        private List<T> GetCachedItems<T>() where T : RealmObject
        {
            _realm = Realm.GetInstance();
            return _realm.All<T>().ToList();
        }

        //private void CacheItems(int page, MvxObservableCollection<ContactItemVm> data)
        //{
        //    new Thread(() =>
        //    {
        //        _realm = Realm.GetInstance();
        //        _realm.Write(() =>
        //        {
        //            _realm.Add(new UsersListCacheModel
        //            {
        //                SeriallizedContactItemsList = JsonConvert.SerializeObject(new List<ContactItemVm>(data)),
        //                Page = page
        //            }, true);
        //        });
        //    }).Start();
        //}

        //private MvxObservableCollection<ContactItemVm> GetCachedItems(int page)
        //{
        //    _realm = Realm.GetInstance();
        //    var cachedPage = (from d in _realm.All<UsersListCacheModel>() where d.Page == _page select d).First();
        //    if (cachedPage != null)
        //    {
        //        return new MvxObservableCollection<ContactItemVm>(JsonConvert.DeserializeObject<List<ContactItemVm>>(cachedPage.SeriallizedContactItemsList));
        //    }
        //    return null;
        //}
    }
}
