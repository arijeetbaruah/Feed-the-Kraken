using Baruah.Service;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Baruah
{
    public class AIPlayer : BasePlayer
    {
        public AIPlayer(string name, ICharacterCard characterCard) : base(name, characterCard)
        {
        }

        public override void AppointmentNavigationTeam()
        {
            PlayerService playerService = ServiceManager.Get<PlayerService>();
            var players = playerService.GetPlayers().Where(player => player.ID != ID).ToList();
            
            int index = UnityEngine.Random.Range(0, players.Count - 1);
            players[index].Role = Role.VICE_CAPTAIN;
            IPlayer viceCaptain = players[index];
            players.RemoveAt(index);

            index = UnityEngine.Random.Range(0, players.Count - 1);
            IPlayer navigator = players[index];
            players[index].Role = Role.NAVIGATOR;

            ServiceManager.Get<UIService>().appointmentNavigationTeamHUD.gameObject.SetActive(true);
            ServiceManager.Get<UIService>().appointmentNavigationTeamHUD.ShowViceCaptainAndNavigator(viceCaptain, navigator);
        }
    }
}
