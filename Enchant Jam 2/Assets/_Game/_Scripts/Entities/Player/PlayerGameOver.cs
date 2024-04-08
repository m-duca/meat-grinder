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
    [SerializeField] private BlinkSpriteVFX blinkScript;
    [SerializeField] private Animator anim;
    [SerializeField] private PlayerMovement playerMovement;

    // Referências:
    private CollisionLayersManager _collisionLayersManager;

    // Vida:
    private int _curHealth;

    private bool _canRestart = true;
    #endregion

    #region Funções Unity
    private void Start()
    {
        _collisionLayersManager = GameObject.FindObjectOfType<CollisionLayersManager>();
        blinkScript = GetComponent<BlinkSpriteVFX>();
    }

    private void Update()
    {
        if (anim.speed == 0f)
            transform.position += Vector3.left * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == _collisionLayersManager.DeadEndTrigger.Index)
            ChangeHealthPoints(-obstacleDamage);
        
        if (col.gameObject.layer == _collisionLayersManager.Obstacle.Index)
        {
            ChangeHealthPoints(-obstacleDamage);
            cameraShakeSript.ApplyScreenShake();
            //StartCoroutine(SetInvencibilityInterval());
        }
        else if (col.gameObject.layer == _collisionLayersManager.Boss.Index)
        {
            ChangeHealthPoints(-bossDamage);
            cameraShakeSript.ApplyScreenShake();
            //StartCoroutine(SetInvencibilityInterval());
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == _collisionLayersManager.Obstacle.Index)
        {
            ChangeHealthPoints(-obstacleDamage);
            cameraShakeSript.ApplyScreenShake();
            //StartCoroutine(SetInvencibilityInterval());
        }
        else if (col.gameObject.layer == _collisionLayersManager.Boss.Index)
        {
            ChangeHealthPoints(-bossDamage);
            cameraShakeSript.ApplyScreenShake();
            //StartCoroutine(SetInvencibilityInterval());
        }
    }
    #endregion

    #region Funções Próprias
    private void Restart() => TransitionManager.Instance().Transition("GameScene", transitionSettings, loadTime);

    private void ChangeHealthPoints(int points)
    {
        _curHealth = Mathf.Clamp(_curHealth + points, 0, initialHealth);

        if (_curHealth == 0 && _canRestart)
        {
            _canRestart = false;
            playerMovement.enabled = false;
            anim.Play("Dead");
            anim.speed = 0f;
            ScoreManager.Instance.CanCount = false;
            Restart();
        }
    }

    private IEnumerator SetInvencibilityInterval()
    {
        blinkScript.SetBlink();
        Physics2D.IgnoreLayerCollision(_collisionLayersManager.Player.Index, _collisionLayersManager.Obstacle.Index, true);
        Physics2D.IgnoreLayerCollision(_collisionLayersManager.Player.Index, _collisionLayersManager.Boss.Index, true);
        
        yield return new WaitForSeconds(invencibilityInterval);

        Physics2D.IgnoreLayerCollision(_collisionLayersManager.Player.Index, _collisionLayersManager.Obstacle.Index, false);
        Physics2D.IgnoreLayerCollision(_collisionLayersManager.Player.Index, _collisionLayersManager.Boss.Index, false);
    }
    #endregion
}

