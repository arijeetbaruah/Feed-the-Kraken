using Baruah.Service;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Baruah.StateMachine
{
    public class MutinyState : BaseState
    {
        private float timer = 5;
        private bool startTimer = false;
        private MutanyHUD mutanyHUD;

        public MutinyState(IStateMachine stateMachine) : base(stateMachine)
        {
            mutanyHUD = ServiceManager.Get<UIService>().mutanyHUD;
        }

        public override void OnEnter()
        {
            ServiceManager.Get<UIService>().ribbonHUD.SetText("Mutany Phase");
            DOVirtual.DelayedCall(2, () =>
            {
                UIService UIservice = ServiceManager.Get<UIService>();
                UIservice.ribbonHUD.gameObject.SetActive(false);
                UIservice.mutanyHUD.gameObject.SetActive(true);
                timer = 10;
                startTimer = true;
                //UIservice.mutanyHUD.
            });
        }

        public override void OnExit()
        {
        }

        public override void OnUpdate(float deltaTime)
        {
            if (startTimer && timer > 0)
            {
                timer -= deltaTime;
                mutanyHUD.SetTimerTxt(Mathf.RoundToInt(timer));
            }
        }
    }
}
