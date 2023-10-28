using Baruah.Service;
using System.Collections.Generic;
using System.Linq;

namespace Baruah
{
    public enum Role
    {
        NONE,
        CAPTAIN,
        VICE_CAPTAIN,
        NAVIGATOR
    }

    public interface IPlayer
    {
        string ID { get; }
        string Name { get; }
        ICharacterCard CharacterCard { get; }

        Role Role { get; set; }
        int TotalGuns { get; set; }
    }

    public abstract class BasePlayer : IPlayer
    {
        public string ID => id;
        public string id;
        public string Name => name;
        public string name;

        public ICharacterCard CharacterCard { get; private set; }
        public int TotalGuns { get; set; }

        public Role Role { get; set; }

        public BasePlayer(string name, ICharacterCard characterCard)
        {
            id = System.Guid.NewGuid().ToString();
            this.name = name;
            CharacterCard = characterCard;
        }
    }

    public class LocalPlayer : BasePlayer
    {
        public LocalPlayer(string name, ICharacterCard characterCard) : base(name, characterCard)
        {
        }
    }

    public class AIPlayer : BasePlayer
    {
        public AIPlayer(string name, ICharacterCard characterCard) : base(name, characterCard)
        {
        }
    }

    public class PlayerService : IService
    {
        private Dictionary<string, IPlayer> playerDatabase = new Dictionary<string, IPlayer>();
        private PlayerCharacterCardConfig PlayerCharacterCardConfig => ServiceManager.Get<ConfigService>().Get<PlayerCharacterCardConfig>();

        public string CurrentPlayerID { get; set; }
        public IPlayer CurrentPlayer => playerDatabase[CurrentPlayerID];

        public PlayerService()
        {
            var characterData1 = PlayerCharacterCardConfig.data[GetRandomCard()];
            IPlayer player = new LocalPlayer("Player 1", characterData1.type);
            playerDatabase.Add(player.ID, player);

            var characterData2 = PlayerCharacterCardConfig.data[GetRandomCard()];
            IPlayer player1 = new AIPlayer("Player 2", characterData2.type);
            playerDatabase.Add(player1.ID, player1);

            var characterData3 = PlayerCharacterCardConfig.data[GetRandomCard()];
            IPlayer player2 = new AIPlayer("Player 3", characterData3.type);
            playerDatabase.Add(player2.ID, player2);

            var characterData4 = PlayerCharacterCardConfig.data[GetRandomCard()];
            IPlayer player3 = new AIPlayer("Player 4", characterData4.type);
            playerDatabase.Add(player3.ID, player3);


            var characterData5 = PlayerCharacterCardConfig.data[GetRandomCard()];
            IPlayer player4 = new AIPlayer("Player 5", characterData5.type);
            playerDatabase.Add(player4.ID, player4);
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

            if (GetPlayers().Where(p => p.CharacterCard == PlayerCharacterCardConfig.data[index]) == null)
            {
                return GetRandomCard();
            }

            return index;
        }
    }
}
