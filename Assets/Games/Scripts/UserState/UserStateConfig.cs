using Baruah.Config;
using Sirenix.OdinInspector;
using System;
using System.Linq;

namespace Baruah.UserState
{
    public class UserStateConfig : BaseMultiConfig<UserStateConfigData, UserStateConfig>
    {
        [Button]
        private void Generate()
        {
            AppDomain.CurrentDomain.GetAssemblies().SelectMany(asm => asm.GetTypes());
        }
    }

    [System.Serializable]
    public class UserStateConfigData : IConfigData
    {
        public string ID => id;
        [ReadOnly] public string id;
        [ReadOnly] public string type;
    }
}
