using EasyTransition;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerGameOver : MonoBehaviour
{
    #region Vari�veis Globais
    [Header("Configura��es:")] 
    
    [Header("Vida:")]
    private int initialHealth;
    private int obstacleDamage;
    private int bossDamage;

    [Header("Transi��o Restart:")]
    [SerializeField] private TransitionSettings transitionSettings;
    [SerializeField] private float loadTime;

    [Header("Refer�ncias:")] 
    [SerializeField] private CameraShake cameraShakeSript;

    // Refer�ncias:
    private CollisionLayersManager _collisionLayersManager;

    // Vida:
    private int _curHealth;
    #endregion

    #region Fun��es Unity
    private void Start() => _collisionLayersManager = GameObject.FindObjectOfType<CollisionLayersManager>();

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
        }
        else if (col.gameObject.layer == _collisionLayersManager.Boss.Index)
        {
            ChangeHealthPoints(bossDamage);
            cameraShakeSript.ApplyScreenShake();
        }
    }
    #endregion

    #region Fun��es Pr�prias
    private void Restart() => TransitionManager.Instance().Transition(SceneManager.GetActiveScene().name, transitionSettings, loadTime);

    private void ChangeHealthPoints(int points)
    {
        _curHealth = Mathf.Clamp(_curHealth + points, 0, initialHealth);

        if (_curHealth == 0)
        {
            GameObject.FindObjectOfType<ScoreManager>()._canCount = false;
            Restart();
        }
    }
    #endregion
}
