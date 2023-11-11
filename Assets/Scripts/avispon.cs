using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class avispon : MonoBehaviour
{
    private bool start = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            transform.Translate(-0.025f, 0, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "destroy")
        {
            Destroy(this.gameObject);
        }
    }
    public void SetStart()
    {
        start = true;
    }
}
