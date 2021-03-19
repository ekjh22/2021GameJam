using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //이동 관련 변수
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpPower = 10f;

    //점프 방향 관련 변수
    [SerializeField] Vector2 jumpDirVector = new Vector2(0.75f, 0.25f);
    [SerializeField] float jumpDirnumber;

    float playerHorizontal;

    public float elapsedTime = 0f;
    public bool isJump = false;

    Vector3 mousePosition;

    SpriteRenderer playerSpriteRenderer;
    PlayerController playerController;
    Transform playerTransform;
    Rigidbody2D playerRigidbody2D;
    Animator playerAnimator;

    void Start()
    {
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        playerTransform = GetComponent<Transform>();
        playerAnimator = GetComponent<Animator>();
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
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
        if (Input.GetButtonDown("Jump"))
        {
            isJump = true;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            // 사용자 input에 따른 대각선 방향 계산
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            jumpDirVector = (mousePosition - transform.position).normalized;

            Move(mousePosition);

            Vector2 dirVector2 = jumpDirVector;
            //Vector2 dirVector2 = new Vector2(jumpDirVector.x * jumpDirnumber, jumpDirVector.y);

            playerRigidbody2D.AddForce(dirVector2 * jumpPower * elapsedTime, ForceMode2D.Impulse);
            Debug.Log("점프: " + dirVector2 + " : " + jumpDirnumber);

            elapsedTime = 0f;
            isJump = false;
        }

        if (isJump)
        {
            elapsedTime += Time.deltaTime;
        }
    }

    void LandingJump()
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(playerRigidbody2D.position, Vector2.down, 1, LayerMask.GetMask("Ground"));
        Debug.DrawRay(playerRigidbody2D.position, Vector2.down * 1.0f, Color.red);
        
        if (raycastHit2D.collider != null)
        {
            if (raycastHit2D.distance <= 0.5f)
            {
                //playerAnimator.SetBool("애니메이션 이름");
                Debug.Log("땅에 착지");
            }
        }
    }
}
