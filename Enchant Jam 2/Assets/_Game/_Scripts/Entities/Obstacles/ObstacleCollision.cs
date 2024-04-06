using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    #region Variáveis Globais
    // Referências
    private CollisionLayersManager _collisionLayersManager;
    #endregion

    #region Funções Unity
    private void Start() => _collisionLayersManager = GameObject.FindObjectOfType<CollisionLayersManager>();

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == _collisionLayersManager.DeadEndTrigger.Index)
            Destroy(gameObject, 1f);
    }
    #endregion
}
