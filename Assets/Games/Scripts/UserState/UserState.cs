using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.CloudSave;
using Unity.Services.CloudSave.Models;

namespace Baruah.Service
{
    public class UserStateService : IService
    {
        public async Task<Dictionary<string, string>> Save(IDictionary<string, object> data)
        {
            return await CloudSaveService.Instance.Data.Player.SaveAsync(data);
        }

        public async Task<Dictionary<string, Item>> Load(HashSet<string> key)
        {
            return await CloudSaveService.Instance.Data.Player.LoadAsync(key);
        }

        public async Task<Dictionary<string, Item>> LoadAll()
        {
            return await CloudSaveService.Instance.Data.Player.LoadAllAsync();
        }
    }
}
