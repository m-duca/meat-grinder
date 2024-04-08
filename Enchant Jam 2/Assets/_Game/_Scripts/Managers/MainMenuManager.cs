using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    #region Variables
    public static MainMenuManager Instance;

    public static GameObject MainMenu, OptionsMenu, ControlsMenu;

    // Referências
    private AudioManager _audioManager;
    #endregion

    #region Unity
    private void Awake()
    {
        Instance = this;
        Init();
    }

    private void Start() => _audioManager = GameObject.FindObjectOfType<AudioManager>();

    public void PlaySFX() => _audioManager.PlaySFX("button");
    #endregion

    #region Other
    private void Init()
    {
        var menuCanvas = GameObject.Find("MainMenu Canvas");
        MainMenu = menuCanvas.transform.Find("MainMenu").gameObject;
        OptionsMenu = menuCanvas.transform.Find("OptionsMenu").gameObject;
        ControlsMenu = menuCanvas.transform.Find("ControlsMenu").gameObject;
    }

    public void OpenMenu(Default menu, GameObject callingMenu)
    {
        switch (menu)
        {
            case Default.MainMenu:
                MainMenu.SetActive(true);
                break;

            case Default.Options:
                OptionsMenu.SetActive(true);
                break;

            case Default.Controls:
                ControlsMenu.SetActive(true);
                break;
        }

        callingMenu.SetActive(false);
    }
    #endregion
}
