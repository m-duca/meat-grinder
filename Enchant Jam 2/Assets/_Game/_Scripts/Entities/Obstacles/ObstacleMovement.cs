using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    #region Vari�veis Globais
    [Header("Configura��es:")]

    [Header("Velocidade:")]
    [SerializeField] private float _moveSpeed;

    // Componentes
    private Rigidbody2D _rb;
    #endregion

    #region Fun��es Unity
    private void Start() => _rb = GetComponent<Rigidbody2D>();

    private void FixedUpdate() => ApplyHorizontalMove();
    #endregion

    #region Fun��es Pr�prias
    private void ApplyHorizontalMove() => _rb.velocity = Vector2.left * _moveSpeed;
    #endregion
}
