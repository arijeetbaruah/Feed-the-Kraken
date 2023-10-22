namespace Baruah.StateMachine
{
    public interface IStateMachine
    {
        IState CurrentState { get; }
        void Update();
        void ChangeState(IState state);
    }
}
