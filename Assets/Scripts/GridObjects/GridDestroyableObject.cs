using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathFinding;
public class GridDestroyableObject : MonoBehaviour
{
    [SerializeField] private Vector3Int[] _occupiedNeighbourCells;
    [SerializeField] private Health _healt;

    private PathFinder _pathFinder;
    private Transform _transform;

    private void Awake()
    {
        _pathFinder = FindObjectOfType<PathFinder>();
        _transform = GetComponent<Transform>();
    }

    private void Start()
    {
        _healt.Died += ReleaseCells;
    }

    private void ReleaseCells()
    {
        PathNode initialNode = _pathFinder.GetNode(_transform.position);
        initialNode.IsFree = true;
        Vector3Int initialCell = new Vector3Int(initialNode.X, initialNode.Y, 0);

        for(int  i = 0; i < _occupiedNeighbourCells.Length; i++)
        {
            _pathFinder.GetNode(new Vector3Int(
                _occupiedNeighbourCells[i].x + initialCell.x, _occupiedNeighbourCells[i].y + initialCell.y, 0
                )).IsFree = true;
        }
    }

}
