using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    #region Variáveis Globais
    [Header("Configurações:")]

    [Header("Velocidade:")]
    [SerializeField] private float _moveSpeed;

    // Componentes
    private Rigidbody2D _rb;
    #endregion

    #region Funções Unity
    private void Start() => _rb = GetComponent<Rigidbody2D>();

    private void FixedUpdate() => ApplyHorizontalMove();
    #endregion

    #region Funções Próprias
    private void ApplyHorizontalMove() => _rb.velocity = Vector2.left * _moveSpeed;
    #endregion
}
