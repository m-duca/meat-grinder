using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSFX : MonoBehaviour
{
    private AudioManager _audioManager;

    private void Start()
    {
        _audioManager = GameObject.FindObjectOfType<AudioManager>();

        _audioManager.PlaySFX("boss_scream2");

        PlaySfxScream();
    }

    private void PlaySfxScream()
    {
        var target = "boss_scream" + Random.Range(1, 3).ToString();
        _audioManager.PlaySFX(target);

        Invoke("PlaySfxScream", Random.Range(8f, 18f));
    }

}
