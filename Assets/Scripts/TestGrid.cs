using UnityEngine;
using UnityEngine.InputSystem;

public class TestGrid : MonoBehaviour
{
    PathFinding.PathFinder finder;


    private void Start()
    {
        finder = FindObjectOfType<PathFinding.PathFinder>();
        InputController.Instance.Input.Player.Attacking.performed += ctn => { Debug.Log(finder.GetNode(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue())).IsFree); };        
        Debug.Log(finder.GetWorldPosition(new Vector3Int(0, -3, 0)));
    }


}
