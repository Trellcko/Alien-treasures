using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CursorGraphic : MonoBehaviour
{
    public static CursorGraphic Instance { get; private set; }

    [SerializeField] private Texture2D _defaultTexture;
    [SerializeField] private Texture2D _interactTexture;

    private Camera _camera;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            _camera = Camera.main;
            _defaultTexture.filterMode = FilterMode.Point;
            SetDefaultCursor();
        }
        else if(FindObjectsOfType<CursorGraphic>().Length > 1)
        {
            Destroy(gameObject);
        }
    }

    public void SetDefaultCursor()
    {
        Cursor.SetCursor(_defaultTexture, new Vector2(10, 10), CursorMode.Auto);
    }

    public void SetInteractTexture()
    {
        Cursor.SetCursor(_interactTexture, new Vector2(10, 10), CursorMode.Auto);
    }

}
