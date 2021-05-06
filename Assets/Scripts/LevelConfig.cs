using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelConfig : MonoBehaviour
{
    [SerializeField] private AudioClip _levelMusic;

    public void Start()
    {
        AudioManager.Instance.PlayMusic(_levelMusic);
    }
}
