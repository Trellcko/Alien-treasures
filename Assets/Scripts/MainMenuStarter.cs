using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MainMenuStarter : MonoBehaviour
{
    [SerializeField] private SoundOption _sound;
    [SerializeField] private MusicOption _music;
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private AudioClip _mainThem;
    private void Awake()
    {
        Time.timeScale = 1;
        _audioMixer.GetFloat("Sound", out float soundValue);

        _audioMixer.GetFloat("Sound", out float musicValue);
        if(soundValue < 0)
        {
            _sound.TurnOffSound();
        }
        if(musicValue < 0)
        {
            _music.TurnOffMusic();
        }
    }
    private void Start()
    {
        AudioManager.Instance.PlayMusic(_mainThem);
    }
}
