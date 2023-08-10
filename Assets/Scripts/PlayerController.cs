using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;

    public float jumpForse;
    private GroundCheck groundCheck;

    [SerializeField] ParticleSystem[] _particlesLanded;
    private Animator _anim;

    //Actions
    public static Action saveMaxScore;
    public static Action isGameOver;

    public static Action soundJump;
    public static Action soundFall;
    public static Action soundDeath;

    private void OnEnable()
    {
        MovePlatform.setLeftPlayer += SetLeftSptire;
        MovePlatform.setRightPlayer += SetRightSptire;
        GameContinue.setDefaultPos += SetDefaultPos;
    }

    private void OnDisable()
    {
        MovePlatform.setLeftPlayer -= SetLeftSptire;
        MovePlatform.setRightPlayer -= SetRightSptire;
        GameContinue.setDefaultPos -= SetDefaultPos;
    }

    private void Awake()
    {
        Instance = this;

        _rb= GetComponent<Rigidbody2D>();
        _anim= GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        groundCheck = GetComponentInChildren<GroundCheck>();
    }

    public void Jump()
    {
        if (groundCheck.isGround)
        {
            _rb.AddForce(Vector2.up * jumpForse, ForceMode2D.Impulse);
            soundJump?.Invoke();
        }

        if (!groundCheck.isGround)
        _rb.AddForce(Vector2.down * jumpForse * 2, ForceMode2D.Impulse);
    }

    public void SetDefaultPos()
    {
        _rb.velocity = new Vector3(0, 0, 0);
        gameObject.transform.position += new Vector3(0,3,0);

    }

    public void SetRightSptire()
    {
        _spriteRenderer.flipX = false;
    }
    public void SetLeftSptire()
    {
        _spriteRenderer.flipX = true;
    }

    private void Update()
    {
        /*if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began && !GameOver.isGameOver) Jump();*/
        _anim.SetFloat("velY", _rb.velocity.y);

        //input PC test
        if (Input.GetKeyDown(KeyCode.Space) && !GameOver.isGameOver) Jump();
    }

    /* public void Down()
    {
        if (!GroundCheck.isGround)
        _rb.AddForce(Vector2.down * jumpForse * 2, ForceMode2D.Impulse);
    } */

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("Landed");
            saveMaxScore?.Invoke();

            Database.instance.SaveGameData();

            // Play Anim
            for (int i = 0; i < _particlesLanded.Length; i++) 
            {
                _particlesLanded[i].Play();
            }

            // play Sound
            soundFall?.Invoke();
        }

        if (collision.gameObject.tag == "Death")
        {
            saveMaxScore?.Invoke();

            Database.instance.SaveGameData();

            isGameOver?.Invoke();
            Debug.Log("Death");

            // play Sound
            soundDeath?.Invoke();
        }
    }
}
