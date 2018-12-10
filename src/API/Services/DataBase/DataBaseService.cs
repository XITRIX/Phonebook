using Realms;
using System.Threading.Tasks;

namespace Phonebook.API.Services.DataBase
{
    public class DataBaseService : IDataBaseService
    {
        public void Save(string key, string data)
        {
            var realm = Realm.GetInstance();
            using (var transaction = realm.BeginWrite())
            {
                var dbo = new DataBaseStringItemModel(key, data);
                realm.Add(dbo, true);
                transaction.Commit();
            }
        }

        public string LoadString(string key)
        {
            var dbo = Realm.GetInstance().Find<DataBaseStringItemModel>(key);
            return dbo.Data;
        }
    }
}
