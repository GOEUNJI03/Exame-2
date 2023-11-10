using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Movement : MonoBehaviour
{
    private float speed = 3;
    private float Horizontal;
    private float jumpForce = 5f;
    private Rigidbody2D rb;
    [SerializeField] private Joystick joyStick;
    [SerializeField] private GameObject joyStickObject;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = joyStick.Horizontal;
        joyStickObject.SetActive(true);
        transform.Translate(Horizontal * speed * Time.deltaTime, 0, 0);
        if (Horizontal < 0.0f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (Horizontal > 0.0f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
    public void BotonJump()
    {
        if (Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            //animJump = true;
            //sfx.PlayJump();
        }
    }
}