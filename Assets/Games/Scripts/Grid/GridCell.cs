using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GridSystem
{
    public class GridCell : MonoBehaviour
    {
        [SerializeField] private int x;
        [SerializeField] private int y;

        [SerializeField] public GridCell straightCell;
        [SerializeField] public GridCell leftCell;
        [SerializeField] public GridCell rightCell;

        public int XPos => x;
        public int YPos => y;
    }
}
