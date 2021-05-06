using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicOption : MonoBehaviour
{
    [SerializeField] private AudioMixer _audio;
    [SerializeField] private Image _musicImage;
    [SerializeField] private Sprite _musicIsOn;
    [SerializeField] private Sprite _musicIsOff;


    private bool _isMusicPlay = true;
    

    public void ChangeMusicState()
    {
        if (_isMusicPlay)
        {
            TurnOffMusic();
        }
        else
        {
            TurnOnMusic();
        }
    }

    public void TurnOffMusic()
    {
        _audio.SetFloat("Music", -80);
        _isMusicPlay = false;
        _musicImage.sprite = _musicIsOff;
    }

    public void TurnOnMusic()
    {
        _audio.SetFloat("Music", 0);
        _isMusicPlay = true;

        _musicImage.sprite = _musicIsOn;
    }

}
