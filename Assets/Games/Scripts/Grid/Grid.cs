using System.Linq;
using UnityEngine;

namespace GridSystem
{
    public class Grid : MonoBehaviour
    {
        [SerializeField] private GridCell[] gridCells;

        public GridCell GetCell(Vector2Int position)
        {
            return gridCells.ToList().Find(cell => cell.XPos == position.x && cell.YPos == position.y);
        }
    }
}
