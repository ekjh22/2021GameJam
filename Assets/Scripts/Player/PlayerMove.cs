using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float ratcastValue;

    //이동 관련 변수
    [SerializeField] float jumpPower = 10f;

    //점프 방향 관련 변수
    [SerializeField] Vector2 jumpDirVector;
    [SerializeField] float jumpDirnumber;
    Vector2 mousePosition;

    //점프 시간 관련 변수
    [Range(0, 200)]
    public float jumpBoostTime;
    public float elapsedTime = 0f;
    public bool isJump = false;

    SpriteRenderer playerSpriteRenderer;
    Rigidbody2D playerRigidbody2D;
    Animator playerAnimator;
    CircleCollider2D playerCircleCollider2D;

    void Start()
    {
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        playerAnimator = GetComponent<Animator>();
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        playerCircleCollider2D = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        LandingJump();
        Jump();
    }

    void Move(Vector2 mousePosition)
    {
        if (transform.position.x > mousePosition.x)
        {
            playerSpriteRenderer.flipX = true;
        }
        else if (transform.position.x < mousePosition.x)
        {
            playerSpriteRenderer.flipX = false;
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && !playerAnimator.GetBool("isJump"))
        {
            isJump = true;
        }
        else if (Input.GetButtonUp("Jump") && !playerAnimator.GetBool("isJump"))
        {
            mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            jumpDirVector = (mousePosition - new Vector2(transform.position.x, transform.position.y));

            Move(mousePosition);

            playerRigidbody2D.AddForce(jumpDirVector.normalized * jumpPower * elapsedTime, ForceMode2D.Impulse);

            elapsedTime = 0f;
            isJump = false;
            playerAnimator.SetBool("isJump", true);
        }

        if (isJump)
        {
            elapsedTime += (Time.deltaTime) * (jumpBoostTime / 100);

            if (elapsedTime >= 1)
            {
                elapsedTime = 1;
            }
        }
    }

    void LandingJump()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(playerCircleCollider2D.bounds.center, playerCircleCollider2D.bounds.size, 0, Vector2.down, 0.01f, LayerMask.GetMask("Ground"));

        if (raycastHit2D.collider != null)
        {
            if (raycastHit2D.distance <= 0.01f && playerRigidbody2D.velocity.y <= 0)
            {
                playerAnimator.SetBool("isJump", false);
            }
        }
    }
}
