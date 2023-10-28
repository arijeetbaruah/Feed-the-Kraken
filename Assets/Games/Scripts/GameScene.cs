using Baruah.Service;
using Baruah.StateMachine;
using UnityEngine;

namespace Baruah
{
    public class GameScene : MonoBehaviour
    {
        private IStateMachine stateMachine;
        [SerializeField] private AppointmentNavigationTeamHUD appointmentNavigationTeamHUD;
        [SerializeField] private CaptainAppointementHUD captainAppointementHUD;
        [SerializeField] private RibbonHUD ribbonHUD;

        private void Start()
        {
            UIService uIService = new UIService();
            ServiceManager.Add(uIService);
            uIService.appointmentNavigationTeamHUD = appointmentNavigationTeamHUD;
            uIService.captainAppointementHUD = captainAppointementHUD;
            uIService.ribbonHUD = ribbonHUD;
            stateMachine = new GameStateMachine();
        }
    }
}
