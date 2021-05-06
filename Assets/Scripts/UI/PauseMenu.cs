using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private GameObject _pauseUI;

    private bool _isPause = false;
    private void Start()
    {
        InputController.Instance.Input.UI.Pause.performed += ChangePauseState;
    }

    private void OnDestroy()
    {
        InputController.Instance.Input.UI.Pause.performed -= ChangePauseState;
    }

    private void ChangePauseState(InputAction.CallbackContext ctx)
    {
        if(GameState.GameEnd)
        {
            return;
        }
        if(_isPause)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Pause()
    {
        _isPause = true;
        _pauseUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        _isPause = false;
        
        Time.timeScale = 1;
        _pauseUI.SetActive(false);
    }
}
