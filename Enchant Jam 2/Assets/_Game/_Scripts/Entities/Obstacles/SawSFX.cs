using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawSFX : MonoBehaviour
{
    private static AudioManager _audioManager;

    private void Start()
    {
        if (_audioManager == null)
            _audioManager = GameObject.FindObjectOfType<AudioManager>();

        PlaySfxSaw();
    }

    private void PlaySfxSaw() => _audioManager.PlaySFX("obstacle");
}
