using UnityEngine;

namespace GridSystem
{
    public enum Teams
    {
        PIRATES,
        CREW,
        CULT
    }

    public class GoalCell : MonoBehaviour, ICell
    {
        public Teams winner;
    }
}
