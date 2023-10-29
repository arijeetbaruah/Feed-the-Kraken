using Baruah.Service;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
}
