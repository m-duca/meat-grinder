using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class FadeVolume : MonoBehaviour
{
    #region Vari�veis Globais
    private float _masterVolume;
    #endregion

    #region Fun��es Unity
    private void Start()
    {
        AudioListener.volume = 0f;
        _masterVolume = PlayerPrefs.GetFloat("masterVolume");
    }

    private void Update() => ApplyFade();
    #endregion

    #region Fun��es Pr�prias
    private void ApplyFade()
    {
        if (AudioListener.volume < _masterVolume)
        {
            AudioListener.volume += 0.25f * Time.deltaTime;
        }
        else
        {
            AudioListener.volume = _masterVolume;
            this.enabled = false;
        }
    }
    #endregion
}
