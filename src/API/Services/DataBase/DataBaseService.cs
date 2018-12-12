using Realms;
using System.Threading.Tasks;
using System.Threading;

namespace Phonebook.API.Services.DataBase
{
    public class DataBaseService : IDataBaseService
    {
        public Task Save(string key, string data)
        {
            return Task.Run(() =>
            {
                var realm = Realm.GetInstance();
                using (var transaction = realm.BeginWrite())
                {
                    var dbo = new DataBaseStringItemModel(key, data);
                    realm.Add(dbo, true);
                    transaction.Commit();
                }
            });
        }

        public Task<string> LoadString(string key)
        {
            return Task.Run(() =>
            {
                var dbo = Realm.GetInstance()
                               .Find<DataBaseStringItemModel>(key);

                return dbo?.Data;
            });
        }

        public Task ClearAll() {
            return Task.Run(() =>
            {
                var realm = Realm.GetInstance();
                using (var transaction = realm.BeginWrite())
                {
                    realm.RemoveAll<DataBaseStringItemModel>();
                    transaction.Commit();
                }
            });
        }
    }
}
