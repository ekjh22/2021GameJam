using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public Slider playerSlider;
    public GameObject gameObject;

    //이동 관련 변수
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpPower = 10f;

    //점프 방향 관련 변수
    [SerializeField] Vector2 jumpDirVector;
    [SerializeField] float jumpDirnumber;
    Vector2 mousePosition;

    //점프 시간 관련 변수
    [Range(1, 2)]
    public float jumpBoostTime;
    public float elapsedTime = 0f;
    public bool isJump = false;


    SpriteRenderer playerSpriteRenderer;
    Rigidbody2D playerRigidbody2D;
    Animator playerAnimator;

    void Start()
    {
        playerSlider.value = 0;
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        playerAnimator = GetComponent<Animator>();
        playerRigidbody2D = GetComponent<Rigidbody2D>();
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
        if (Input.GetButtonDown("Jump") /*&& playerAnimator.GetBool("ddd")*/)
        {
            isJump = true;
        }
        else if (Input.GetButtonUp("Jump") /*&& playerAnimator.GetBool("ddd")*/)
        {
            // 사용자 input에 따른 대각선 방향 계산
            mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            jumpDirVector = (mousePosition - new Vector2(transform.position.x, transform.position.y));

            Move(mousePosition);

            playerRigidbody2D.AddForce(jumpDirVector.normalized * jumpPower * elapsedTime, ForceMode2D.Impulse);

            playerSlider.value = 0;
            elapsedTime = 0f;
            isJump = false;
        }

        if (isJump)
        {
            elapsedTime += (Time.deltaTime);

            if(elapsedTime >= 1)
            {
                elapsedTime = 1;
            }
            FillSlider(elapsedTime);
        } 
    }

    void FillSlider(float elapsedTime)
    {
        playerSlider.value = elapsedTime * 100;
        Debug.Log(elapsedTime * 100);
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
            }
        }
    }
}
