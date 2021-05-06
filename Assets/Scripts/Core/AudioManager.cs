using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource[] _soundSource;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if( FindObjectsOfType<AudioManager>().Length > 1)
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(AudioClip audioClip)
    {
        if(_musicSource.isPlaying)
        {
            _musicSource.Stop();
        }
        _musicSource.clip = audioClip; 
        _musicSource.Play();
    }

    public void PlaySound(AudioClip audioClip)
    {
        for (int i = 0; i < _soundSource.Length; i++)
        {
            if (_soundSource[i].isPlaying) continue;

            _soundSource[i].clip = audioClip;
            _soundSource[i].Play();
            return;
        }
    }

}
