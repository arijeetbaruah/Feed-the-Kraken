using UnityEngine;

namespace Baruah.StateMachine
{
    public abstract class BaseStateMachine : IStateMachine
    {
        public IState CurrentState { get; private set; } = null;

        public virtual void ChangeState(IState state)
        {
            CurrentState?.OnExit();
            CurrentState = state;
            CurrentState?.OnEnter();
        }

        public virtual void Update()
        {
            CurrentState?.OnUpdate(Time.deltaTime);
        }
    }
}
