using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    #region Variables
    private bool _gamePaused;
    #endregion

    #region Unity
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_gamePaused)
                Pause();
            else
                Resume();
        }
    }
    #endregion

    #region Others
    private void Pause()
    {
        Time.timeScale = 0f;
        GameMenuManager.MenuCanvas.GetComponent<Canvas>().enabled = true;
        _gamePaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        GameMenuManager.MenuCanvas.GetComponent<Canvas>().enabled = false;
        _gamePaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void GoToOptions() => GameMenuManager.Instance.OpenMenu(InGame.Options, GameMenuManager.GameMenu);

    public void GoToControls() => GameMenuManager.Instance.OpenMenu(InGame.Controls, GameMenuManager.GameMenu);

    public void GoToMainMenu() => SceneManager.LoadScene("TestMainMenu");

    #endregion
}
