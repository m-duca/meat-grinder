using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    #region Variáveis Globais
    [Header("Configurações")] 
    
    [Header("Tempo para Retornar:")] 
    [SerializeField] private float minReturnTime;
    [SerializeField] private float maxReturnTime;

    [Header("Velocidades:")]
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float backwardSpeed;

    // Referências:
    private CollisionLayersManager _collisionLayersManager;
    private AudioManager _audioManager;

    // Componentes:
    private Rigidbody2D _rb;

    // Movimentação:
    private bool _isReturning = false;
    #endregion

    #region Funções Unity
    private void Start()
    {
        _collisionLayersManager = GameObject.FindObjectOfType<CollisionLayersManager>();
        _audioManager = GameObject.FindObjectOfType<AudioManager>();
        _rb = GetComponent<Rigidbody2D>();

        PlaySfxProjectile();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == _collisionLayersManager.FlipProjectileTrigger.Index && !_isReturning)
        {
            _isReturning = true;
            _rb.isKinematic = false;
            StartCoroutine(ReturnInterval());
            StartCoroutine(BossProjectileManager.Instance.SpawnNextProjectile());
        }
        else if (col.gameObject.layer == _collisionLayersManager.DeadEndTrigger.Index)
            Destroy(gameObject, 0.25f);
    }

    private void FixedUpdate() => ApplyHorizontalMovement();
    #endregion

    #region Funções Próprias
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
        PlaySfxProjectile();
    }

    private void PlaySfxProjectile() => _audioManager.PlaySFX("boss projectile");
    #endregion
}
