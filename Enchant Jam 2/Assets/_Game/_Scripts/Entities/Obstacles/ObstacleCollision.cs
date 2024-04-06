using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    #region Vari�veis Globais
    // Refer�ncias
    private CollisionLayersManager _collisionLayersManager;
    #endregion

    #region Fun��es Unity
    private void Start() => _collisionLayersManager = GameObject.FindObjectOfType<CollisionLayersManager>();

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == _collisionLayersManager.DeadEndTrigger.Index)
            Destroy(gameObject, 1f);
    }
    #endregion
}
