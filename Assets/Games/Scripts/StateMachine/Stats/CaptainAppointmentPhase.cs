using Baruah.Service;
using DG.Tweening;
using System.Linq;
using UnityEngine;

namespace Baruah.StateMachine
{
    public class CaptainAppointmentPhase : BaseState
    {
        public CaptainAppointmentPhase(IStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void OnEnter()
        {
            var players = ServiceManager.Get<PlayerService>().GetPlayers().ToList();
            var captain = players[Random.Range(0, players.Count)];
            captain.Role = Role.CAPTAIN;

            ServiceManager.Get<UIService>().captainAppointementHUD.gameObject.SetActive(true);
            ServiceManager.Get<UIService>().captainAppointementHUD.ShowCaptain(captain);
            DOVirtual.DelayedCall(2, () =>
            {
                ServiceManager.Get<UIService>().captainAppointementHUD.gameObject.SetActive(false);
                stateMachine.ChangeState(new AppointmentNavigationTeamState(stateMachine));
            });
        }

        public override void OnExit()
        {
        }

        public override void OnUpdate(float deltaTime)
        {

        }
    }
}
