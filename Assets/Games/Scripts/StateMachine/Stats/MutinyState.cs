using Baruah.Service;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Baruah.StateMachine
{
    public class MutinyState : BaseState
    {
        public MutinyState(IStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void OnEnter()
        {
            ServiceManager.Get<UIService>().ribbonHUD.SetText("Mutany Phase");
            DOVirtual.DelayedCall(2, () =>
            {
                ServiceManager.Get<UIService>().ribbonHUD.gameObject.SetActive(false);
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
