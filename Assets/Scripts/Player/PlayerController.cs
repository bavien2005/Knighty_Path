using System;
using UnityEngine;
public class PlayerController : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 20f;

    [SerializeField] private float jumSpeed = 15f;


    [SerializeField] private bool isGround = true;


    private Animator animator;


    private Rigidbody2D rb;

    private AudioManager audioManager;

    private MobileInput mobileInput;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        audioManager = FindAnyObjectByType<AudioManager>();
        mobileInput = FindAnyObjectByType<MobileInput>();
    }

    void Update()
    {
        HandelJum();
        UpdateAnimation();
    }

    private void FixedUpdate()
    {
        HandelMovement();
    }

    //private void HandelMovement()
    //{
    //    var moveInput = Input.GetAxis("Horizontal");
    //    rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

    //    if (moveInput > 0) transform.localScale = new Vector3(1, 1, 1);

    //    if (moveInput < 0) transform.localScale = new Vector3(-1, 1, 1);

    //}

    //private void HandelJum()
    //{

    //    if (Input.GetKeyDown(KeyCode.Space) && isGround)
    //    {
    //        audioManager.PlayJumpSound();
    //        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumSpeed);
    //        isGround = false;
    //    }

    //}

    private void HandelMovement()
    {
        float moveInput = MobileInput.horizontal != 0 ? MobileInput.horizontal : Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        if (moveInput > 0) transform.localScale = new Vector3(1, 1, 1);
        if (moveInput < 0) transform.localScale = new Vector3(-1, 1, 1);
    }

    private void HandelJum()
    {
        if (isGround)
        {
            if(MobileInput.jump || Input.GetKeyDown(KeyCode.Space))
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumSpeed);
                audioManager.PlayJumpSound();
                isGround = false;
            }
        }
    }



    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }

    private void UpdateAnimation()
    {
        bool isRunning = Math.Abs(rb.linearVelocity.x) > 0.1f;

        bool isJumping = !isGround;

        animator.SetBool("IsRunning", isRunning);

        animator.SetBool("IsJumpping", isJumping);
    }


}
