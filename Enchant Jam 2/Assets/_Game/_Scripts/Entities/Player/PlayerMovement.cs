using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variáveis Globais
    public Rigidbody2D rb;
    public Transform sprite;
    public float jumpForce = 10f;
    public LayerMask groundLayer;
    public Transform feetPosition;
    public float groundDistance = 0.2f;
    public float jumpTime = 0.3f;
    public Animator anim;
    public BoxCollider2D boxCollider;

    bool _isGrounded = false;
    bool _isJumping = false;
    float _jumpTimer;

    CollisionLayersManager _collisionLayersManager;
    #endregion

    #region Funções Unity
    private void Start()
    {
        _collisionLayersManager = GameObject.FindObjectOfType<CollisionLayersManager>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == _collisionLayersManager.DeadEndTrigger.Index)
            Destroy(gameObject, 1f);
    }

    private void Update()
    {
        _isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundDistance, groundLayer);

        #region JUMPING
        if (_isGrounded && Input.GetButtonDown("Jump")) //Se pressionar, pula mais alto
        {
            anim.SetTrigger("Jump");
            Invoke("ResetAnim", 0.55f);
            _isJumping = true;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (_isJumping && Input.GetButton("Jump")) //Se apertar uma vez, pula
        {
            if (_jumpTimer < jumpTime)
            {
                rb.velocity = Vector2.up * jumpForce;
                _jumpTimer += Time.deltaTime;
            }
            else
            {
                _isJumping = false;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            _isJumping = false;
            _jumpTimer = 0;
        }
        #endregion

        #region CROUCHING
        if (_isGrounded && Input.GetKey(KeyCode.LeftControl))
        {
            anim.Play("Sliding");
            boxCollider.offset = new Vector2(0f, -0.1271861f);
            boxCollider.size = new Vector2(1.666667f, 0.871702f);

            if (_isJumping)
            {
                boxCollider.offset = new Vector2(0f, 0.31f);
                boxCollider.size = new Vector2(1.666667f, 1.743404f);
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            anim.Play("Player Walk Animation");
            boxCollider.offset = new Vector2(0f, 0.31f);
            boxCollider.size = new Vector2(1.666667f, 1.743404f);
        }
        #endregion
    }

    private void ResetAnim() => anim.Play("Player Walk Animation");

    #endregion
}