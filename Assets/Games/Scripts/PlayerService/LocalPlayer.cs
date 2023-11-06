using Baruah.Service;

namespace Baruah
{
    public class LocalPlayer : BasePlayer
    {
        public LocalPlayer(string name, ICharacterCard characterCard) : base(name, characterCard)
        {
        }

        public override void AppointmentNavigationTeam()
        {
            ServiceManager.Get<UIService>().appointmentNavigationTeamHUD.gameObject.SetActive(true);
        }

        public override void ShowMutany()
        {
            
        }
    }
}
