using EasyTransition;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    #region Vari�veis Globais
    [Header("Transi��o Jogar:")]
    [SerializeField] private TransitionSettings transitionSettings;
    [SerializeField] private float loadTime;
    #endregion

    #region Fun��es Pr�prias
    public void StartGame() => TransitionManager.Instance().Transition("GameScene", transitionSettings, loadTime);

    public void GoToOptions() => MainMenuManager.Instance.OpenMenu(Default.Options, MainMenuManager.MainMenu);

    public void GoToControls() => MainMenuManager.Instance.OpenMenu(Default.Controls, MainMenuManager.MainMenu);

    public void ExitGame() => Application.Quit();
    #endregion
}
