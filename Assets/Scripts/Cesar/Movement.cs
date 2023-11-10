using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Movement : MonoBehaviour
{
    private bool dead;
    private bool atack;
    private bool animJump = false;
    private bool walking;
    private float speed = 3;
    private float horizontal;
    private float jumpForce = 5f;
    private Rigidbody2D rb;
    [SerializeField] private Joystick joyStick;
    [SerializeField] private Animator anim;
    [SerializeField] private SFX sfx;
    //[SerializeField] private GameObject joyStickObject;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = joyStick.Horizontal;
        transform.Translate(horizontal * speed * Time.deltaTime, 0, 0);

        if (rb.velocity.y <= 0)
        {
            animJump = false;
            //anim.SetFloat("MoveY", 0);
        }

        if (horizontal < 0.0f)
        {
            if (Mathf.Abs(rb.velocity.y) < 0.001f)
            {
                WalkingOn();
            }
            transform.localScale = new Vector3(-0.080761f, 0.080761f, 0.080761f);
        }
        else if (horizontal > 0.0f)
        {
            if(Mathf.Abs(rb.velocity.y) < 0.001f)
            {
                WalkingOn();
            }
            transform.localScale = new Vector3(0.080761f, 0.080761f, 0.080761f);
        }


        if (horizontal == 0 || Mathf.Abs(rb.velocity.y) > 0.001f)
        {
            WalkingOff();
        }
        _checkAnimation();

        /*if (dead)
        {
            SceneManager.LoadScene("loser");
        }*/
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (atack)
        {
            Debug.Log("enemy");
            /*if (collision.tag == "Enemy")
            {
                Destroy(collision.gameObject);
            }*/
        }
        /*else
        {
            if (collision.tag == "Enemy")
            {
                dead = true;
            }
        }*/
    }
            public void BotonJump()
    {
        if (Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            animJump = true;
            anim.SetFloat("MoveX", 0);
            anim.SetFloat("MoveY", 1);
            StartCoroutine(Stop(1f));
            sfx.PlayJump();
        }
    }
    public void BotonAtaque()
    {
        anim.SetBool("atackf", false);
        //anim.Play("ataque_player");
        //atack = true;
        /*anim.SetFloat("MoveX", 1);
        anim.SetFloat("MoveY", 1);*/
        StartCoroutine(Stop(.62f));
    }
    private void WalkingOn()
    {
        anim.SetFloat("MoveX", 1);
        sfx.PlayWalk();
        walking = true;
    }
    private void WalkingOff()
    {
        anim.SetFloat("MoveX", 0);
        sfx.StopWalk();
        walking = false;
    }
    void _checkAnimation()
    {
        if (animJump)
        {
            Debug.Log("salto");
            //anim.Play("salto_player");
            return;
        }
        if (walking)
        {
            Debug.Log("caminar");
            //anim.Play("player_run");
            return;
        }

        //anim.Play("idl_player");

    }
    IEnumerator Stop(float Tiempo)
    {
        yield return new WaitForSeconds(Tiempo);
        anim.SetFloat("MoveX", 0);
        anim.SetFloat("MoveY", 0);
        anim.SetBool("atackf", true);
        //atack = false;
    }
}