using EasyTransition;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWinMenu : MonoBehaviour
{
    #region Vari�veis Globais
    [Header("Transi��o Jogar:")]
    [SerializeField] private TransitionSettings transitionSettings;
    [SerializeField] private float loadTime;

    private AudioManager _audioManager;
    #endregion

    #region Fun��es Unity
    private void Awake() => _audioManager = GameObject.FindObjectOfType<AudioManager>();
    #endregion

    #region Fun��es Pr�prias
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        TransitionManager.Instance().Transition("MainMenu", transitionSettings, loadTime);
    }

    public void PlaySFX() => _audioManager.PlaySFX("button");
    #endregion
}
