using Baruah.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Baruah
{
    public interface IPlayer
    {
        string ID { get; }
        ICharacterCard CharacterCard { get; }
    }

    public abstract class BasePlayer : IPlayer
    {
        public string ID => id;
        public string id;

        public ICharacterCard CharacterCard { get; private set; }

        public BasePlayer(ICharacterCard characterCard)
        {
            id = System.Guid.NewGuid().ToString();
            CharacterCard = characterCard;
        }
    }

    public class LocalPlayer : BasePlayer
    {
        public LocalPlayer(ICharacterCard characterCard) : base(characterCard)
        {
        }
    }

    public class PlayerService : IService
    {
        private Dictionary<string, IPlayer> playerDatabase = new Dictionary<string, IPlayer>();
        private PlayerCharacterCardConfig PlayerCharacterCardConfig => ServiceManager.Get<ConfigService>().Get<PlayerCharacterCardConfig>();

        public PlayerService()
        {
            var characterData1 = PlayerCharacterCardConfig.data[GetRandomCard()];
            Type type1 = JsonConvert.DeserializeObject<Type>(characterData1.type);
            ICharacterCard characterCard1 = (ICharacterCard) Activator.CreateInstance(type1);
            IPlayer player = new LocalPlayer(characterCard1);
            playerDatabase.Add(player.ID, player);

            var characterData2 = PlayerCharacterCardConfig.data[GetRandomCard()];
            Type type2 = JsonConvert.DeserializeObject<Type>(characterData2.type);
            ICharacterCard characterCard2 = (ICharacterCard)Activator.CreateInstance(type2);
            IPlayer player1 = new LocalPlayer(characterCard2);
            playerDatabase.Add(player1.ID, player1);

            var characterData3 = PlayerCharacterCardConfig.data[GetRandomCard()];
            Type type3 = JsonConvert.DeserializeObject<Type>(characterData3.type);
            ICharacterCard characterCard3 = (ICharacterCard)Activator.CreateInstance(type3);
            IPlayer player2 = new LocalPlayer(characterCard3);
            playerDatabase.Add(player2.ID, player2);
        }

        public IEnumerable<IPlayer> GetPlayers()
        {
            return playerDatabase.Values;
        }

        public IPlayer GetPlayer(string id)
        {
            return playerDatabase[id];
        }
        
        private int GetRandomCard()
        {
            int index = UnityEngine.Random.Range(0, PlayerCharacterCardConfig.data.Count);
            
            if(GetPlayers().Where(p => p.CharacterCard == PlayerCharacterCardConfig.data[index]) == null)
            {
                return GetRandomCard();
            }
            
            return index;
        }
    }
}
