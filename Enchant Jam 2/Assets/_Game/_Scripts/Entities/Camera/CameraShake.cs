using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    #region Vari�veis Globais
    [Header("Configura��es:")]

    [SerializeField] private float animationSpeed;

    private Animator _camAnim;
    #endregion

    #region Fun��es Unity
    private void Awake()
    {
        _camAnim = gameObject.GetComponent<Animator>();
    }

    private void Start()
    {
        _camAnim.speed = animationSpeed;
    }
    #endregion

    #region Fun��es Pr�prias
    public void ApplyScreenShake()
    {
        _camAnim.SetTrigger("shake");
        _camAnim.SetInteger("random", Random.Range(1, 3));
    }
    #endregion
}
