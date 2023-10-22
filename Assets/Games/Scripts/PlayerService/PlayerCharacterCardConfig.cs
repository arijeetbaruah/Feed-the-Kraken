using Baruah.Config;
using Newtonsoft.Json;
using Sirenix.OdinInspector;
using System;
using System.Linq;
using UnityEngine;

public class PlayerCharacterCardConfig : BaseMultiConfig<PlayerCharacterCardConfigData, PlayerCharacterCardConfig>
{
    [Button]
    public void Refresh()
    {
        if (data == null)
        {
            data = new System.Collections.Generic.List<PlayerCharacterCardConfigData> ();
        }

        data.Clear();
        Type type = typeof(ICharacterCard);
        var characterCards = AppDomain.CurrentDomain.GetAssemblies().SelectMany(asm => asm.GetTypes())
            .Where(t => type.IsAssignableFrom(t) && type != t).ToList();

        foreach(var characterCardType in characterCards)
        {
            ICharacterCard characterCard = (ICharacterCard)Activator.CreateInstance(characterCardType);
            data.Add(new PlayerCharacterCardConfigData
            {
                id = characterCard.ID,
                type = JsonConvert.SerializeObject(characterCardType)
            });
        }
    }
}

[System.Serializable]
public class PlayerCharacterCardConfigData : IConfigData
{
    public string ID => id;

    public string id;
    [TextArea] public string description;
    [ReadOnly] public string type;
}
