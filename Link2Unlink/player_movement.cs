using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_movement : MonoBehaviour
{
    Scene sc;
    public ParticleSystem ps;
    public bool checker = false;

    [SerializeField]
    public float moveForce = 10;

    [SerializeField]
    public float jumpForce = 14;


    public float movementX;

    public ParticleSystem ps1;
    public ParticleSystem ps2;
    public ParticleSystem ps3;
    public ParticleSystem ps4;


    [SerializeField]
    private Rigidbody2D myBody;
    private SpriteRenderer sr;
    private Animator anim;
    


   
    // private string GROUND_tag = "Ground";

    //  private string Enemy_Tag = "Enemy";

    private bool isGrounded = true;

    // Start is called before the first frame update

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        sc = SceneManager.GetActiveScene();

    }

    // Update is called once per frame
    void Update()
    {
        Keyboard();
        animateplayer();
        jump_player();
    }
    private void FixedUpdate()
    {
        jump_player();
    }
    void Keyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }
    void animateplayer()
    {
        if (movementX > 0)
        {
            anim.SetBool("walk", true);
            sr.flipX = false;

        }
        else if (movementX < 0)
        {
            anim.SetBool("walk", true);
            sr.flipX = true;
            jump_player();
        }
        else
        {
            anim.SetBool("walk", false);

        }
    }
    void jump_player()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            anim.SetBool("walk", false);
            anim.SetBool("jump", true);
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {
            anim.SetBool("jump", false);
            isGrounded = true;
            anim.SetBool("walk", false);
        }

        if (collision.gameObject.CompareTag("Respawn"))
        {
            SceneManager.LoadScene("SampleScene1");
        }
        if(collision.gameObject.CompareTag("Plant"))
        {
            ps.Play();
            checker = true;
        }
        if (sc.name == "SampleScene1")
        {
            if (collision.gameObject.CompareTag("Mystery1"))
            {
                ps1.Play();

            }
            if (collision.gameObject.CompareTag("Mystery2"))
            {
                ps2.Play();

            }
            if (collision.gameObject.CompareTag("Mystery3"))
            {
                ps3.Play();

            }
            if (collision.gameObject.CompareTag("Mystery4"))
            {
                ps4.Play();

            }
            if (ps1.isPlaying && ps2.isPlaying && ps3.isPlaying && ps4.isPlaying)
            {
                SceneManager.LoadScene("final_menu");
            }
        }

    }

}