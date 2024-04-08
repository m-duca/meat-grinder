using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMainMenu : MonoBehaviour
{
    [Header("Configurações:")]

    [Header("Cores:")]
    [SerializeField] private Color defaultColor;
    [SerializeField] private Color secondColor;

    [Header("Modificador de transição:")] 
    [SerializeField] private float modifier;

    private void Update() => Camera.main.backgroundColor = Color.Lerp(defaultColor, secondColor, Mathf.PingPong(Time.time * modifier, 1));
}
