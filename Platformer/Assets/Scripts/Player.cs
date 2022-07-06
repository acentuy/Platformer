using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Hero")]
    [SerializeField] private int maxHealth = 5;
    [SerializeField] private float speed = 3f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float groundRadius = 0.2f;
    [Space]
    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private AudioSource damageSound;
    [Header("Canvas")]
    [SerializeField] private Text coinsText;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private HealthBar healthBar;
    [Header("Control")]
    [SerializeField] private Joystick joystick;
    [SerializeField] private PauseController pauseController;
    [Space]
    [SerializeField] private GameObject hero;
    [SerializeField] private GameObject effect;
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private GameObject winScreen;

    private int currentHealth;
    private int impulseX = -6;
    private int impulseY = 2;
    private int coins = 0;
    private int level = 2;
    private float x = -4;
    private float y = -6;

    private bool stor = true;
    private bool isGrounded = false;
    private bool isFacingRight = true;

    private Animator animator;
    public static Player Instance { get; set; }
    public enum State
    {
        Idle,
        Run,
        Jump
    }
    private State States
    {
        get { return (State)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        pauseController = GameObject.FindGameObjectWithTag("PauseController").GetComponent<PauseController>();
        Instance = this;
        currentHealth = maxHealth;
        LoadData();
    }
    private void Start()
    {
        hero.SetActive(true);
        coinsText.text = coins.ToString();
        healthBar.SetHealth(currentHealth);
        rb.transform.position = new Vector2(x, y);
    }
    private void FixedUpdate()
    {
        CheckGround();
        if (joystick.Horizontal > 0 && !isFacingRight) Flip();
        else if (joystick.Horizontal < 0 && isFacingRight) Flip();
    }
    public void Update()
    {
        if (isGrounded) States = State.Idle;
        if (joystick.Horizontal != 0) Run();

    }
    public void PauseClick()
    {
        hero.SetActive(false);
        SaveData();
        pauseController.PauseGame();
    }
    private void SaveData()
    {
        PlayerPrefs.SetInt("LEVEL_KEY", level);
        PlayerPrefs.SetInt("COIN_KEY", coins);
        PlayerPrefs.SetInt("HEALTH_KEY", currentHealth);
        PlayerPrefs.SetFloat("X_KEY", rb.transform.position.x);
        PlayerPrefs.SetFloat("Y_KEY", rb.transform.position.y);
    }
    private void LoadData()
    {
        if (PlayerPrefs.HasKey("COIN_KEY"))
            coins = PlayerPrefs.GetInt("COIN_KEY");
        if (PlayerPrefs.HasKey("LEVEL_KEY"))
            level = PlayerPrefs.GetInt("LEVEL_KEY");
        if (PlayerPrefs.HasKey("HEALTH_KEY"))
            currentHealth = PlayerPrefs.GetInt("HEALTH_KEY");
        if (PlayerPrefs.HasKey("X_KEY"))
            x = PlayerPrefs.GetFloat("X_KEY");
        if (PlayerPrefs.HasKey("Y_KEY"))
            y = PlayerPrefs.GetFloat("Y_KEY");
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        stor = !stor;
    }
    private void Run()
    {
        if (isGrounded) States = State.Run;
        Vector3 dir = transform.right * joystick.Horizontal;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
    }
    public void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
            jumpSound.Play();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            coins++;
            coinsText.text = coins.ToString();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "DeadZone")
        {
            Die();
        }
        if (collision.gameObject.tag == "Star")
        {
            Destroy(collision.gameObject);
            Star();
        }
    }
    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        if (!isGrounded) States = State.Jump;
    }
    public void GetDamage()
    {
        currentHealth -= 1;
        healthBar.SetHealth(currentHealth);
        impulseX = stor ? impulseX * 1 : impulseX * -1;
        rb.AddForce(new Vector2(impulseX, impulseY), ForceMode2D.Impulse);
        if (currentHealth == 0) 
        {
            Die();
            return;
        }
        damageSound.Play();
    }
    private void Die()
    {
        hero.SetActive(false);
        Instantiate(effect, transform.position, Quaternion.identity);
        deathScreen.SetActive(true);
    }
    private void Star()
    {
        hero.SetActive(false);
        winScreen.SetActive(true);
    }
}

