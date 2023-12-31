using DG.Tweening;
using GridSystem;
using System;
using UnityEngine;

namespace Baruah
{
    public class MoveActionAttribute : Attribute
    {
    }

    public class Ship : MonoBehaviour
    {
        [SerializeField] private GridSystem.Grid grid;
        [SerializeField] private Vector2Int location;

        private bool moving = false;

        [MoveAction]
        public void MoveLeft()
        {
            moving = true;

            GridCell cell = grid.GetCell(location);
            Vector3 targetPos = cell.leftCell.transform.position;
            location = new Vector2Int(cell.leftCell.XPos, cell.leftCell.YPos);

            transform.DOMove(targetPos, 2).OnComplete(() =>
            {
                moving = false;
                NavigationCardSelector.Instance.GenerateCards();
            });
        }

        [MoveAction]
        public void MoveForward()
        {
            moving = true;

            GridCell cell = grid.GetCell(location);
            Vector3 targetPos = cell.straightCell.transform.position;
            location = new Vector2Int(cell.straightCell.XPos, cell.straightCell.YPos);

            transform.DOMove(targetPos, 2).OnComplete(() =>
            {
                moving = false;
                NavigationCardSelector.Instance.GenerateCards();
            });
        }

        [MoveAction]
        public void MoveRight()
        {
            moving = true;

            GridCell cell = grid.GetCell(location);
            Vector3 targetPos = cell.rightCell.transform.position;
            location = new Vector2Int(cell.rightCell.XPos, cell.rightCell.YPos);

            transform.DOMove(targetPos, 2).OnComplete(() =>
            {
                moving = false;
                NavigationCardSelector.Instance.GenerateCards();
            });
        }
    }
}
