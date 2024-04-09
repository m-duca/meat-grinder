using EasyTransition;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameWin : MonoBehaviour
{
    [Header("Configurações:")]

    [Header("Transição:")]
    [SerializeField] private TransitionSettings transitionSettings;
    [SerializeField] private float loadTime;

    // Referências:
    private CollisionLayersManager _collisionLayersManager;

    private void Awake() => _collisionLayersManager = GameObject.FindObjectOfType<CollisionLayersManager>();

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == _collisionLayersManager.WinTrigger.Index)
            WinGame();
    }

    private void WinGame()
    {
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<BoxCollider2D>().enabled = false;
        TransitionManager.Instance().Transition("GameWin", transitionSettings, loadTime);
    }
}
