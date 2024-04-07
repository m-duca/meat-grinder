using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    #region Vari�veis Globais
    [Header("Configura��es")] 
    
    [Header("Tempo para Retornar:")] 
    [SerializeField] private float minReturnTime;
    [SerializeField] private float maxReturnTime;

    [Header("Velocidades:")]
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float backwardSpeed;

    // Refer�ncias:
    private CollisionLayersManager _collisionLayersManager;

    // Componentes:
    private Rigidbody2D _rb;

    // Movimenta��o:
    private bool _isReturning = false;
    #endregion

    #region Fun��es Unity
    private void Start()
    {
        _collisionLayersManager = GameObject.FindObjectOfType<CollisionLayersManager>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == _collisionLayersManager.FlipProjectileTrigger.Index && !_isReturning)
        {
            _isReturning = true;
            _rb.isKinematic = false;
            StartCoroutine(ReturnInterval());
        }
        else if (col.gameObject.layer == _collisionLayersManager.DeadEndTrigger.Index)
            Destroy(gameObject, 0.25f);
    }

    private void FixedUpdate() => ApplyHorizontalMovement();

    private void OnDestroy() => StartCoroutine(BossProjectileManager.Instance.SpawnNextProjectile());
    #endregion

    #region Fun��es Pr�prias
    private void ApplyHorizontalMovement()
    {
        if (!_isReturning) _rb.velocity = Vector2.right * forwardSpeed;
        else _rb.velocity = Vector2.left * backwardSpeed;
    }

    private IEnumerator ReturnInterval()
    {
        //TODO: Mostrar Indicador
        yield return new WaitForSeconds(Random.Range(minReturnTime, maxReturnTime));
        _rb.isKinematic = true;
    }
    #endregion
}
