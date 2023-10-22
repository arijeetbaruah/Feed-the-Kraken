using Baruah.StateMachine;
using UnityEngine;

namespace Baruah
{
    public class GameScene : MonoBehaviour
    {
        IStateMachine stateMachine;

        private void Start()
        {
            stateMachine = new GameStateMachine();
        }
    }
}
