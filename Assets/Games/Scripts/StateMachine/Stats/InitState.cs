using Baruah.Service;
using System.Linq;
using UnityEngine;

namespace Baruah.StateMachine
{
    public class InitState : BaseState
    {
        public InitState(IStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void OnEnter()
        {
            var players = ServiceManager.Get<PlayerService>().GetPlayers().ToList();
            Debug.Log("Appointment Phase");

            foreach (var player in players)
            {
                Debug.Log($"{player.ID} is {player.CharacterCard.ID}");
            }

            stateMachine.ChangeState(new CaptainAppointmentPhase(stateMachine));
        }

        public override void OnExit()
        {

        }

        public override void OnUpdate(float deltaTime)
        {

        }
    }
}
