using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundOption : MonoBehaviour
{
    [SerializeField] private AudioMixer _audio;
    [SerializeField] private Image _soundImage;
    [SerializeField] private Sprite _soundIsOn;
    [SerializeField] private Sprite _soundIsOff;


    private bool _isSoundPlay = true;
    

    public void ChangeMusicState()
    {
        if (_isSoundPlay)
        {
            TurnOffSound();
        }
        else
        {
            TurnOnSound();
        }
    }

    public void TurnOffSound()
    {
        _audio.SetFloat("Sound", -80);
        _isSoundPlay = false;
        _soundImage.sprite = _soundIsOff;
    }

    public void TurnOnSound()
    {
        _audio.SetFloat("Sound", 0);
        _isSoundPlay = true;

        _soundImage.sprite = _soundIsOn;
    }

}
