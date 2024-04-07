using EasyTransition;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerGameOver : MonoBehaviour
{
    #region Variáveis Globais
    [Header("Configurações:")] 
    
    [Header("Vida:")]
    [SerializeField] private int initialHealth;
    [SerializeField] private int obstacleDamage;
    [SerializeField] private int bossDamage;

    [Header("Invencibilidade:")] 
    [SerializeField] private float invencibilityInterval;

    [Header("Transição Restart:")]
    [SerializeField] private TransitionSettings transitionSettings;
    [SerializeField] private float loadTime;

    [Header("Referências:")] 
    [SerializeField] private CameraShake cameraShakeSript;

    // Referências:
    private CollisionLayersManager _collisionLayersManager;

    // Componentes:
    private BlinkSpriteVFX _blinkScript;

    // Vida:
    private int _curHealth;
    #endregion

    #region Funções Unity
    private void Start()
    {
        _collisionLayersManager = GameObject.FindObjectOfType<CollisionLayersManager>();
        _blinkScript = GetComponent<BlinkSpriteVFX>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == _collisionLayersManager.DeadEndTrigger.Index)
            Restart();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == _collisionLayersManager.Obstacle.Index)
        {
            ChangeHealthPoints(obstacleDamage);
            cameraShakeSript.ApplyScreenShake();
            StartCoroutine(SetInvencibilityInterval());
        }
        else if (col.gameObject.layer == _collisionLayersManager.Boss.Index)
        {
            ChangeHealthPoints(bossDamage);
            cameraShakeSript.ApplyScreenShake();
            StartCoroutine(SetInvencibilityInterval());
        }
    }
    #endregion

    #region Funções Próprias
    private void Restart() => TransitionManager.Instance().Transition(SceneManager.GetActiveScene().name, transitionSettings, loadTime);

    private void ChangeHealthPoints(int points)
    {
        _curHealth = Mathf.Clamp(_curHealth + points, 0, initialHealth);

        if (_curHealth == 0)
        {
            ScoreManager.Instance.CanCount = false;
            Restart();
        }
    }

    private IEnumerator SetInvencibilityInterval()
    {
        _blinkScript.SetBlink();
        Physics2D.IgnoreLayerCollision(_collisionLayersManager.Player.Index, _collisionLayersManager.Obstacle.Index, true);
        Physics2D.IgnoreLayerCollision(_collisionLayersManager.Player.Index, _collisionLayersManager.Boss.Index, true);
        
        yield return new WaitForSeconds(invencibilityInterval);

        Physics2D.IgnoreLayerCollision(_collisionLayersManager.Player.Index, _collisionLayersManager.Obstacle.Index, false);
        Physics2D.IgnoreLayerCollision(_collisionLayersManager.Player.Index, _collisionLayersManager.Boss.Index, false);
    }
    #endregion
}

