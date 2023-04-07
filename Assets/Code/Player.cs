using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public int speed = 5;

    public int jumpForce = 700;

    public int bulletForce = 500;

    public GameObject bulletPrefab;

    public Transform spawnPoint;

    public AudioClip shootSnd;

    public AudioClip hitSnd;

    public LayerMask whatIsGround;

    public Transform feet;

    GameManager _gamemanager;

    public string currLevel;

    bool grounded = false;

    private Rigidbody2D _rigidbody;

    private Animator _animator;

    private AudioSource _audiosource;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
       _gamemanager = GameObject.FindObjectOfType<GameManager>();
        _audiosource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Bullet")) {
            GameManager.ResetSpeed();
            GameManager.resetBullets();
            GameManager.resetDeathZone();
            int lives = GameManager.RemoveLife();
            GameManager.atTop = true;
            StartCoroutine(getHit(lives));
        }
    }
    IEnumerator getHit(int lives) {
        _audiosource.PlayOneShot(hitSnd);  
        GetComponent<SpriteRenderer> ().color = Color.red;
        yield return new WaitForSeconds(.20f);
        GetComponent<SpriteRenderer> ().color = Color.white;
        if (lives == 0) {
                SceneManager.LoadScene("GameOver");
                GameManager.ResetLives();
                GameManager.ResetSpeed();
                GameManager.changeResetStatus(true);
            }
            else{
            SceneManager.LoadScene(currLevel);
            GameManager.ResetSpeed();
            GameManager.changeResetStatus(true);
            
            }          
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("spike"))
        {
            GameManager.ResetSpeed();
            GameManager.resetBullets();
            GameManager.resetDeathZone();
            int lives = GameManager.RemoveLife();
            GameManager.atTop = true;
            StartCoroutine(getHit(lives));
        }
    }
    
    void FixedUpdate()
    {
        float xSpeed = Input.GetAxis("Horizontal") * speed;
        _rigidbody.velocity = new Vector2(xSpeed, _rigidbody.velocity.y);

        float xScale = transform.localScale.x;
        if ((xSpeed < 0 && xScale > 0) || (xSpeed > 0 && xScale < 0))
        {
            transform.localScale *= new Vector2(-1, 1);
        }

        _animator.SetFloat("Speed", Mathf.Abs(xSpeed));
    }

    // Update is called once per frame
    void Update()
    {
        print(GameManager.getResetStatus());
        grounded = Physics2D.OverlapCircle(feet.position, .25f, whatIsGround);
        _animator.SetBool("Grounded", grounded);

        if(Input.GetButtonDown("Jump") && grounded)
        {
            _rigidbody.AddForce(new Vector2(0, jumpForce));
        }

        if(Input.GetButtonDown("Fire1"))
        {
            _audiosource.PlayOneShot(shootSnd);

            _animator.Play("P_Attack");
            
            GameObject newBullet =  Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);

            if (transform.localScale.x < 0) 
            {
                newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(-bulletForce, 0));
            }
            else
            {
                newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(bulletForce, 0));
            }
        }

        if (transform.position.y < GameManager.getDeathZone()) {
            GameManager.ResetSpeed();
            GameManager.resetBullets();
            GameManager.resetDeathZone();
            int lives = GameManager.RemoveLife();
            GameManager.atTop = true;
            StartCoroutine(getHit(lives));

        }
        grounded = Physics2D.OverlapCircle(feet.position,.4f,whatIsGround);
        if(Input.GetButtonDown("Jump")&& grounded)
        {
            _rigidbody.AddForce(new Vector2(0, jumpForce));
        }
    }
    // IEnumerator Death() {
    //     // _animator.Play()
    //     yield return new WaitForSeconds(.08f);
    // }
}

