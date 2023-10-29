using Baruah.Service;
using DG.Tweening;
using System.Linq;
using UnityEngine;

namespace Baruah.StateMachine
{
    public class AppointmentNavigationTeamState : BaseState
    {
        public AppointmentNavigationTeamState(IStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void OnEnter()
        {
            IPlayer player = ServiceManager.Get<PlayerService>().GetPlayers().Where(player => player.Role == Role.CAPTAIN).FirstOrDefault();
            player.AppointmentNavigationTeam();
            ServiceManager.Get<UIService>().OnNavigatorSelected += OnNavigatorSelected;
        }

        public override void OnExit()
        {
            ServiceManager.Get<UIService>().OnNavigatorSelected -= OnNavigatorSelected;
        }

        public override void OnUpdate(float deltaTime)
        {
            
        }

        private void OnNavigatorSelected()
        {
            Debug.Log("Navigation Selected");

            DOVirtual.DelayedCall(2, () =>
            {
                ServiceManager.Get<UIService>().appointmentNavigationTeamHUD.gameObject.SetActive(false);
                stateMachine.ChangeState(new MutinyState(stateMachine));
            });
        }
    }
}
