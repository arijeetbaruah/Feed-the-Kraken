using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Baruah.StateMachine
{
    public class GameStateMachine : BaseStateMachine
    {
        public GameStateMachine()
        {
            ChangeState(new CaptainAppointmentPhase());
        }
    }
}
