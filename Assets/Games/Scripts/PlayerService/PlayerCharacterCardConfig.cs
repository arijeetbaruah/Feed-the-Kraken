using Baruah.Config;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
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
            data = new System.Collections.Generic.List<PlayerCharacterCardConfigData>();
        }

        Type type = typeof(ICharacterCard);
        var characterCards = AppDomain.CurrentDomain.GetAssemblies().SelectMany(asm => asm.GetTypes())
            .Where(t => type.IsAssignableFrom(t) && type != t).ToList();

        foreach (var characterCardType in characterCards)
        {
            ICharacterCard characterCard = (ICharacterCard)Activator.CreateInstance(characterCardType);

            var characterData = data.Where(d => d.ID == characterCard.ID).FirstOrDefault();
            if (characterData != null)
            {
                characterData.type = characterCard;
                continue;
            }

            data.Add(new PlayerCharacterCardConfigData
            {
                id = characterCard.ID,
                type = characterCard
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
    [SerializeReference, OdinSerialize] public ICharacterCard type;
}
