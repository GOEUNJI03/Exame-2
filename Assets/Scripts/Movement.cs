using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Movement : MonoBehaviour
{
    [SerializeField] private avispon avi;
    [SerializeField] private movGato movG;
    [SerializeField] private Camera cam;
    private int entityCount1;
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
    //private bool moving;

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
        //entityCount1 = CountEntitiesWithTag("enemys_stage1");

        horizontal = joyStick.Horizontal;
        transform.Translate(horizontal * speed * Time.deltaTime, 0, 0);

        if (rb.velocity.y <= 0)
        {
            animJump = false;
            anim.SetFloat("MoveY", 0);
        }
        if (horizontal < 0.0f)
        {
            //moving = true;
            anim.SetFloat("MoveX", 1);
            transform.localScale = new Vector3(-0.080761f, 0.080761f, 0.080761f);
        }
        else if (horizontal > 0.0f)
        {
            //moving = true;
            anim.SetFloat("MoveX", 1);
            transform.localScale = new Vector3(0.080761f, 0.080761f, 0.080761f);
        }
        if (horizontal == 0)
        {
            anim.SetFloat("MoveX", 0);
        }
        {
            
        }


        _checkAnimation();

        if (dead)
        {
            SceneManager.LoadScene("loser");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (atack)
        {
            if (collision.tag == "enemy_stage1")
            {
                Destroy(collision.gameObject);
                //Debug.Log("enemy_ata");
            }
        }
        else
        {
            if (collision.tag == "enemy_stage1")
            {
                Debug.Log("enemy_dead");
                dead = true;
            }
        }
        if (atack)
        {
            if (collision.tag == "enemy_stage2")
            {
                Destroy(collision.gameObject);
                //Debug.Log("enemy_ata");
            }
        }
        else
        {
            if (collision.tag == "enemy_stage2")
            {
                Debug.Log("enemy_dead");
                dead = true;
            }
        }
        if (atack)
        {
            if (collision.tag == "enemy_stage3")
            {
                Destroy(collision.gameObject);
                //Debug.Log("enemy_ata");
            }
        }
        else
        {
            if (collision.tag == "enemy_stage3")
            {
                //Debug.Log("enemy_dead");
                dead = true;
            }
        }
        if (collision.gameObject.tag == "tp1")
        {
            if (GameObject.FindGameObjectsWithTag("enemy_stage1").Length == 0) 
            {
                movG.SetStart();
                cam.transform.position = new Vector3(20, 0.02f, -10);
                this.transform.position = new Vector3(11.5f, -3, 0);
            }
        }
        if (collision.gameObject.tag == "tp2")
        {
            //avi.SetStart();
            cam.transform.position = new Vector3(40, 0.02f, -10);
            this.transform.position = new Vector3(31.5f, -3, 0);
        }
        if (collision.gameObject.tag == "win")
        {
            SceneManager.LoadScene("win");
        }
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
        anim.Play("ataque_player");
        atack = true;
        anim.SetFloat("MoveX", 1);
        anim.SetFloat("MoveY", 1);
        StartCoroutine(Stop(.31f));
    }
    
    void _checkAnimation()
    {
        if (animJump)
        {
            //Debug.Log("salto");
            //anim.Play("salto_player");
            return;
        }
        if (walking)
        {
            //Debug.Log("caminar");
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
        yield return new WaitForSeconds(1);
        atack = false;
    }
}