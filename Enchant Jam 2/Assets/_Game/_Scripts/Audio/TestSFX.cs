using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSFX : MonoBehaviour
{
    #region Vari�veis Globais
    [SerializeField] private string name;

    private AudioManager _audioManager;
    #endregion

    #region Fun��es Unity
    private void Start() => _audioManager = GameObject.FindObjectOfType<AudioManager>();

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _audioManager.PlaySFX(name);
    }
    #endregion
}
