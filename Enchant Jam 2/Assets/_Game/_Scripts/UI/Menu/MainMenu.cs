using EasyTransition;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
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
    public void StartGame()
    {
        _audioManager.PlayMusic("game");
        TransitionManager.Instance().Transition("GameScene", transitionSettings, loadTime);
    } 

    public void GoToOptions() => MainMenuManager.Instance.OpenMenu(Default.Options, MainMenuManager.MainMenu);

    public void GoToControls() => MainMenuManager.Instance.OpenMenu(Default.Controls, MainMenuManager.MainMenu);

    public void ExitGame() => Application.Quit();
    #endregion
}
