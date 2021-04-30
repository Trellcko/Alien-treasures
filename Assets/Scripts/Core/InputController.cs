using Core.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{

    public static InputController Instance { get; private set; }
    public MasterInput Input { get; private set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            Input = new MasterInput();
            Input.Enable();
            DontDestroyOnLoad(gameObject);
        }
        else if(FindObjectsOfType<InputController>().Length > 1)
        {
            Destroy(gameObject);
        }
    }

}
