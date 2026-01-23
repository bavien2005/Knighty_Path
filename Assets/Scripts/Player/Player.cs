using System;
using UnityEngine;
public class Player : MonoBehaviour
{


    [Header("Move")]
    [SerializeField] private float moveSpeed = 20f;

    [SerializeField] private float jumSpeed = 15f;

    [SerializeField] private bool isGround = true;

    [Header("Health")]
    [SerializeField] private float health;

    [SerializeField] private float maxHealth;

    [SerializeField] private float maxTotalHealth;
    
    public float Health { get { return health; } }

    public float MaxHealth { get { return maxHealth; } }

    public float MaxTotalHealth { get { return maxTotalHealth; } }


    private Animator animator;


    private Rigidbody2D rb;

    private AudioManager audioManager;

    private MobileInput mobileInput;

    public delegate void OnHealthChangedDelegate();

    public OnHealthChangedDelegate onHealthChanged;


    #region Sigleton
    private static Player instance;
    public static Player Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<Player>();
            return instance;
        }
    }
    #endregion

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

    private void ClampHealth()
    {
        health = Math.Clamp(health , 0 , maxHealth);
        if (onHealthChanged != null )
        {
            onHealthChanged.Invoke();
        }
    }
    public void Heal(float health)
    {
        this.health += health;
        ClampHealth();
    }

    public void TakeDamage(float dmg)
    {
        this.health -= dmg;
        ClampHealth();
    }

    public void AddHealth()
    {
        if (maxHealth < maxTotalHealth)
        {
            maxHealth += 1;
            health = maxHealth;

            if (onHealthChanged != null)
                onHealthChanged.Invoke();
        }
    }

}
