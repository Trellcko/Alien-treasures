using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    [SerializeField] private int _index = 0;

    public void Change()
    {
        if(_index == -1)
        {
            Application.Quit();
        }
        SceneManager.LoadScene(_index);
    }

}
