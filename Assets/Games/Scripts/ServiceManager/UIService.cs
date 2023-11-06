using System;

namespace Baruah.Service
{
    public class UIService : IService
    {
        public AppointmentNavigationTeamHUD appointmentNavigationTeamHUD;
        public CaptainAppointementHUD captainAppointementHUD;
        public RibbonHUD ribbonHUD;
        public MutanyHUD mutanyHUD;

        public Action OnNavigatorSelected;

        public void RegisterEvents()
        {
        }

        public void UnRegisterEvents()
        {
        }
    }
}
