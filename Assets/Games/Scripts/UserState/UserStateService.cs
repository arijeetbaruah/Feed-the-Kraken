using Baruah.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditorInternal;

namespace Baruah.UserState
{
    public interface IUserState
    {
    }

    public class UserStateService : IService
    {
        private string path;
        private Dictionary<string, IUserState> userStates;

        public UserStateService(string path)
        {
            this.path = path;
            LoadFile();
        }

        private void SaveFile()
        {
            FileStream fs = File.Open(path, FileMode.OpenOrCreate);
            byte[] data = Convert.FromBase64String(JsonConvert.SerializeObject(userStates));
        }

        private void LoadFile()
        {
            FileStream fs = File.Open(path, FileMode.OpenOrCreate);
            BinaryReader binaryReader = new BinaryReader(fs);
            byte[] bin = binaryReader.ReadBytes(Convert.ToInt32(fs.Length));
            string data = Convert.ToBase64String(bin);

            userStates = JsonConvert.DeserializeObject<Dictionary<string, IUserState>>(data);
            if (userStates == null)
            {
                userStates = new Dictionary<string, IUserState>();
            }
        }
    }
}
