using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuManager : MonoBehaviour
{
    #region Vari�veis Globais
    // Inst�ncia da Classe
    public static GameMenuManager Instance;

    // Refer�ncia Canvas
    public static GameObject MenuCanvas;

    // Refer�ncias dos Menus que ser�o manipulados
    public static GameObject GameMenu, OptionsMenu, ControlsMenu;
    #endregion

    #region Fun��es Unity
    private void Awake()
    {
        Instance = this;
        Init();
    }
    #endregion

    #region Fun��es Pr�prias
    // Coletando os objetos necess�rios
    private void Init()
    { 
        MenuCanvas = GameObject.Find("GameMenu Canvas");
        GameMenu = MenuCanvas.transform.Find("GameMenu").gameObject;
        OptionsMenu = MenuCanvas.transform.Find("OptionsMenu").gameObject;
        ControlsMenu = MenuCanvas.transform.Find("ControlsMenu").gameObject;

        MenuCanvas.GetComponent<Canvas>().enabled = false;
    }

    // Abre o menu desejado e fecha o que foi utilizado anteriormente
    public void OpenMenu(InGame menu, GameObject callingMenu)
    {
        // Ativando o menu selecionado
        switch (menu)
        {
            case InGame.GameMenu:
                GameMenu.SetActive(true);
                break;

            case InGame.Options:
                OptionsMenu.SetActive(true);
                break;

            case InGame.Controls:
                ControlsMenu.SetActive(true);
                break;
        }

        // Desativando o anterior
        callingMenu.SetActive(false);
    }
    #endregion
}
