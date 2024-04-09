using EasyTransition;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWinMenu : MonoBehaviour
{
    #region Variáveis Globais
    [Header("Transição Jogar:")]
    [SerializeField] private TransitionSettings transitionSettings;
    [SerializeField] private float loadTime;

    private AudioManager _audioManager;
    #endregion

    #region Funções Unity
    private void Awake() => _audioManager = GameObject.FindObjectOfType<AudioManager>();
    #endregion

    #region Funções Próprias
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        TransitionManager.Instance().Transition("MainMenu", transitionSettings, loadTime);
    }

    public void PlaySFX() => _audioManager.PlaySFX("button");
    #endregion
}
