using UnityEngine;
using PathFinding;
using System.Collections.Generic;
using UnityEngine.Rendering;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _minimumDistanceToPlayer = 1F;

    private Transform _playerTransform;
    private Transform _transform;
    
    private PathFinder _pathFinder;
    private PathNode _lastPlayerPathNode;
    private Vector2 _lastPathPoint;

    private Rigidbody2D _rigibody;

    private List<Vector2> _path;

    private Vector2 _direction = Vector2.zero;
    
    private int _pathIndex = 0;
    
    private void Awake()
    {
        _pathFinder = FindObjectOfType<PathFinder>();
        _playerTransform = FindObjectOfType<PlayerMovement>().transform;
        _rigibody = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
    }

    private void Start()
    {
        MakeNewPath();
        
    }

    private void Update()
    {
        LookAt(_playerTransform.position);
        if(Vector2.Distance(_playerTransform.position, _transform.position) <= _minimumDistanceToPlayer )
        {
            _direction = Vector2.zero;
        }
        else if(_path.Count > 0)
        {
            SetDirection(_lastPathPoint);
        }
        PathNode playerNode = _pathFinder.GetNode(_playerTransform.position);
        if (_lastPlayerPathNode != playerNode)
        {
            _lastPlayerPathNode = playerNode;
            MakeNewPath();
        }


        if (_path.Count == 0 || _pathIndex == _path.Count) return;

        if (Vector2.Distance(_path[_pathIndex], _transform.position) < 0.25f)
        {
            _pathIndex++;
            if(_pathIndex != _path.Count)
            {
                _lastPathPoint = _path[_pathIndex];
                return;
            }
        }
    }
    private void FixedUpdate()
    {
        Move(_direction);
    }

    private void LookAt(Vector3 target)
    {
        Vector3 dir = target - _transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        _transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void MakeNewPath()
    {
        _path = _pathFinder.FindPath(_transform.position, _playerTransform.position);
        _pathIndex = 0;
        if(_path.Count == 0)
        {
            _direction = Vector2.zero;
            return;
        }
        _lastPathPoint = _path[0];
    }

    private void SetDirection(Vector2 to)
    {
        _direction = (to - (Vector2)_transform.position).normalized;
    }

    private void Move(Vector2 direct)
    {
        _rigibody.velocity = _speed * direct;
    }



}
