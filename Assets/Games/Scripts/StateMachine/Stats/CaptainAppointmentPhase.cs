using Baruah.Service;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Baruah.StateMachine
{
    public class CaptainAppointmentPhase : IState
    {
        public void Initialize()
        {
            
        }

        public void OnEnter()
        {
            var players = ServiceManager.Get<PlayerService>().GetPlayers().ToList();
            var captain = players[Random.Range(0, players.Count)];
            Debug.Log("Appointment Phase");

            foreach (var player in players)
            {
                Debug.Log($"{player.ID} is {player.CharacterCard.ID}");
            }

            Debug.Log($"{captain.ID} is captain");
        }

        public void OnExit()
        {
            
        }

        public void OnUpdate(float deltaTime)
        {
            
        }
    }
}
