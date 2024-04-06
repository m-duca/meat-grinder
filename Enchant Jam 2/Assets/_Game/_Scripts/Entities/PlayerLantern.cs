using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerLantern : MonoBehaviour
{
    #region Variáveis Globais
    [Header("Configurações:")]

    [Header("Alterar Iluminação:")]
    [SerializeField] private float lightDecrement;
    [SerializeField] private float lightIncrement;

    [Header("Referências:")]
    [SerializeField] private Light2D light;

    // Referências
    private CollisionLayersManager _collisionLayersManager;

    private float _initialLightRadius;
    #endregion

    #region Funções Unity
    private void Start()
    {
        _collisionLayersManager = GameObject.FindObjectOfType<CollisionLayersManager>();
        _initialLightRadius = light.pointLightOuterRadius;
    }

    private void Update() => DecreaseLight();

    private void OnTriggerEnter2D(Collider2D col)
    {
        //if (col.gameObject.layer == _collisionLayersManager.LampOil.Index)
            IncreaseLight();
    }
    #endregion

    #region Funções Próprias
    private void DecreaseLight() => light.pointLightOuterRadius -= lightDecrement * Time.deltaTime;

    private void IncreaseLight()
    {
        if (light.pointLightOuterRadius < _initialLightRadius)
            light.pointLightOuterRadius += lightIncrement;
        else
            light.pointLightOuterRadius = _initialLightRadius;
    }
    #endregion
}
