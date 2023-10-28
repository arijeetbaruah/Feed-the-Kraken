using System;

namespace Baruah.Service
{
    public class UIService : IService
    {
        public AppointmentNavigationTeamHUD appointmentNavigationTeamHUD;
        public CaptainAppointementHUD captainAppointementHUD;
        public RibbonHUD ribbonHUD;
        public Action OnNavigatorSelected;
    }
}
